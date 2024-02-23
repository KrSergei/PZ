using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public int inventoryСapacity;
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
                //Поиск в инвентаре совпадающей ячейки, если есть, то увеличение количества элементов в ячейке
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].item == item)
                    {
                        container[i].AddAmount(amount);
                        index = i;
                        totalAmountItem = container[i].amount;
                        hasItem = true;
                        return;
                    }
                }
            }
            if (hasItem == false)
            {
                //Поиск пустой ячейки и ее заполнение элементом item
                for (int i = 0; i < container.Count; i++)
                {
                    if (container[i].item == null)
                    {
                        container[i] = new InvemtorySlot(item, amount);
                        index = i;
                        totalAmountItem = amount;
                        hasItem = true;
                        return;
                    }
                }
            }
        }
        catch (NullReferenceException) { }
        //Если нет нужного элемента и количество элементов меньше вместимости инвентаря, то добавляется новая ячейка инвентаря
        //Возвращается индекс добавленной ячейки иколичество элементов в ячейке
        if (!hasItem && container.Count < inventoryСapacity)
        {
            container.Add(new InvemtorySlot(item, amount));
            index = container.Count - 1;
            totalAmountItem = amount;
        }
    }


    /// <summary>
    /// Удаление из инвентаря предмета 
    /// </summary>
    /// <param name="indexSlot"></param>
    public void RemoveItem(int indexSlot) 
    {
        if (container.Count == 0 || indexSlot > container.Count) return; 

        if (container[indexSlot].item != null)
        {           
            container[indexSlot].amount = 0;
            container[indexSlot] = null;
        }
        else return;
    }
    public int GetInventoryCapacity()
    {
        return inventoryСapacity;
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