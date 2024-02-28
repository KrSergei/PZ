using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private int _slotIndex;
    [SerializeField] private DisplayInventory _inventory;
    public int SlotIndex { get => _slotIndex; set => _slotIndex = value; }

    private void Start()
    {
        _inventory = GetComponentInParent<DisplayInventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //��������� �������� ��������
        var otherItemTransform = eventData.pointerDrag.transform;
        //��������� ������� ����� ����������
        int index = otherItemTransform.GetComponentInParent<UISlot>().SlotIndex;
        //��������, ���� �� � ������ ����� �������
        if (transform.GetComponentInChildren<UIItem>() != null)
        {   
            //��������� ������ �� ������� � �����
            GameObject currentItem = transform.GetComponentInChildren<UIItem>().gameObject;
            //������� �� �������� ����� � ���� ������������ �������� 
            currentItem.transform.SetParent(otherItemTransform.GetComponentInParent<UISlot>().transform);
            //��������� ������� �������� � ������ �����
            currentItem.transform.localPosition = Vector3.zero;
        }
        //������� �������� � ����
        otherItemTransform.SetParent(transform);
        // ��������� ������� �������� � ������ �����
        otherItemTransform.localPosition = Vector3.zero;
        //
        _inventory.SwapSlots(index, SlotIndex);
    }

}