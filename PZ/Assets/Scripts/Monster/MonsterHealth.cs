using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) 
        {  
            //toDo return to pool
            gameObject.SetActive(false);
        }
    }
}
