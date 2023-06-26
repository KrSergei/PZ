using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public InventoryObject inventory;

    public void AddItem(GameObject item)
    {
        var _item = item.GetComponent<Item>();
        if(_item)
        {
            inventory.AddItem(_item.item, 1);
            //ToDo back to objectpool
            item.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
    #region old method
    //public bool[] isFull;
    //public GameObject[] slots;
    //public Dictionary<int, GameObject> inventory =  new Dictionary<int, GameObject>();

    //public List<GameObject> invent = new List<GameObject>();

    //[SerializeField] private TextMeshProUGUI _textCount;
    //[SerializeField] private int _countItemInSlot;

    ///// <summary>
    ///// Отображение количества вещей в слоте инветнаря
    ///// </summary>
    ///// <param name="item"></param>
    //private void ChangeCountItemInUI(GameObject item)
    //{
    //    //Получение компонента текущего слота инвентаря
    //    _textCount = item.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    //    //Если слот пустой, то инкремент количества предметов в слоте
    //    if(_textCount.text.Equals(""))
    //    {
    //        _countItemInSlot++;
    //    }
    //    //если слот не пустой, то инкремент текущего количества  в слоте 
    //    else
    //    {
    //        _countItemInSlot = int.Parse(_textCount.text);
    //        _countItemInSlot++;
    //    }
    //    _textCount.text = _countItemInSlot.ToString();
    //}


    ///// <summary>
    ///// Метод сравнения элмента в ячейке инвентаря м подбираемого элемента
    ///// </summary>
    ///// <param name="item">подбираемый элемент</param>
    ///// <param name="array">массив элементов</param>
    ///// <param name="slotIndex">индекс в массиве элементов</param>
    ///// <returns></returns>
    //private bool CheckSameItem(GameObject item, int slotIndex, Dictionary<int, GameObject> inventory)
    //{
        
    //    Debug.Log(inventory.Count);

    //    if (inventory.Count != 0)
    //        return (inventory[slotIndex].name.Equals(item.name)) ? true : false;
    //    else
    //        return false;
    //}

    //private bool ChekSameItem(GameObject item, int slotIndex) 
    //{
    //    if (invent[slotIndex].tag.Equals(item.tag))
    //    {
    //        Debug.Log(invent[slotIndex].name);
    //        return true;
    //    }
    //    else return false;
    //}

    ///// <summary>
    ///// Вызывается событием onCollisionPlayer в скрипте PlayerCollision
    ///// </summary>
    ///// <param name="item">Объект,с которым столкнулся игрок</param>
    //public void AddItemToInventory(GameObject item)
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (isFull[i] == false)
    //        {
    //            isFull[i] = true;
    //            invent.Add(item);
    //            //перемещение объекта в ячейку
    //            item.transform.position = slots[i].transform.position;
    //            //изменение количества в ячейке
    //            ChangeCountItemInUI(slots[i]);
    //            break;
    //        } else 
    //        {
    //            if (!ChekSameItem(item, i)) Debug.Log("Checking same items " + ChekSameItem(item, i));

    //            //возврат в пул
    //            item.SetActive(false);   
    //            ChangeCountItemInUI(slots[i]);
    //            break;
    //        }
            
    //        //else
    //        //{
    //        //    isFull[i] = true;
    //        //    invent.Add(item);
    //        //    //перемещение объекта в ячейку
    //        //    item.transform.position = slots[i].transform.position;
    //        //    //изменение количества в ячейке
    //        //    ChangeCountItemInUI(slots[i]);
    //        //    break;
    //        //}
    //    }
    //}
    #endregion
}
