/*****************************************************************************
// File Name :         TutorialBehaviour.cs
// Author :            Brad Dixon
// Creation Date :     May 3rd, 2023
//
// Brief Description : Displays ingame information for how to play
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject lightAttack;
    [SerializeField] private GameObject mediumAttack;
    [SerializeField] private GameObject heavyAttack;

    PlayerControls controls;

    //Bools are used to see which tutorial text is enabled
    private bool onLight = false;
    private bool onMedium = false;
    private bool onHeavy = false;

    //Once a button has been pressed x amount of times, the text changes
    private int count;

    /// <summary>
    /// Runs code based off of input
    /// </summary>
    private void Awake()
    {
        controls = new PlayerControls();

        onLight = true;
        count = 0;

        controls.PlayerActions.Light.performed += ctx => ManageText();
        controls.PlayerActions.Medium.performed += ctx => ManageText();
        controls.PlayerActions.Heavy.performed += ctx => ManageText();
    }

    public void StartTutorial()
    {
        lightAttack.SetActive(true);
    }

    /// <summary>
    /// Changes the tutorial text after the condition has been met
    /// </summary>
    private void ManageText()
    {
        if(onLight || onMedium || onHeavy)
        {
            count++;
        }

        if(count >= 3)
        {
            if(onLight)
            {
                lightAttack.SetActive(false);
                mediumAttack.SetActive(true);
                onLight = false;
                onMedium = true;
                count = 0;
            }
            else if (onMedium)
            {
                mediumAttack.SetActive(false);
                heavyAttack.SetActive(true);
                onMedium = false;
                onHeavy = true;
                count = 0;
            }
            else if (onHeavy)
            {
                heavyAttack.SetActive(false);
                onHeavy = true;
            }
        }
    }

    /// <summary>
    /// Allows player input
    /// </summary>
    private void OnEnable()
    {
        controls.Enable();
    }

    /// <summary>
    /// Turns off player input
    /// </summary>
    private void OnDisable()
    {
        controls.Disable();
    }
}
