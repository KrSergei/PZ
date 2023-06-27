using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryObject inventory;

    public void AddItem(GameObject item)
    {
        var _item = item.GetComponent<Item>();
        if (_item)
        {
            inventory.AddItem(_item.item, 1);
            //ToDo back to objectpool
            item.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
