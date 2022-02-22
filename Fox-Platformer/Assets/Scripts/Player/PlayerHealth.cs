using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Variables")]
    public int maxHealth;
    private int currentHealth;

    public HealthBarScript healthBarScript;

	private void Awake()
	{
		currentHealth = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);
	}

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) Die();
        UpdateUI();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBarScript.SetHealth(currentHealth);
    }

    private void Die()
    {
        //Start death animation (if we make one)
        //End game
        FindObjectOfType<AudioManager>().Play("Death");
        SceneManager.LoadScene(2);
    }
    
}
