/*****************************************************************************
// File Name :         HowToPlay.cs
// Author :            Aidan Ratcliffe
// Creation Date :     April 17th, 2023
//
// Brief Description : Script for How To play screen
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
   public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    } 
}
