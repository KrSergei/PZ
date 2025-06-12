using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _iconItem;
    [SerializeField] private Button _button;
    [SerializeField] private DisplayInventory _inventory;
    [SerializeField] private TextMeshProUGUI _amount;
    [SerializeField] private int _slotIndex;

    public int SlotIndex { get => _slotIndex; set => _slotIndex = value; }

    private void Start()
    {
        _inventory = GetComponentInParent<DisplayInventory>();
    }

    internal void ActivateIconInSlot(Sprite icon)
    {
        _iconItem.sprite = icon;
        _iconItem.color = new Color(_iconItem.color.r, _iconItem.color.g, _iconItem.color.b, 255f);
    }

    internal void DeactivateIconInSlot()
    {        
        _iconItem.color = new Color(_iconItem.color.r, _iconItem.color.g, _iconItem.color.b, 0f);
        _iconItem.sprite = null;
    }

    internal TextMeshProUGUI GetTextCount()  { return _amount; }

    internal Button GetButton() { return _button; }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (_button != null)
            ActivateDeactivateButton();
    }

    async private void ActivateDeactivateButton()
    {
        _button.gameObject.SetActive(true);        
        await UniTask.Delay(2000);
        _button.gameObject.SetActive(false);
    }

    async public void DeleteItemFromInventory()
    {
        _inventory.RemoveItem(_slotIndex);
        await Task.CompletedTask;
    }
}
