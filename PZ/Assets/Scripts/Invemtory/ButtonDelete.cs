using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonDelete : MonoBehaviour
{
    [Header("Event")]
    [SerializeField] private UnityEvent onPressButtonDelete;
    
    public InventoryObject inventory;
    public DisplayInventory inventoryDisplay;

    public Button button;
    public TextMeshProUGUI textCount;
    public int indexButton;
    public float actionTimeButton;

    private void Start()
    {
        inventoryDisplay = FindObjectOfType<DisplayInventory>();
    }
    public void ActivateButton()
    {
        button.gameObject.SetActive(true);
        Timer();
    }
    public void OnPreeedButton()
    {
        inventory.RemoveItem(indexButton);
        inventoryDisplay.RemoveItem(indexButton);
        DeactivateButton();
    }
    private void DeactivateButton()
    {
        button.gameObject.SetActive(false);
    }

    /// <summary>
    /// Тамер для деактивации кнопки
    /// </summary>
    private  async void Timer()
    {
        await UniTask.Delay((int)actionTimeButton * 1000);
        DeactivateButton();
    }
}