using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collaider)
    {
        if (collaider.gameObject.TryGetComponent<Item>(out var item))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    collaider.transform.position = inventory.slots[i].transform.position;
                    inventory.AddItem(inventory.slots[i]);
                    break;
                }
            }
        }
    }
}
