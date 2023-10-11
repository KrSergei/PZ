using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;
using System.ComponentModel;
using static UnityEditor.Progress;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject slotPrefab;
    public List<GameObject> createdSlots = new();
    public int x_Space_Beetwen_Items;
    public int number_of_column;
    [SerializeField]
    private Dictionary<InvemtorySlot, GameObject> _itemDisplayed = new();
    [SerializeField]
    private List<InventoryObject> itemDisplayed = new();


    private void Start()
    {
        CreateDisplay();        
    }

    /// <summary>
    /// Стартовое создание инвентаря
    /// </summary>
    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.GetInventoryCapacity(); i++)
        {
            GameObject item = Instantiate(slotPrefab, Vector2.zero, Quaternion.identity, transform);
            item.GetComponent<ButtonDelete>().indexButton = i;
            item.transform.localPosition = GetPosition(i);
            if (i < inventory.container.Count)
            {
                //отрисовка иконки предмета в слоте
                item.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
                //вывод коичества предметов в слоте
                if (AmountItem(inventory.container[i].amount))
                    //вывод коичества предметов в слоте
                    item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                else
                    item.GetComponentInChildren<TextMeshProUGUI>().text = "";
                Debug.Log("Current amount = " + inventory.container[i].amount);
                //item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                //добавление предмета в инвентарь
                //_itemDisplayed.Add(inventory.container[i], item);

            }
            createdSlots.Add(item);
        }   
    }
    
    /// <summary>
    /// указание позиции размещения слота инвентаря
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private Vector3 GetPosition(int i)
    {
        return new Vector3(x_Space_Beetwen_Items * (i % number_of_column), 0f, 0f);
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
            //Debug.Log("Get sprite prefab of " + item.item.prefab.name);
            return item.item.prefab.GetComponent<SpriteRenderer>().sprite;
        }
        catch (Exception)
        {
            //Debug.Log("Not have sprite " + item.item.prefab.name);
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

    /// <summary>
    /// Обновление инвентаря при подборе предмета
    /// </summary>
    public void UpdateInventory(int index, bool newItem)
    {
        try
        {
            if (newItem)
            {
                //отрисовка иконки предмета в слоте
                inventory.container[index].item.GetComponent<Image>().sprite = GetIconItem(inventory.container[index]);
                //вывод количества предметов в слоте
                if (AmountItem(inventory.container[index].amount))
                    //вывод коичества предметов в слоте
                    inventory.container[index].item.GetComponentInChildren<TextMeshProUGUI>().text =
                                                    inventory.container[index].amount.ToString("n0");
                else
                    inventory.container[index].item.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
            else 
            {
                //вывод количества предметов в слоте
                if (AmountItem(inventory.container[index].amount))
                    //вывод коичества предметов в слоте
                    inventory.container[index].item.GetComponentInChildren<TextMeshProUGUI>().text =
                                                    inventory.container[index].amount.ToString("n0");
                else
                    inventory.container[index].item.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }

        //Debug.Log(hasItem);
        //if (createdSlots.Count >= inventory.GetInventoryCapacity()) return;

        //if (!itemDisplayed.Contains(item))                
        //    itemDisplayed.Add(item);
        //for (int i = 0; i < createdSlots.Count; i++)
        //{

        //    //отрисовка иконки предмета в слоте
        //    item.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
        //    //вывод коичества предметов в слоте
        //    if (AmountItem(inventory.container[i].amount))
        //        //вывод коичества предметов в слоте
        //        item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
        //    else
        //        item.GetComponentInChildren<TextMeshProUGUI>().text = "";
        //    Debug.Log("Current amount = " + inventory.container[i].amount);

        //}

        //for (int i = 0; i < inventory.container.Count; i++)
        //{            

        //    if (createdSlots[i] != inventory.container[i].item)
        //    {
        //        Debug.Log("Add item - " + createdSlots[i].name);
        //        //отрисовка иконки предмета в слоте
        //        //createdSlots[i].GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
        //        createdSlots[i].GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
        //        //Проверка на количество, если 2 и более, то изменение количества, иначе пустая строка.
        //        if (AmountItem(inventory.container[i].amount))
        //            //вывод коичества предметов в слоте
        //            createdSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
        //        else
        //            createdSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";

        //        //добавление предмета в инвентарь
        //        //itemDisplayed.Add(item);
        //    }
        //    else
        //    {
        //        Debug.Log("Change amount");
        //        //Проверка на количество, если 2 и более, то изменение количества, иначе пустая строка.
        //        if (AmountItem(inventory.container[i].amount))
        //            createdSlots[i].GetComponentInChildren<TextMeshProUGUI>().text =
        //            inventory.container[i].amount.ToString("n0");
        //        else
        //            createdSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        //    }
        //}


        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (i >= inventory.GetInventoryCapacity()) return;

            //if (!itemDisplayed.Contains(item))
            //    itemDisplayed.Add(item);
            //else
            //    Debug.Log("Already has " + item);

            #region v1
            //if (_itemDisplayed.ContainsKey(inventory.container[i]))
            //{
            //    //Проверка на количество, если 2 и более, то изменение количества, иначе пустая строка.
            //    if (AmountItem(inventory.container[i].amount))
            //        _itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text =
            //        inventory.container[i].amount.ToString("n0");
            //    else
            //        _itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = "";

            //}
            //else
            //{
            //    GameObject item = createdSlots[i];
            //    //отрисовка иконки предмета в слоте
            //    item.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
            //    //Проверка на количество, если 2 и более, то изменение количества, иначе пустая строка.
            //    if (AmountItem(inventory.container[i].amount))
            //        //вывод коичества предметов в слоте
            //        item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            //    else
            //        item.GetComponentInChildren<TextMeshProUGUI>().text = "";
            //    //добавление предмета в инвентарь
            //    _itemDisplayed.Add(inventory.container[i], item);

            //}
            #endregion

            #region v2

            //if (!itemDisplayed.ContainsKey(inventory.container[i]) || inventory.container[i] == null) 
            //if (itemDisplayed[i] != inventory.container[i])
            //    itemDisplayed.Add(inventory.container[i]);
            //else
            //    Debug.Log("Already has " + inventory.container[i]);

            //if (itemDisplayed[i] == inventory.container[i])
            //{
            //    //Проверка на количество, если 2 и более, то изменение количества, иначе пустая строка.
            //    if (AmountItem(inventory.container[i].amount))
            //        itemDisplayed[i].GetComponentInChildren<TextMeshProUGUI>().text =
            //        inventory.container[i].amount.ToString("n0");
            //    else
            //    {
            //        itemDisplayed[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            //    }
            //}
            //else
            //{
            //    GameObject item = createdSlots[i];
            //    //отрисовка иконки предмета в слоте
            //    item.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
            //    //Проверка на количество, если 2 и более, то изменение количества, иначе пустая строка.
            //    if (AmountItem(inventory.container[i].amount))
            //        //вывод коичества предметов в слоте
            //        item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            //    else
            //        item.GetComponentInChildren<TextMeshProUGUI>().text = "";
            //    //добавление предмета в инвентарь
            //    itemDisplayed.Add(inventory.container[i]);
            //}
            #endregion

        }
    }

    public void ChangeAmountItem(int indexSlot)
    {
        //проверка количества патронов, если больше 1, то устанавливается значение текущего количества, иначе пустая строка
        string currentAmount = (AmountItem(inventory.container[indexSlot].amount))
            ? inventory.container[indexSlot].amount.ToString("n0") : "";
        createdSlots[indexSlot].GetComponent<ButtonDelete>().textCount.text = currentAmount;
    }

    /// <summary>
    /// Сброс иконки и количества при удалении предмета из инвентаря
    /// </summary>
    /// <param name="indexSlot"></param>
    public void RemoveItem(int indexSlot)
    {
        createdSlots[indexSlot].GetComponent<Image>().sprite = slotPrefab.GetComponent<Image>().sprite;
        createdSlots[indexSlot].GetComponent<ButtonDelete>().textCount.text = ""; 
    }
}
