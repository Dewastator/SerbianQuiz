using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Color correctCol, wrongCol, normalCol;
    private Question question;
    [SerializeField]
    private Text questionInfo;
    [SerializeField]
    public Text ScoreText;
    [SerializeField]
    public Text TimerText;
    [SerializeField]
    public Text HighScore;
    [SerializeField]
    private List<Button> options;
    [SerializeField]
    private Image questionImage;
    [SerializeField]
    private Image questionImageBackground;
    [SerializeField]
    private QuizManager quizManager;
    [SerializeField]
    private Image HorImage, VerImage, BonusPanel;
    Animator animator;
    public GameObject objectToRotate;
    private bool rotating;
    private bool answered = false;
    int counter = 0;

    private void Start()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        animator = BonusPanel.GetComponent<Animator>();
        BonusPanel.gameObject.SetActive(false);
        
    }
   

    public void SetQuestion(Question question)
    {
        this.question = question;

        questionInfo.text = question.question;

        List<string> ansOptions = ShuffleList.ShuffleListItems(question.options);

        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<Text>().text = ansOptions[i];
            options[i].name = ansOptions[i];
            options[i].image.color = normalCol;
        }

        SetQuestionImage(question);
        answered = false;
    }

    private void SetQuestionImage(Question question)
    {
        if (question.questionImage == null)
        {
            questionImage.gameObject.SetActive(false);
            questionImageBackground.gameObject.SetActive(false);
        }
        else
        {

            questionImageBackground.gameObject.SetActive(true);
            questionImage.sprite = question.questionImage;
            questionImage.gameObject.SetActive(true);
        }
    }

    void OnClick(Button btn)
    {
        
        if (!answered)
        {
            
            answered = true;
            
            bool val = quizManager.Answer(btn.name);

            
            if (val)
            {
                counter++;

                if (counter == 5)
                {
                    BonusPanel.gameObject.SetActive(true);
                    
                    animator.SetBool("Show", true);
                    StartCoroutine(BonusPanelDis());
                    StartCoroutine(BonusPointLines());
                    counter = 0;
                }
              
                btn.image.color = correctCol;
            }
            else
            {
          
                btn.image.color = wrongCol;
                counter = 0;
            }
        }
        StartRotation();
    }

    private IEnumerator BonusPointLines()
    {
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(BonusPointsHor(0.06f));
        StartCoroutine(BonusPoints());
    }

    private IEnumerator BonusPanelDis()
    {
        yield return new WaitForSeconds(1f);
        BonusPanel.gameObject.SetActive(false);
        HorImage.fillAmount = 0;
        VerImage.fillAmount = 0;
    }

    private IEnumerator BonusPoints()
    {
        
        yield return new WaitForSeconds(0.15f);
        StartCoroutine(BonusPointsVer(0.06f));
    }

    private IEnumerator BonusPointsVer(float i)
    {
        yield return new WaitForSeconds(0.01f);
        VerImage.fillAmount += i;
        
        if (VerImage.fillAmount < 1 && VerImage.fillAmount > 0)
        {
            StartCoroutine(BonusPointsVer(i));
            
        }
       
        
    }
    private IEnumerator BonusPointsHor(float i)
    {
        yield return new WaitForSeconds(0.01f);
      
        HorImage.fillAmount += i;
        if (HorImage.fillAmount < 1 && HorImage.fillAmount > 0)
        {
            StartCoroutine(BonusPointsHor(i));
        }
        
       

    }
  

    private IEnumerator Rotate(Vector3 angles, float duration)
    {
        StartCoroutine(TxtFade());
        rotating = true;
        Quaternion startRotation = objectToRotate.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            objectToRotate.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
         
            yield return null;
            
        }
        
        questionInfo.gameObject.transform.rotation = Quaternion.identity;
        questionInfo.gameObject.SetActive(true);
        objectToRotate.transform.rotation = endRotation;
        rotating = false;
        
    }

    public void StartRotation()
    {

        if (!rotating)
            StartCoroutine(Rotate(new Vector3(180, 0, 0), 1));
        //StartCoroutine(TxtFade());
    }

    private IEnumerator TxtFade()
    {
        
        yield return new WaitForSeconds(0.50f);
        questionInfo.gameObject.SetActive(false);
    }

    
}
