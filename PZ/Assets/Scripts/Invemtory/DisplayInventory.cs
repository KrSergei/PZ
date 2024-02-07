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
        //CreateDisplay();
        GetInventorySlots();
    }

    /// <summary>
    /// ��������� �������� ���������
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
                //��������� ������ �������� � �����
                item.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
                //����� ���������� ��������� � �����
                item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                //���������� �������� � ���������
                itemDisplayed.Add(inventory.container[i], item);
            }
            createdSlots.Add(item);
        }   
    }

    private void GetInventorySlots()
    {
        foreach (Transform child in transform)
        {
            //createdSlots.Add(child.gameObject);
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
                slotHandlers[i].GetTextCount().text = inventory.container[i].amount.ToString();
                slotHandlers[i].ActivateIconInSlot(inventory.container[i].item.itemIcon);
            }
        }
    }

    
    /// <summary>
    /// �������� ������� ���������� ����� ���������
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private Vector3 GetPosition(int i)
    {
        return new Vector3(x_Space_Beetwen_Items * (i % number_of_column), 0f, 0f);
    }

    /// <summary>
    /// ������� ������ ��������
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
    /// ������� true ���� ���������� ��������� ������ 1 
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
    /// ���������� ��������� ��� ������� ��������
    /// </summary>
    public void UpdateInventory()
    {
        #region Old 
        //    try
        //    {
        //        for (int i = 0; i < inventory.container.Count; i++)
        //        {                

        //            if (i >= inventory.GetInventoryCapacity()) return;

        //            if (itemDisplayed.ContainsKey(inventory.container[i]))
        //            {
        //                //�������� �� ����������, ���� 2 � �����, �� ��������� ����������, ����� ������ ������.
        //                if (AmountItem(inventory.container[i].amount))
        //                    itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text =
        //                    inventory.container[i].amount.ToString("n0");
        //                else
        //                    itemDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = "";

        //            }
        //            else
        //            {
        //                GameObject item = createdSlots[i];
        //                //��������� ������ �������� � �����
        //                item.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
        //                //�������� �� ����������, ���� 2 � �����, �� ��������� ����������, ����� ������ ������.
        //                if (AmountItem(inventory.container[i].amount))
        //                    //����� ��������� ��������� � �����
        //                    item.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
        //                else
        //                    item.GetComponentInChildren<TextMeshProUGUI>().text = "";
        //                //���������� �������� � ���������
        //                itemDisplayed.Add(inventory.container[i], item);
        //                _addedItems.Add(item);
        //            }
        //        }
        //}
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        return;
        //    }
        #endregion

    }

    public void ChangeAmountItem(int indexSlot)
    {
        //�������� ���������� ��������, ���� ������ 1, �� ��������������� �������� �������� ����������, ����� ������ ������
        string currentAmount = (AmountItem(inventory.container[indexSlot].amount))
            ? inventory.container[indexSlot].amount.ToString("n0") : "";
        createdSlots[indexSlot].GetComponent<ButtonDelete>().textCount.text = currentAmount;
    }

    /// <summary>
    /// ����� ������ � ���������� ��� �������� �������� �� ���������
    /// </summary>
    /// <param name="indexSlot"></param>
    public void RemoveItem(int indexSlot)
    {
        //createdSlots[indexSlot].GetComponent<Image>().sprite = null;
        createdSlots[indexSlot].GetComponent<SpriteRenderer>().sprite = _emptyinventoryCell;
        createdSlots[indexSlot].GetComponent<ButtonDelete>().textCount.text = "";
    }
}
