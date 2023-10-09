using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public int inventoryÑapcity;
    public List<InvemtorySlot> container = new List<InvemtorySlot>();
    public void AddItem(ItemObject item, int amount = 1)
    {  
        bool hasItem = container.Exists(x => x.item == item);
        if (hasItem)
        {
            for (int i = 0; i < container.Count; i++)
            {
                if (i == inventoryÑapcity - 1) return;
                try
                {
                    if (container[i].item == item)
                    {
                        container[i].AddAmount(amount);
                        hasItem = true;
                        return;
                    }
                }
                catch (NullReferenceException)
                {
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i < container.Count; i++)
            {
                if (i == inventoryÑapcity - 1) return;
                try
                {
                    if (container[i].item == null)
                    {
                        container[i] = new InvemtorySlot(item, amount);
                        hasItem = true;
                        return;
                    }
                }
                catch (NullReferenceException)
                {
                    return;
                }
            }
        }
        if (!hasItem) container.Add(new InvemtorySlot(item, amount));  
    }


    public void RemoveItem(int indexSlot) 
    {
        if (container.Count == 0 || indexSlot > container.Count) return; 

        if (container[indexSlot].item != null)
        {
            container[indexSlot] = null;
        }
        else return;
    }

    public int GetInventoryCapacity()
    {
        return inventoryÑapcity;
    }
}

[System.Serializable]
public class InvemtorySlot
{
    public ItemObject item;
    public int amount;
    public InvemtorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
    public void AddAmount(int value) {

        amount += value;
    } 
    public void SubstractionAmount(int value) => amount -= value;
    public GameObject GetCurrentPrefab(InvemtorySlot item) => item.item.prefab;
}