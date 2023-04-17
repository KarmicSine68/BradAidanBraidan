using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaBehavior : MonoBehaviour
{

    public bool hasSpawned;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyBehavior eb = FindObjectOfType<EnemyBehavior>();
            if (hasSpawned == false)
            {
                GameController gc = FindObjectOfType<GameController>();
                gc.EnemyCounter++;
                eb.spawnEnemy();
                hasSpawned = true;
                StartCoroutine(Timer());
            }
            Destroy(other.gameObject, 0.1f);
            
        }

        else if (other.CompareTag("Player") != true && other.CompareTag("Magic") != true)
        {
            Destroy(other.gameObject, 0.1f);
        }
        //Destroy(this.gameObject);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.001f);
        hasSpawned = false;

    }
}
