using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISlot : MonoBehaviour, IPointerDownHandler, IDropHandler
{
    public UIItem currentItem;

    [SerializeField] private int _slotIndex;
    [SerializeField] private DisplayInventory _inventory;
    [SerializeField] private Button _button;
    [SerializeField] private bool _canUseItem = true;
    public int SlotIndex { get => _slotIndex; set => _slotIndex = value; }
    public bool canUseItem { get => _canUseItem; set => _canUseItem = value; }

    private void Start()
    {
        _inventory = GetComponentInParent<DisplayInventory>();
        _button = GetComponentInParent<Button>();
        _canUseItem = true;
        currentItem = GetComponentInChildren<UIItem>();
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
    }
}