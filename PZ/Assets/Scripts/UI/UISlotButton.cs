using UnityEngine;
using UnityEngine.EventSystems;

public class UISlotButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler
{
    [SerializeField]
    private bool m_IsDragging = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        m_IsDragging = false;
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        m_IsDragging = true;
        if (m_IsDragging) Debug.Log("UISlotButton: relased button");
    }
}