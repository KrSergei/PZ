using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private EvenGameObj onCollisionPlayer;
    [SerializeField] private EvenFloat onTakeDamage;

    
    private void OnTriggerEnter2D(Collider2D collaider)
    {
        onCollisionPlayer.Invoke(collaider.gameObject);
    }

    public void TakeDamage(float damage)
    {
        onTakeDamage?.Invoke(damage);
    }
}

[System.Serializable]
public class EvenGameObj : UnityEvent<GameObject> { }
[System.Serializable]
public class EvenFloat : UnityEvent<float> { }

