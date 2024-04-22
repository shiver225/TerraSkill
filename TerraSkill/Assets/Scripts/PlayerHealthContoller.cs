using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthContoller : MonoBehaviour
{
    public float maxHealth = 100f;
    public float regenerationRate = 5f; // Health regenerated per second

    public float currentHealth;

    [SerializeField] PlayerHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponent<MainPlayerController>().inventoryPanel.gameObject.transform.parent.GetComponentInChildren<PlayerHealthBar>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    void Update()
    {
        // Regenerate health over time
        if (currentHealth < maxHealth)
        {
            currentHealth += regenerationRate * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        // Check if the object has died
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform any death-related actions here
        Debug.Log("You died!");
        //Destroy(gameObject);
    }
}