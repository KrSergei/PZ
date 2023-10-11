using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public int inventory—apcity;
    public List<InvemtorySlot> container = new();
    [SerializeField]
    private int _updatedSlotIndex;
    [SerializeField]
    private bool _isNewItem;

    public void AddItem(ItemObject item, int amount = 1)
    {
        bool hasItem = false;
        try
        {           
            hasItem = container.Exists(x => x.item == item);
            if (hasItem)
            {
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].item == item)
                    {
                        _updatedSlotIndex = i;
                        _isNewItem = false;
                        container[i].AddAmount(amount);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].item == null)
                    {
                        _updatedSlotIndex = i;
                        _isNewItem = true;
                        container[i] = new InvemtorySlot(item, amount);
                        return;
                    }
                }
            }
        }
        catch (NullReferenceException)
        {
            return;
        }
        if (!hasItem && container.Count < inventory—apcity) container.Add(new InvemtorySlot(item, amount));  
    }

    public int GetUpdatedSlotIndex()
    {
        return _updatedSlotIndex;
    }

    public bool IsNewItem()
    {
        return _isNewItem;
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
        return inventory—apcity;
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