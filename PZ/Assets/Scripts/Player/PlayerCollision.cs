using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{

    public DisplayInventory displayInventory;
    
    [Header("Events")]
    [SerializeField] private EventGameObj onCollisionPlayer;
    [SerializeField] private EventFloat onTakeDamage;


    private void OnTriggerEnter2D(Collider2D collaider)
    {
        onCollisionPlayer?.Invoke(collaider.gameObject);
        //displayInventory.UpdateInventory(collaider.gameObject);
    }

    public void TakeDamage(float damage)
    {
        onTakeDamage?.Invoke(damage);
    }
}

[System.Serializable]
public class EventGameObj : UnityEvent<GameObject> { }
[System.Serializable]
public class EventFloat : UnityEvent<float> { }

