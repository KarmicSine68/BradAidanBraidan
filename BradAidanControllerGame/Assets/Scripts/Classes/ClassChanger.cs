/*****************************************************************************
// File Name :         ClassChanger.cs
// Author :            Brad Dixon
// Creation Date :     March 23rd, 2023
//
// Brief Description : Determines the player's class
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassChanger : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string className;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour pb = GetComponent<PlayerBehaviour>();

        if (collision.gameObject.name == "Player(Clone)")
        {

        }
    }
}
