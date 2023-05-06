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

public class BradHealthBehaviour : MonoBehaviour
{
    //The players healthbar
    [SerializeField] private Image health;
    [SerializeField] private GameObject healthBar;

    float currentHealth, maxHealth = 100;

    /// <summary>
    /// Makes sure the current health starts at the max health
    /// Makes sure health bar doesn't appear until game starts
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetActive(false);
    }

    /// <summary>
    /// Makes sure current health doesn't exceed max health, also makes surethe health changes
    /// </summary>
    void Update()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        DisplayHealth();
    }

    /// <summary>
    /// Displays how much health
    /// </summary>
    private void DisplayHealth()
    {
        //Visual display of health
        //Lerp can only use values between 0 and 1
        health.fillAmount = Mathf.Lerp(health.fillAmount,
            (currentHealth / maxHealth), 3 * Time.deltaTime);

        Color healthColor = Color.Lerp(Color.red, Color.green, 
            (currentHealth / maxHealth));
        health.color = healthColor;
    }

    /// <summary>
    /// Makes it so the health bar is visible once the game starts
    /// </summary>
    public void EnableHealth()
    {
        healthBar.SetActive(true);
    }
}
