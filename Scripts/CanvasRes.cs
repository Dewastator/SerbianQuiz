using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasRes : MonoBehaviour
{

    [SerializeField]
    private Image image;

    public float canX;
    public float canY;

    void Start()
    {

        SetPos();
    }

    private void SetPos()
    {
        canX = Screen.currentResolution.width;
        canY = Screen.currentResolution.height;

        image.rectTransform.sizeDelta = new Vector2(canX, canY);
    }
}
