using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuService : MonoBehaviour
{
    [SerializeField]
    private Image pravila;
    private const string receiverEmailAddress = "danilopetrusic98@gmail.com";

    private void Start()
    {
        pravila.gameObject.SetActive(false);
    }

    public void PredloziPitanje()
    {
        string email = receiverEmailAddress;
        string subject = "Predlog pitanja!";
        OpenLink("mailto:" + email + "?subject=" + subject);
    }
    public void RateUs()
    {

        OpenLink("market://details?id=com.DaniloPetrusic.SrpskiKviz");
    }

    public void ContactUs()
    {
        string email = receiverEmailAddress;
        string subject = "Zdravo!";
        OpenLink("mailto:" + email + "?subject=" + subject);
    }

    public void PravilaIgre()
    {
        if (pravila.gameObject.activeSelf)
        {
            pravila.gameObject.SetActive(false);
        }
        else
        {

            pravila.gameObject.SetActive(true);
        }
        
    }
    private void OpenLink(string link)
    {
        Application.OpenURL(link);
    }

    public void PrivacyPolicyPage()
    {
        Application.OpenURL("https://danilopetrusic98.blogspot.com/p/srpski-kviz-privacy-policy.html");
    }
}
