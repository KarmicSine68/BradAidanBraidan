using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject enemyPrefab;
    public float respawnTime = 1.0f;
    private SpriteRenderer mySpriteRenderer;
    public int damage;
    public HealthScript health;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        var playerdamage = GameObject.Find("Player");
        health = playerdamage.GetComponent<HealthScript>();
    }

    private void spawnEnemy()
    {
        GameObject e = Instantiate(enemyPrefab) as GameObject;
    }
    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        mySpriteRenderer.flipX = true;
        direction.Normalize();
        movement = direction;
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
            if (collision.CompareTag("Player"))
            {
                health.Damage(damage);
            }
        }

    }
    public void Die()
    {

    }

}
