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

    public void RemoveItem(int indexSlot)
    {
        Debug.Log("Delete item in slot " + indexSlot);
        inventory.RemoveItem(indexSlot);
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
