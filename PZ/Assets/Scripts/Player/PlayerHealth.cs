using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent onHealthOver;
    public HealthBar healthBar;

    [SerializeField] private float health, maxHealth;

    public float Health { get => health; set => health = value; }
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
    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (Health <= 0)
        {
            onHealthOver?.Invoke();
            gameObject.SetActive(false);
        }
    }


}
