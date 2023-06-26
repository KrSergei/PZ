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
    ///// ����������� ���������� ����� � ����� ���������
    ///// </summary>
    ///// <param name="item"></param>
    //private void ChangeCountItemInUI(GameObject item)
    //{
    //    //��������� ���������� �������� ����� ���������
    //    _textCount = item.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    //    //���� ���� ������, �� ��������� ���������� ��������� � �����
    //    if(_textCount.text.Equals(""))
    //    {
    //        _countItemInSlot++;
    //    }
    //    //���� ���� �� ������, �� ��������� �������� ����������  � ����� 
    //    else
    //    {
    //        _countItemInSlot = int.Parse(_textCount.text);
    //        _countItemInSlot++;
    //    }
    //    _textCount.text = _countItemInSlot.ToString();
    //}


    ///// <summary>
    ///// ����� ��������� ������� � ������ ��������� � ������������ ��������
    ///// </summary>
    ///// <param name="item">����������� �������</param>
    ///// <param name="array">������ ���������</param>
    ///// <param name="slotIndex">������ � ������� ���������</param>
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
    ///// ���������� �������� onCollisionPlayer � ������� PlayerCollision
    ///// </summary>
    ///// <param name="item">������,� ������� ���������� �����</param>
    //public void AddItemToInventory(GameObject item)
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (isFull[i] == false)
    //        {
    //            isFull[i] = true;
    //            invent.Add(item);
    //            //����������� ������� � ������
    //            item.transform.position = slots[i].transform.position;
    //            //��������� ���������� � ������
    //            ChangeCountItemInUI(slots[i]);
    //            break;
    //        } else 
    //        {
    //            if (!ChekSameItem(item, i)) Debug.Log("Checking same items " + ChekSameItem(item, i));

    //            //������� � ���
    //            item.SetActive(false);   
    //            ChangeCountItemInUI(slots[i]);
    //            break;
    //        }
            
    //        //else
    //        //{
    //        //    isFull[i] = true;
    //        //    invent.Add(item);
    //        //    //����������� ������� � ������
    //        //    item.transform.position = slots[i].transform.position;
    //        //    //��������� ���������� � ������
    //        //    ChangeCountItemInUI(slots[i]);
    //        //    break;
    //        //}
    //    }
    //}
    #endregion
}
