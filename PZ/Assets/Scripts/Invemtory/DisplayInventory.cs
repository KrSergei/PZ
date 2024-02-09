using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Reflection;
using Unity.VisualScripting;

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
    [SerializeField] private Sprite _emptyInventoryCell;


    private void Start()
    {        
        GetInventorySlots();
    }

    /// <summary>
    /// Получение списка слотов инвентаря
    /// </summary>
    private void GetInventorySlots()
    {
        foreach (Transform child in transform)
        {
            slotHandlers.Add(child.gameObject.GetComponent<InventorySlotHandler>());    
        }
        SetSlotIndex();
        FillingSlots();
    }

    /// <summary>
    /// Установка индекса для кнопки "Delete" интерфейса инвентаря
    /// </summary>
    private void SetSlotIndex()
    {
        for (int i = 0; i < slotHandlers.Count; i++)
        {
            slotHandlers[i].gameObject.GetComponent<ButtonDelete>().indexButton = i;
        }
    }

    /// <summary>
    /// Заполнение UI инвентаря
    /// </summary>
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
    /// Возврат true если количества претметов больше 1 
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    private bool AmountItem(int amount)
    {
       return amount > 1;
    }

    /// <summary>
    /// Обновление ячейки инвентаря при подборе предмета
    /// </summary>
    /// <param name="index"></param>
    /// <param name="itemIcon"></param>
    /// <param name="totalCount"></param>
    public void UpdateInventoryUI(int index, Sprite itemIcon, int totalCount)
    {
        //amount item
        if (AmountItem(totalCount))
            slotHandlers[index].GetTextCount().text = totalCount.ToString();
        else
            slotHandlers[index].GetTextCount().text = " ";

        slotHandlers[index].ActivateIconInSlot(itemIcon);
    }
    /// <summary>
    /// Обновление текста количества предмета при использовании(стрельба, применение предмета)
    /// </summary>
    /// <param name="index"></param>
    /// <param name="totalCount"></param>
    public void UpdateTextInventoryUI(int index, int totalCount)
    {
        if (AmountItem(totalCount))
            slotHandlers[index].GetTextCount().text = totalCount.ToString();
        else
            slotHandlers[index].GetTextCount().text = " ";
    }

    /// <summary>
    /// Сброс иконки и количества при удалении предмета из инвентаря
    /// </summary>
    /// <param name="indexSlot"></param>
    public void RemoveItem(int indexSlot)
    {
        //createdSlots[indexSlot].GetComponent<Image>().sprite = null;
        //createdSlots[indexSlot].GetComponent<SpriteRenderer>().sprite = _emptyinventoryCell;
        //createdSlots[indexSlot].GetComponent<ButtonDelete>().textCount.text = "";
        slotHandlers[indexSlot].GetTextCount().text = "";
        slotHandlers[indexSlot].DeactivateIconInSlot();
    }
}
