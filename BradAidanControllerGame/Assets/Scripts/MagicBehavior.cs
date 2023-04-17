using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
                eb.spawnEnemy();
                hasSpawned = true;

            }
            Destroy(other.gameObject, 0.1f);
            Destroy(gameObject);
        }

        else if(other.CompareTag("Player") != true)
        {
            Destroy(gameObject, 0.1f);
        }
       

        
        //Destroy(other.gameObject);
        //Destroy(this.gameObject);
    }
}
