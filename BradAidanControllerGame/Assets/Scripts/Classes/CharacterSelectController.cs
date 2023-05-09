/*****************************************************************************
// File Name :         CharacterSelectController.cs
// Author :            Brad Dixon
// Creation Date :     May 4th, 2023
//
// Brief Description : Controls the UI in the character select scene also 
//                     changes to the next scene
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectController : MonoBehaviour
{
    //All of these game objects are deleted when the new scene is added on top
    //of the current scene
    [SerializeField] private GameObject fighterText;
    [SerializeField] private GameObject mageText;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject startingText;
    [SerializeField] private GameObject startArea;
    [SerializeField] private GameObject background;

    /// <summary>
    /// Makes sure the button can't be presses until both players 
    /// have picked a class
    /// </summary>
    private void Start()
    {
        startArea.SetActive(false);
    }

    /// <summary>
    /// Makes the button available once both players have selected a class
    /// </summary>
    private void Update()
    {
        GameObject button = GameObject.FindGameObjectWithTag("CharacterSelect");
        if(button == null)
        {
            startArea.SetActive(true);
        }
    }

    /// <summary>
    /// Destroys old UI and loads the next scene
    /// </summary>
    public void StartGame()
    {
        Destroy(fighterText);
        Destroy(mageText);
        Destroy(instructions);
        Destroy(startText);
        Destroy(startingText);
        Destroy(startArea);
        Destroy(background);
        Destroy(gameObject);

        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
    }
}
