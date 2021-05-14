using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField]
    private Text Score, HighScoreTxt;
    int scorePrefs, HighScorePrefs;

    [SerializeField]
    private ParticleSystem confetti;
  
    private void Start()
    {

        scorePrefs = PlayerPrefs.GetInt("Score", 0);
        HighScorePrefs = PlayerPrefs.GetInt("HighScore", 0);
        Score.text = scorePrefs.ToString();
        HighScoreTxt.text = HighScorePrefs.ToString();
        if (QuizManager.Instance.beatenScore)
        {
            confetti.Play();
            CloudOnceSetup.Instance.SubmitScoreToLeaderboards(scorePrefs);
        }
        
    }

    
}
