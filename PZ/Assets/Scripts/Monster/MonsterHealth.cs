using UnityEngine;
using UnityEngine.Events;

public class MonsterHealth : MonoBehaviour
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
    public void TakeDamage(float damage)
    {
        Health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (Health <= 0) 
        {
            onHealthOver?.Invoke();
            //toDo return to pool
            gameObject.SetActive(false);
        }
    }
}
