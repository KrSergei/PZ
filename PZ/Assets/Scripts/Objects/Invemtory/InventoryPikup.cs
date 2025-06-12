using UnityEngine;

public class InventoryPikup : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>().GetComponent<Inventory>();
    }
}
