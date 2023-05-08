/*****************************************************************************
// File Name :         StartUI.cs
// Author :            Brad Dixon
// Creation Date :     May 7th, 2023
//
// Brief Description : Tells players how to join
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    private GameObject player;

    /// <summary>
    /// Makes sure the UI is visible on start
    /// </summary>
    void Start()
    {
        startUI.SetActive(true);
    }

    /// <summary>
    /// Once a player joins, UI goes away
    /// </summary>
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            startUI.SetActive(false);
        }
    }
}
