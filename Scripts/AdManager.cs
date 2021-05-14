using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private string gpid = "4017923";
    private string interstitialAd = "video";
    public bool isTestAd;
    private void Start()
    {
        InitializeAd();
    }

    private void InitializeAd()
    {
        Advertisement.Initialize(gpid, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd)) { return; }
        Advertisement.Show(interstitialAd);
    }

    
}
