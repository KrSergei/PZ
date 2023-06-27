using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonDelete : MonoBehaviour
{
    [Header("Event")]
    [SerializeField] private EvenInt onPressButtonDelete;

    public InventoryObject inventory;

    //public Clickable buttonDelete;
    public Button button;
    public int indexButton;

    public void ActivateButton()
    {
        button.gameObject.SetActive(true);
    }

    public void OnPreeedButton()
    {
        inventory.RemoveItem(indexButton);
    }
}

[System.Serializable]
public class EvenInt : UnityEvent<int> { }
