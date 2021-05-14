using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAnim : MonoBehaviour
{
    public Image menu, menuitems;
    
    private void Start()
    {
        menu.gameObject.SetActive(false);
        menuitems.gameObject.SetActive(false);
    }
    public void ShowHideMenu()
    {
        if (!menu.gameObject.activeSelf)
        {

            menu.gameObject.SetActive(true);
            
            StartCoroutine(MenuSlide(0.05f));
        }
        else
        {
            menuitems.gameObject.SetActive(false);
            StartCoroutine(MenuSlide(-0.05f));
        }
        
    }

    IEnumerator MenuSlide(float i)
    {
        yield return new WaitForSeconds(0.01f);
        menu.fillAmount += i;
        if (menu.fillAmount < 1 && menu.fillAmount > 0)
        {
            StartCoroutine(MenuSlide(i));
        }
        else if(menu.fillAmount == 0)
        {
            menu.gameObject.SetActive(false);
        }
        else if(menu.fillAmount == 1)
        {
            menuitems.gameObject.SetActive(true);
        }
    }

   
}
