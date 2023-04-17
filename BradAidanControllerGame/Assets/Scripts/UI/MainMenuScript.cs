/*****************************************************************************
// File Name :         MainMenu.cs
// Author :            Aidan Ratcliffe
// Creation Date :     April 16th, 2023
//
// Brief Description : Code for Main Menu Screen
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("AidanScene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
