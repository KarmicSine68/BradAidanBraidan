using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyBehavior eb = FindObjectOfType<EnemyBehavior>();
            eb.spawnEnemy();
        }

            Destroy(other.gameObject);
        //Destroy(this.gameObject);
    }
}
