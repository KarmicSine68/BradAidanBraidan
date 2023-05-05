/*****************************************************************************
// File Name :         Ranger.cs
// Author :            Brad Dixon
// Creation Date :     March 29th, 2023
//
// Brief Description : Data for the ranger
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ranger : ClassChanger
{
    [SerializeField] GameObject meleeWeapon;

    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction lAttack;
    InputAction mAttack;
    InputAction hAttack;

    PlayerBehaviour playerBehaviour;

    /// <summary>
    /// Enables input and executes code based off of input
    /// </summary>
    private void Awake()
    {
        //playerBehaviour = new PlayerBehaviour();

        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        lAttack = inputMap.FindAction("Light");
        mAttack = inputMap.FindAction("Medium");
        hAttack = inputMap.FindAction("Heavy");

        lAttack.performed += ctx => LightAttack();
        mAttack.performed += ctx => MediumAttack();
        hAttack.performed += ctx => HeavyAttack();
    }

    /// <summary>
    /// Allows for the code to recieve player inputs
    /// </summary>
    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void LightAttack()
    {
        //Vector3 attackPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if(playerBehaviour.facingLeft)
        {
            Vector3 attackPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(meleeWeapon, attackPos, Quaternion.identity);
        }
    }

    private void MediumAttack()
    {

    }

    private void HeavyAttack()
    {

    }

    /// <summary>
    /// Stops the code from recieving player input
    /// </summary>
    private void OnDisable()
    {
        inputMap.Disable();
    }
}
