using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InvemtorySlot> container = new List<InvemtorySlot>();
    public void AddItem(ItemObject item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == item) 
            {
                container[i].AddAmount(amount);
                hasItem = true;
                break; 
            }
        }
        if(!hasItem) container.Add(new InvemtorySlot(item ,amount));
    }

    //public GameObject GetPrefab(InvemtorySlot item) 
    //{
    //    //return GetCurrentPrefab(item);
    //}
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
    public void AddAmount(int value) => amount += value;
    public void SubstractionAmount(int value = 1) => amount -= value;
    public GameObject GetCurrentPrefab(InvemtorySlot item) => item.item.prefab;
}