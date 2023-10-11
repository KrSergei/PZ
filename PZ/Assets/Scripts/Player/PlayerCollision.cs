using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public DisplayInventory displayInventory;
    public Inventory inventory;
    [Header("Events")]
    [SerializeField] private EventGameObj onCollisionPlayer;
    [SerializeField] private EventFloat onTakeDamage;


    private void OnTriggerEnter2D(Collider2D collaider)
    {
        //onCollisionPlayer?.Invoke(collaider.gameObject);
        if(collaider.gameObject.layer == LayerMask.NameToLayer("Collectible"))
        {
            inventory.AddItem(collaider.gameObject);
            //displayInventory.UpdateInventory(inventory.inventory.GetUpdatedSlotIndex(), inventory.inventory.IsNewItem());
        }
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

