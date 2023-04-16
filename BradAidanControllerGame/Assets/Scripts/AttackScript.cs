/*****************************************************************************
// File Name :         AttackScript.cs
// Author :            Aidan Ratcliffe
// Creation Date :     April 9th, 2023
//
// Brief Description : Attacking for the player
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Ranger Rplayer;
    public GameObject RightAttackArea;
    public GameObject LeftAttackArea;
    PlayerControls controls;
    public bool HasAttacked;
    public float timer;


    private void Awake()
    {
        controls = new PlayerControls();

        controls.PlayerActions.Light.performed += ctx => Light();
    }

    private void Light()
    {
        Attack();
    }

    public void Attack()
    {
        if (HasAttacked == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 2f;
            HasAttacked = false;
            RightAttackArea.SetActive(false);
            LeftAttackArea.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightAttack()
    {
        RightAttackArea.SetActive(true);
        HasAttacked = true;
    }

    public void LeftAttack()
    {
        LeftAttackArea.SetActive(true);
        HasAttacked = true;
    }
    private void OnEnable()
    {
        controls.PlayerActions.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerActions.Disable();
    }
}
