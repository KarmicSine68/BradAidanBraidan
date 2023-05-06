/*****************************************************************************
// File Name :         StartButtonBehaviour.cs
// Author :            Brad Dixon
// Creation Date :     May 4th, 2023
//
// Brief Description : Starts the game when the player(s) stand on the button
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject starting;

    private bool onButton;

    /// <summary>
    /// Sets the default state of the variables
    /// </summary>
    void Start()
    {
        starting.SetActive(false);
        onButton = false;
    }

    /// <summary>
    /// Checks to see if the player is on the starting button
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onButton = true;
        starting.SetActive(true);

        StartCoroutine(Countdown());
    }

    /// <summary>
    /// Checks to see if the player is off the starting button
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        onButton = false;
        starting.SetActive(false);
    }

    /// <summary>
    /// After x seconds, starts the game if the player is on the button
    /// </summary>
    /// <returns></returns>
    IEnumerator Countdown()
    {
        CharacterSelectController ctx = 
            FindObjectOfType<CharacterSelectController>();
        yield return new WaitForSeconds(3f);
        if(onButton)
        {
            GameObject[] choices = 
                GameObject.FindGameObjectsWithTag("CharacterSelect");

            foreach(GameObject temp in choices)
            {
                Destroy(temp);
            }
            ctx.StartGame();
        }
    }
}
