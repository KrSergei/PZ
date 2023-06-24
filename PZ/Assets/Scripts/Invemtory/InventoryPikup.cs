using UnityEngine;

public class InventoryPikup : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collaider)        
    {
        if (collaider.TryGetComponent<PlayerCollision>(out var item))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    gameObject.transform.position = inventory.slots[i].transform.position;
                    break;
                }
            }
        }
    }
}
