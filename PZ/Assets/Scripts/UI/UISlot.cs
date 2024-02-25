using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //��������� �������� ��������
        var otherItemTransform = eventData.pointerDrag.transform;
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
}