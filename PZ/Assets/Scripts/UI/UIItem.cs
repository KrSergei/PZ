using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private CanvasGroup _canvasGroup;
    [SerializeField] private Canvas _mainCanvas;
    private RectTransform _rectTransform;
    [SerializeField] private bool _isUsingItem = false;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
        _isUsingItem = true;
        UsingItemPeriod();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isUsingItem) Debug.Log("Using item");
        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }

    async private void UsingItemPeriod() {
        await UniTask.Delay(200);
        _isUsingItem = false;
    }

}
