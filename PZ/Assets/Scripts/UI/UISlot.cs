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
        //Получение текущего предмета
        var otherItemTransform = eventData.pointerDrag.transform;
        //Получение индекса слота интерфейса
        int index = otherItemTransform.GetComponentInParent<UISlot>().SlotIndex;
        //Проверка, есть ли в нужном слоте предмет
        if (transform.GetComponentInChildren<UIItem>() != null)
        {   
            //Получение ссылки на предмет в слоте
            GameObject currentItem = transform.GetComponentInChildren<UIItem>().gameObject;
            //Перенос из текущего слота в слот переносимого предмета 
            currentItem.transform.SetParent(otherItemTransform.GetComponentInParent<UISlot>().transform);
            //Установка позиции предмета в центре слота
            currentItem.transform.localPosition = Vector3.zero;
        }
        //Перенос предмета в слот
        otherItemTransform.SetParent(transform);
        // Установка позиции предмета в центре слота
        otherItemTransform.localPosition = Vector3.zero;
        //
        _inventory.SwapSlots(index, SlotIndex);
    }

}