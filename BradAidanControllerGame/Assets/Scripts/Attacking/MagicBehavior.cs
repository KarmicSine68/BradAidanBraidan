/*****************************************************************************
// File Name :         MagicBehavior.cs
// Author :            Aidan Ratcliffe
// Creation Date :     April 11th, 2023
//
// Brief Description : Code for Magic attack
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MagicBehavior : MonoBehaviour
{
    public bool hasSpawned;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyBehavior eb = FindObjectOfType<EnemyBehavior>();
            if(hasSpawned == false)
            {
                GameController gc = FindObjectOfType<GameController>();
                gc.EnemyCounter++;
                if (SceneManager.GetActiveScene().name != "AidanScene")
                {
                    if (gc.EnemyCounter <= 10)
                    {
                        eb.spawnEnemy();
                    }
                    else if (gc.EnemyCounter <= 20)
                    {
                        eb.spawnEnemy1();
                    }
                    else if (gc.EnemyCounter <= 30)
                    {
                        eb.spawnEnemy2();

                    }
                }
                else if (gc.EnemyCounter < 10)
                {
                    eb.spawnEnemy();
                }
                else if(gc.EnemyCounter >= 10)
                {
                    SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
                }
                hasSpawned = true;

            }
            Destroy(other.gameObject, 0.1f);
            Destroy(gameObject);
        }

        else if(other.CompareTag("Player") != true || other.CompareTag("AttackArea") != true)
        {
            Destroy(gameObject, 0.1f);
        }
       

        
        //Destroy(other.gameObject);
        //Destroy(this.gameObject);
    }
}
