using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Question
{
    public string question;
    public Sprite questionImage;
    public List<string> options;
    public string correctAns;
}
