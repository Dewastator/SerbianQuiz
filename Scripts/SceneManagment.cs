using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagment : MonoBehaviour
{

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartQuiz()
    {
        SceneManager.LoadScene("Kviz");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void TurizamLoad()
    {
        Application.OpenURL("https://www.instagram.com/turizam_srbije/");
        
    }
}
