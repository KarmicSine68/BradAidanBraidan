using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public int maxhealth = 100;
    public int health = 100;
    public GameObject HealthBar;
    public Texture HealthSprite1;
    public Texture HealthSprite2;
    public Texture HealthSprite3;
    public Texture HealthSprite4;
    public Texture HealthSprite5;
    public Texture HealthSprite6;
    public Texture HealthSprite7;
    public Texture HealthSprite8;
    public Texture HealthSprite9;

    private void Start()
    {
        health = maxhealth;
        HealthBar = GameObject.Find("HealthBar");
        //HealthSprite1 = GameObject.Find("HealthBar1").GetComponent<Texture>();
        //HealthSprite2 = GameObject.Find("HealthBar2").GetComponent<Texture>();
        //HealthSprite3 = GameObject.Find("HealthBar3").GetComponent<Texture>();
        //HealthSprite4 = GameObject.Find("HealthBar4").GetComponent<Texture>();
        //HealthSprite5 = GameObject.Find("HealthBar5").GetComponent<Texture>();
        //HealthSprite6 = GameObject.Find("HealthBar6").GetComponent<Texture>();
        //HealthSprite7 = GameObject.Find("HealthBar7").GetComponent<Texture>();
        //HealthSprite8 = GameObject.Find("HealthBar8").GetComponent<Texture>();
        //HealthSprite9 = GameObject.Find("HealthBar9").GetComponent<Texture>();
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
        if (health == 100)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite1;
        }
        if (health == 90)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite2;
        }
        if (health == 80)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite3;
        }
        if (health == 70)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite4;
        }
        if (health == 60)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite5;
        }
        if (health == 50)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite6;
        }
        if (health == 40)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite7;
        }
        if (health == 30)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite8;
        }
        if (health == 0)
        {
            HealthBar.GetComponent<RawImage>().texture = HealthSprite9;
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
        SceneManager.LoadScene("Main Menu");
        //Invoke("Respwan", 5f);
    }

    public void Respwan()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-0.01f, -3.57f, 0);
        health = 100;
    }
}
