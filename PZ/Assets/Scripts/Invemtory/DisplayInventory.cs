using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using JetBrains.Annotations;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int slotsCount;
    public GameObject slotPrefab;
    public List<GameObject> createdSlots = new List<GameObject>();
    public int x_Space_Beetwen_Items;
    public int number_of_column;

    private Dictionary<InvemtorySlot, GameObject> itemDisplayed = new Dictionary<InvemtorySlot, GameObject>();

    private void Start()
    {
        CreateDisplay();
    }

    /// <summary>
    /// Стартовое создание инвентаря
    /// </summary>
    private void CreateDisplay()
    {
        for (int i = 0; i < slotsCount; i++)
        {
            GameObject item = Instantiate(slotPrefab, Vector2.zero, Quaternion.identity, transform);
            item.GetComponent<ButtonDelete>().indexButton = i;
            item.transform.localPosition = GetPosition(i);
            if (i < inventory.container.Count)
            {
                //отрисовка иконки предмета в слоте
                item.gameObject.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
                //вывод коичества предметов в слоте
                item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                //добавление предмета в инвентарь
                itemDisplayed.Add(inventory.container[i], item);
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
        return item.item.prefab.GetComponent<SpriteRenderer>().sprite; 
    }

    /// <summary>
    /// Возврат true если количества претметов больше 1 
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    private bool AmountItem(int amount)
    {
       return amount > 1 ? true : false;
    }

    /// <summary>
    /// Обновление инвентаря при подборе предмета
    /// </summary>
    public void UpdateInventory()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (i == slotsCount) break;

            if (itemDisplayed.ContainsKey(inventory.container[i]))
            {   
                //Проверка на количество, если 2 и более, то изменение количества, иначе пустая строка.
                if (AmountItem(inventory.container[i].amount))
                    itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                    inventory.container[i].amount.ToString("n0");
                else
                    itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
            else
            {
                GameObject item = createdSlots[i];
                //отрисовка иконки предмета в слоте
                item.gameObject.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
                //Проверка на количество, если 2 и более, то изменение количества, иначе пустая строка.
                if (AmountItem(inventory.container[i].amount))
                    //вывод коичества предметов в слоте
                    item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                else
                    item.GetComponentInChildren<TextMeshProUGUI>().text = "";
                //добавление предмета в инвентарь
                itemDisplayed.Add(inventory.container[i], item);
            }
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
    }
}
