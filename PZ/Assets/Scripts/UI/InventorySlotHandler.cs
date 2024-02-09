using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotHandler : MonoBehaviour
{
    [SerializeField] private Image _iconItem;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _amount;

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
}
