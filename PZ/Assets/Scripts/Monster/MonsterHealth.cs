using UnityEngine;
using UnityEngine.Events;

public class MonsterHealth : MonoBehaviour
{
    public UnityEvent onHealthOver;
    
    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) 
        {
            onHealthOver?.Invoke();
            //toDo return to pool
            gameObject.SetActive(false);
        }
    }
}
