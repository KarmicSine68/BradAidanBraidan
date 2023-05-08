/*****************************************************************************
// File Name :         TutorialButtons.cs
// Author :            Brad Dixon
// Creation Date :     May 5th, 2023
//
// Brief Description : Allows the player to choose of skip the tutorial
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtons : MonoBehaviour
{
    //Text to be deleted with the button
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject otherText;
    [SerializeField] private GameObject otherButton;

    //Used to determine if the button is the skip button
    [SerializeField] private bool skip;

    /// <summary>
    /// Activates or skips the tutorial when a player touches the button
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player(Clone)")
        {
            BradGameController ctx = FindObjectOfType<BradGameController>();
            if(skip)
            {
                ctx.SkipTutorial();
            }
            else
            {
                ctx.EnableTutorial();
            }

            Destroy(text);
            Destroy(otherButton);
            Destroy(otherText);
            Destroy(gameObject);
        }
    }
}
