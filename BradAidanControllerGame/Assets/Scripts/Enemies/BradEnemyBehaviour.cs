/*****************************************************************************
// File Name :         BradEnemyBehavior.cs
// Author :            Brad Dixon
// Creation Date :     April 26th, 2023
//
// Brief Description : Enemy AI and spawning
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BradEnemyBehaviour : MonoBehaviour
{
    //The player game object is used so the enemies move towards them
    [SerializeField] GameObject player;

    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Enemies move towards players until one of them is range
    void Update()
    {
        if (!inRange)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                player.transform.position, 2f * Time.deltaTime);
        }
    }

    /// <summary>
    /// Stops the enemies from moving into the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    /// <summary>
    /// If a player moves out of range, the enemy moves closer
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
