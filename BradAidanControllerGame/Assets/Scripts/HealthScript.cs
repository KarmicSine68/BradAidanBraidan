using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int maxhealth = 100;
    public int health = 100;
    public Sprite HealthSprite1;
    public Sprite HealthSprite2;
    public Sprite HealthSprite3;
    public Sprite HealthSprite4;
    public Sprite HealthSprite5;
    public Sprite HealthSprite6;
    public Sprite HealthSprite7;
    public Sprite HealthSprite8;
    public Sprite HealthSprite9;

    private void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(health);

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        //SceneManager.LoadScene("GameOver");
        //Invoke("Respwan", 5f);
    }

    public void Respwan()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-0.01f, -3.57f, 0);
        health = 100;
    }
}
