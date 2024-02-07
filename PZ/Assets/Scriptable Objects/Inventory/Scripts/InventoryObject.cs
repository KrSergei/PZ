using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public int inventoryÑapcity;
    public List<InvemtorySlot> container = new();

    public void AddItem(ItemObject item, out int index, out int totalAmountItem, int amount = 1)
    {
        bool hasItem = false;
        index = 0;
        totalAmountItem = amount;
        try
        {
            if (hasItem == false)
            {
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].item == item)
                    {
                        hasItem = true;
                        container[i].AddAmount(amount);
                        index = i;
                        totalAmountItem = container[i].amount;
                    }
                    else
                    {
                        if (container[i].item == null)
                        {
                            hasItem = true;
                            container[i] = new InvemtorySlot(item, amount);
                            index = i;
                            totalAmountItem = amount;
                        }
                    }
                }
            }
        }
        catch (NullReferenceException)
        {
           
        }
        if (!hasItem && container.Count < inventoryÑapcity)
        {
            container.Add(new InvemtorySlot(item, amount));
            index = container.Count - 1;
            totalAmountItem = amount;
        }
    }

    /// <summary>
    /// Óäàëåíèå èç èíâåíòàğÿ ïğåäìåòà 
    /// </summary>
    /// <param name="indexSlot"></param>
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

    public int GetCurrentIndexItem()
    {

        return 0;
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