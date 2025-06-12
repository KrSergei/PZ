using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MonsterHealth : MonoBehaviour
{
    public UnityEvent onHealthOver;
    public HealthBar healthBar;
    [SerializeField] private float health, maxHealth;

    [SerializeField] private MonsterDropItem _drop;

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
        _drop = GetComponent<MonsterDropItem>();
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (Health <= 0) 
        {
            onHealthOver?.Invoke();
            _drop.DropItem();
            gameObject.SetActive(false);
        }
    }
}
