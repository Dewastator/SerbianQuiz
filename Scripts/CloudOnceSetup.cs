using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;
using System;


public class CloudOnceSetup : MonoBehaviour
{
    public static CloudOnceSetup Instance;


    private void Awake()
    {
        TestSingleton();
    }

    private void TestSingleton()
    {
        if(Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SubmitScoreToLeaderboards(int Score)
    {
        Leaderboards.HighScore.SubmitScore(Score);
           
    }
}
