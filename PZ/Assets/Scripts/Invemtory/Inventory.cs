using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private int _countItemInSlot;

    /// <summary>
    /// Отображение количества вещей в слоте инветнаря
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(GameObject item)
    {
        //Получение компонента текущего слота инвентаря
        _textCount = item.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //Если слот пустой, то инкремент количества предметов в слоте
        if(_textCount.text.Equals(""))
        {
            _countItemInSlot++;
        }
        //если слот не пустой, то инкремент текущего количества  в слоте 
        else
        {
            _countItemInSlot = int.Parse(_textCount.text);
            _countItemInSlot++;
        }
        _textCount.text = _countItemInSlot.ToString();
    }
}
