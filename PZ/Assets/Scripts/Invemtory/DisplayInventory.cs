using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

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

    public void UpdateInventory()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (i == slotsCount) break;

            if (itemDisplayed.ContainsKey(inventory.container[i]))
            {
                itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text =
                inventory.container[i].amount.ToString("n0");
            }
            else
            {
                GameObject item = createdSlots[i];
                //отрисовка иконки предмета в слоте
                item.gameObject.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
                //вывод коичества предметов в слоте
                item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                //добавление предмета в инвентарь
                itemDisplayed.Add(inventory.container[i], item);
            }
        }
    }

    public void RemoveItem()
    {

    }
}
