using UnityEngine;
using UnityEngine.Events;
using System;

public class Inventory : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private EvenInt onDoesShoot;
    [SerializeField] private EvenInt onAmmoOver;

    [Header("Inventory Fields")]
    public InventoryObject inventory;
    public AmmoObject ammoItem;

    public void AddItem(GameObject item)
    {
        var _item = item.GetComponent<Item>();
        if (_item)
        {
            inventory.AddItem(_item.item, 1);
            //ToDo back to objectpool
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
                        onDoesShoot?.Invoke(i);
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

    private void CheckAmountItem(int indexSlot)
    {
        //удаление предмета из инвентаря, если его количество равно 0
        if (inventory.container[indexSlot].amount <= 0)
        {
            inventory.RemoveItem(indexSlot);
            onAmmoOver?.Invoke(indexSlot);
        } 
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
[Serializable]
public class EvenInt : UnityEvent<int> { }
