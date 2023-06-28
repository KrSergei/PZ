using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            if (collider.TryGetComponent<Monster>(out var monster))
            {
                Debug.Log("Monster collider");
            }
        }
    }
}
