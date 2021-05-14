using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuizManager : MonoBehaviour
{
    [SerializeField] private float timeInSeconds;
    public QuestionData quizData;
    private List<Question> questions;

    [SerializeField]
    private SceneManagment sceneManagment;

    public static QuizManager Instance;
    public bool beatenScore = false;
    public int score;
    public QuizUI quizUI;
    private float currentTime;
    public Question selectedQuestion;
    int counter = 0;


    private void Start()
    {
        Instance = this;
        questions = new List<Question>();
        questions.AddRange(quizData.questions);
        SelectQuestion();
        currentTime = timeInSeconds;
      
    }

    private void Update()
    {

        currentTime -= Time.deltaTime;
        SetTime(currentTime);

    }

    void SelectQuestion()
    {
        int val = UnityEngine.Random.Range(0, questions.Count);
        selectedQuestion = questions[val];

        quizUI.SetQuestion(selectedQuestion);
        questions.RemoveAt(val);
    }

    public bool Answer(string selectedOption)
    {

        bool correct; 

        if (selectedQuestion.correctAns == selectedOption)
        {
            counter++;
            
            if(counter == 5)
            {
                currentTime += 5;
                counter = 0;
            }
            
            correct = true;
            score += 10;
            quizUI.ScoreText.text = score.ToString();
        }
        else
        {
            counter = 0;
            correct = false;
            
            score -= 3;
            quizUI.ScoreText.text = score.ToString();

        }


        Invoke("SelectQuestion", 0.4f);

       
        return correct;
    }

   
    void SetTime(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(value);                      
        quizUI.TimerText.text = time.ToString("mm':'ss");   


        

        if (value <= 0)
        {
            PlayerPrefs.SetInt("Score", score);
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                quizUI.HighScore.text = score.ToString();
                PlayerPrefs.SetInt("HighScore", score);
                beatenScore = true;
            }
            GameEnd();
            
        }
    }

    private void GameEnd()
    {
        
        sceneManagment.GameOver();
    }
}
