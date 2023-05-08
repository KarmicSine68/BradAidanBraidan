/*****************************************************************************
// File Name :         BradMagic.cs
// Author :            Brad Dixon
// Creation Date :     May 7th, 2023
//
// Brief Description : Code for the spells themselves
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradMagic : MonoBehaviour
{
    private bool inRange;

    /// <summary>
    /// Damages enemies when a spell hits them
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.SendMessage("Attacked", 1);
            }
            Destroy(gameObject);
    }

    /// <summary>
    /// Damages enemies if the heavy spell hits
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            inRange = true;
            StartCoroutine(Attack(collision.gameObject));
        }
    }

    /// <summary>
    /// If enemy leaves the spell, they can't be hit
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            inRange = false;
        }
    }

    /// <summary>
    /// Damages enemy when the spell finishes if it hits
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    IEnumerator Attack(GameObject target)
    {
        yield return new WaitForSeconds(0.95f);

        if(inRange)
        {
            target.SendMessage("Attacked", 2);
        }
    }
}
