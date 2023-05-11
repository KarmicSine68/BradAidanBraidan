/*****************************************************************************
// File Name :         BradHealthBehaviour.cs
// Author :            Brad Dixon
// Creation Date :     May 5th, 2023
//
// Brief Description : Goes down when enemies hit you
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BradHealthBehaviour : MonoBehaviour
{
    //The players healthbar
    [SerializeField] private Image health;
    [SerializeField] private GameObject healthBar;

    [SerializeField] float currentHealth, maxHealth = 100;

    private AudioSource sound;

    [SerializeField] AudioClip hitSound;

    float healthSpeed;

    /// <summary>
    /// Makes sure the current health starts at the max health
    /// Makes sure health bar doesn't appear until game starts
    /// </summary>
    void Start()
    {
        sound = FindObjectOfType<Camera>().GetComponent<AudioSource>();

        currentHealth = maxHealth;
        healthBar.SetActive(false);

        sound.volume = 0.2f;
        sound.pitch = 1.5f;

        sound.clip = hitSound;
    }

    /// <summary>
    /// Makes sure current health doesn't exceed max health, also makes surethe health changes
    /// </summary>
    void Update()
    {
        healthSpeed = 3 * Time.deltaTime;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        DisplayHealth();

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    /// <summary>
    /// Displays how much health
    /// </summary>
    private void DisplayHealth()
    {
        //Visual display of health
        //Lerp can only use values between 0 and 1
        health.fillAmount = Mathf.Lerp(health.fillAmount,
            (currentHealth / maxHealth), healthSpeed);

        Color healthColor = Color.Lerp(Color.red, Color.green, 
            (currentHealth / maxHealth));
        health.color = healthColor;
    }

    /// <summary>
    /// Resets the players health to full when they complete the tutorial
    /// </summary>
    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Makes it so the health bar is visible once the game starts
    /// </summary>
    public void EnableHealth()
    {
        healthBar.SetActive(true);
    }

    /// <summary>
    /// Causes players to take damage from enemy attacks
    /// </summary>
    /// <param name="damage"></param>
    public void Attacked(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;

            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
        }
    }
}
