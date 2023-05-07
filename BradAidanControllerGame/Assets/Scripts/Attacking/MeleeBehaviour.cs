/*****************************************************************************
// File Name :         MeleeBehaviour.cs
// Author :            Brad Dixon
// Creation Date :     May 7th, 2023
//
// Brief Description : Makes sure enemy is in range
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    public bool inRange;

    public GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;

        target = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
