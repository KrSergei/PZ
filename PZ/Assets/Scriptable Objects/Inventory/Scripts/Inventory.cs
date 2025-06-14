using UnityEngine;
using UnityEngine.Events;
using System;

public class Inventory : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent<int, int> onDoesShoot;
    [SerializeField] private EvenInt onAmmoOver;
    [SerializeField] private UnityEvent<int, Sprite, int> onItemTaken;
    [Header("Inventory Fields")]
    public InventoryObject inventory;
    public AmmoObject ammoItem;

    private void Start()
    {
        inventory.InitInventory();
    }

    /// <summary>
    /// ���������� �������� � ���������. ����� ���������� ����� UnityEvent � ������� PlayerCollision
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(GameObject item)
    {
        var _item = item.GetComponent<Item>();
        if (_item)
        {
            inventory.AddItem(_item.item, out int index, out int totalAmount);
            onItemTaken?.Invoke(index, _item.item.itemIcon, totalAmount);
            item.SetActive(false);
        }
    }
    public bool CanShoot()
    {
        bool value = false;
        for (int i = 0; i < inventory.container.Count; i++)
        {
            try
            {
                if (inventory.container[i].item.Equals(ammoItem))
                {
                    if (inventory.container[i].amount > 0)
                    {
                        //��������� ��������
                        inventory.container[i].SubstractionAmount(1);
                        //��������� �������� � UI
                        onDoesShoot?.Invoke(i, inventory.container[i].amount);
                        //�������� ���������� ��������
                        CheckAmountItem(i);
                        value = true;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                value = false;
            }
        }
        return value;
    }

    public void AddItemToInventory(GameObject item)
    {
        var _item = item.GetComponent<Item>();
    }

    private void CheckAmountItem(int indexSlot)
    {
        //�������� �������� �� ���������, ���� ��� ���������� ����� 0
        if (inventory.container[indexSlot].amount <= 0)
        {
            inventory.RemoveItem(indexSlot);
            onAmmoOver?.Invoke(indexSlot);
        } 
    }
}

[Serializable]
public class EvenInt : UnityEvent<int> { }
