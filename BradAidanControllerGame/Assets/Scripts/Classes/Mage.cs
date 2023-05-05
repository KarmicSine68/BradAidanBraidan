/*****************************************************************************
// File Name :         Mage.cs
// Author :            Brad Dixon
// Creation Date :     March 28th, 2023
//
// Brief Description : Data for the mage
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mage : ClassChanger
{
    private Vector3 target;
    public GameObject player;
    public GameObject MagicPrefab;
    PlayerControls controls;

    public float ProjectileSpeed;

    InputActionAsset inputAsset;
    InputActionMap inputMap;
    InputAction lightAttack;

    private void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        inputMap = inputAsset.FindActionMap("PlayerActions");
        lightAttack = inputMap.FindAction("Light");

        lightAttack.performed += ctx => Light();
    }

    private void Light()
    {
        Vector3 difference = target - player.transform.position;
        //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        PlayerBehaviour pb = FindObjectOfType<PlayerBehaviour>();
        if(pb.facingLeft)
        {
            ShootMagic(-direction);
        }
        else
        {
            ShootMagic(direction);
        }
    }

    void ShootMagic(Vector2 direction)
    {
        //Checks to make sure the mage script is enabled
        if (gameObject.GetComponent<Mage>().enabled)
        {
            GameObject m = Instantiate(MagicPrefab) as GameObject;
            m.transform.position = player.transform.position;
            m.GetComponent<Rigidbody2D>().velocity = direction * ProjectileSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        inputMap.Enable();
    }

    private void OnDisable()
    {
        inputMap.Disable();
    }
}
