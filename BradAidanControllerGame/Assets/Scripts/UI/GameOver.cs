/*****************************************************************************
// File Name :         GameOver.cs
// Author :            Aidan Ratcliffe
// Creation Date :     May 10th, 2023
//
// Brief Description : Code for Game Over Screen
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
