using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

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
    private List<GameObject> itemDisplayed = new();


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
                item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                //добавление предмета в инвентарь
                //_itemDisplayed.Add(inventory.container[i], item);
                //itemDisplayed.Add(inventory.container[i]);
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
            return item.item.prefab.GetComponent<SpriteRenderer>().sprite;
        }
        catch (Exception)
        {
            Debug.Log("Not have sprite");
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
    public void UpdateInventory()
    {
        try
        {
            //if (!itemDisplayed.Contains(item))
            //    itemDisplayed.Add(item);
            //else
            //    Debug.Log("Already has " + item);

            for (int i = 0; i < inventory.container.Count; i++)
            {

                if (i >= inventory.GetInventoryCapacity()) return;

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
        catch (ArgumentOutOfRangeException)
        {
            return;
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
        createdSlots[indexSlot].GetComponent<Image>().sprite = null;
        createdSlots[indexSlot].GetComponent<ButtonDelete>().textCount.text = "";
        //_addedItems[indexSlot] = null;
    }
}
