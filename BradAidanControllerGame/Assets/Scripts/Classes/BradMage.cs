/*****************************************************************************
// File Name :         BradMage.cs
// Author :            Brad Dixon
// Creation Date :     May 7th, 2023
//
// Brief Description : The attack script for the mage class
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BradMage : MonoBehaviour
{
    //The spawnpoint for the spells
    [SerializeField] private GameObject spawn;

    //The spells for the mage
    [SerializeField] private GameObject lightSpell;
    [SerializeField] private GameObject mediumSpell;
    [SerializeField] private GameObject heavySpell;

    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction lightAttack;
    InputAction mediumAttack;
    InputAction heavyAttack;

    private bool canAttack;

    PlayerBehaviour aim;

    /// <summary>
    /// The input actions for the mage player
    /// </summary>
    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        lightAttack = inputMap.FindAction("Light");
        mediumAttack = inputMap.FindAction("Medium");
        heavyAttack = inputMap.FindAction("Heavy");

        lightAttack.performed += ctx => Attack("Light");
        mediumAttack.performed += ctx => Attack("Medium");
        heavyAttack.performed += ctx => Attack("Heavy");

        aim = gameObject.GetComponent<PlayerBehaviour>();
    }


    private void Attack(string type)
    {
        if(canAttack)
        {
            /*switch (type)
            {

            }*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Enables the input actions
    /// </summary>
    private void OnEnable()
    {
        inputMap.Enable();
    }

    /// <summary>
    /// Disables the input system
    /// </summary>
    private void OnDisable()
    {
        inputMap.Disable();
    }
}
