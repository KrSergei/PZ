using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public CapsuleCollider2D _collider;
    public float damage;

    void Start()
    {
        _collider=  GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collaider)
    {
        if (collaider != null)
        {
            if (collaider.TryGetComponent<PlayerCollision>(out var player))
            {
                player.TakeDamage(damage);
            }
        }
    }
}
