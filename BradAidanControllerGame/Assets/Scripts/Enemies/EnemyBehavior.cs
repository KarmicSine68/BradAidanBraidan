/*****************************************************************************
// File Name :         EnemyBehavior.cs
// Author :            Aidan Ratcliffe
// Creation Date :     April 9th, 2023
//
// Brief Description : Enemy AI and spawning
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject enemyPrefab;
    public float respawnTime = 5f;
    private SpriteRenderer mySpriteRenderer;
    public int damage;
    public HealthScript health;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    /*public void spawnEnemy()
    {
        GameObject e = Instantiate(enemyPrefab , new Vector2(6, 0) , Quaternion.identity) as GameObject;
    }

    public void spawnEnemy1()
    {
        GameObject e = Instantiate(enemyPrefab, new Vector2(14, 7), Quaternion.identity) as GameObject;
    }

    public void spawnEnemy2()
    {
        GameObject e = Instantiate(enemyPrefab, new Vector2(14, -7), Quaternion.identity) as GameObject;
    }

    IEnumerator enemyWave()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();

        }
        enemyWave1();
        StopCoroutine(enemyWave());
    }
    IEnumerator enemyWave1()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();

        }
        enemyWave2();
        StopCoroutine(enemyWave1());
    }
    IEnumerator enemyWave2()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();

        }
        StopCoroutine(enemyWave2());
    }*/
    


    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //mySpriteRenderer.flipX = true;
            direction.Normalize();
            movement = direction;
        }
        
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    private void EnemyAttack()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health = collision.GetComponent<HealthScript>();
                health.Damage(damage);
        }
        if (collision.CompareTag("Magic"))
        {
            Destroy(gameObject, 5f);
        }

    }
    public void Die()
    {

    }

}
