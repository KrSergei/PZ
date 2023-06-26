using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int slotsCount;
    public GameObject slotPrefab;

    public int x_Space_Beetwen_Items;
    public int number_of_column;

    void Start()
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
            GameObject slot = Instantiate(slotPrefab, Vector2.zero, Quaternion.identity, transform);
            slot.transform.localPosition = GetPosition(i);
                if(i < inventory.container.Count)
            {
                //отрисовка иконки предмета в слоте
                slot.gameObject.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
                //вывод коичества предметов в слоте
                slot.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            }
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
}
