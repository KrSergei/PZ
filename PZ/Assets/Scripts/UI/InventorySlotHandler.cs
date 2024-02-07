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
        if (_iconItem.gameObject.activeInHierarchy != true) _iconItem.gameObject.SetActive(true);
        _iconItem.sprite = icon;
    }

    internal void DeactivateIconInSlot()
    {
        _iconItem = null;
        if (_iconItem.gameObject.activeInHierarchy != false) _iconItem.gameObject.SetActive(false);
    }

    public TextMeshProUGUI GetTextCount()  { return _amount; }

    public Button GetButton() { return _button; }
}
