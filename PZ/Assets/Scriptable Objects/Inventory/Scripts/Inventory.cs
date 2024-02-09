using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent<int, int> onDoesShoot;
    [SerializeField] private EvenInt onAmmoOver;
    [SerializeField] private UnityEvent<int, Sprite, int> onItemTaken;
    [Header("Inventory Fields")]
    public InventoryObject inventory;
    public AmmoObject ammoItem;

    /// <summary>
    /// Добавление предмета в инвентарь. Метод вызывается через UnityEvent в скрипте PlayerCollision
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(GameObject item)
    {
        var _item = item.GetComponent<Item>();
        if (_item)
        {
            inventory.AddItem(_item.item, out int index, out int totalAmount);
            onItemTaken?.Invoke(index, _item.item.itemIcon, totalAmount);
            //ToDo return to pool
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
                        //вычитание патронов
                        inventory.container[i].SubstractionAmount(1);
                        //изменение значения в UI
                        onDoesShoot?.Invoke(i, inventory.container[i].amount);
                        //проверка количества патронов
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
        //удаление предмета из инвентаря, если его количество равно 0
        if (inventory.container[indexSlot].amount <= 0)
        {
            inventory.RemoveItem(indexSlot);
            onAmmoOver?.Invoke(indexSlot);
        } 
    }
}
[Serializable]
public class EvenInt : UnityEvent<int> { }
