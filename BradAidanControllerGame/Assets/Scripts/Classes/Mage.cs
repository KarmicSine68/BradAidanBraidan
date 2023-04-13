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

    private void Awake()
    {
        controls = new PlayerControls();

        controls.PlayerActions.Light.performed += ctx => Light();
    }

    private void Light()
    {
        Vector3 difference = target - player.transform.position;
        //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        ShootMagic(direction);
    }

    void ShootMagic(Vector2 direction)
    {
        GameObject m = Instantiate(MagicPrefab) as GameObject;
        m.transform.position = player.transform.position;
        m.GetComponent<Rigidbody2D>().velocity = direction * ProjectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {

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
