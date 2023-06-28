using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            if (collider.TryGetComponent<Monster>(out var monster))
            {
                monster.TakeDamage(damage);
            }
        }
    }
}
