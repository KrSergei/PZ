using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;

    [SerializeField] private float health, maxHealth;
    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.MaxHealth = health;
    }

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
