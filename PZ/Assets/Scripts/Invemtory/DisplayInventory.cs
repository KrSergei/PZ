using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Reflection;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject slotPrefab;
    public List<GameObject> createdSlots = new();
    public List<InventorySlotHandler> slotHandlers = new();

    public int x_Space_Beetwen_Items;
    public int number_of_column;
    [SerializeField]
    private Dictionary<InvemtorySlot, GameObject> itemDisplayed = new();
    [SerializeField] private Sprite _emptyinventoryCell;


    private void Start()
    {        
        GetInventorySlots();
    }

    private void GetInventorySlots()
    {
        foreach (Transform child in transform)
        {
            slotHandlers.Add(child.gameObject.GetComponent<InventorySlotHandler>());
        }
        FillingSlots();
    }
    private void FillingSlots()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (inventory.container[i].item != null)
            {
                if (AmountItem(inventory.container[i].amount))
                    slotHandlers[i].GetTextCount().text = inventory.container[i].amount.ToString();
                slotHandlers[i].ActivateIconInSlot(inventory.container[i].item.itemIcon);
            }
        }
    }

    /// <summary>
    /// Возврат иконки предмета
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private Sprite GetIconItem(InvemtorySlot item)
    {
        try
        {
            //return item.item.prefab.GetComponent<SpriteRenderer>().sprite;
            return item.item.itemIcon;

        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Возврат true если количества претметов больше 1 
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    private bool AmountItem(int amount)
    {
       return amount > 1;
    }

    public void UpdateInventoryUI(int index, Sprite itemIcon, int totalCount)
    {
        //amount item
        if (AmountItem(totalCount))
            slotHandlers[index].GetTextCount().text = totalCount.ToString();
        else
            slotHandlers[index].GetTextCount().text = " ";

        //slotHandlers[index].DeactivateIconInSlot();
        slotHandlers[index].ActivateIconInSlot(itemIcon);
    }

    /// <summary>
    /// Сброс иконки и количества при удалении предмета из инвентаря
    /// </summary>
    /// <param name="indexSlot"></param>
    public void RemoveItem(int indexSlot)
    {
        //createdSlots[indexSlot].GetComponent<Image>().sprite = null;
        createdSlots[indexSlot].GetComponent<SpriteRenderer>().sprite = _emptyinventoryCell;
        createdSlots[indexSlot].GetComponent<ButtonDelete>().textCount.text = "";
    }
}
