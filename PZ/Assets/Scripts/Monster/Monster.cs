using UnityEngine;

public class Monster : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        GetComponent<MonsterHealth>().TakeDamage(damage);
    }
}
