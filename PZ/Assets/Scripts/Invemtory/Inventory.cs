using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    [SerializeField] private TextMeshProUGUI _textCount;
    [SerializeField] private int _countItemInSlot;

    /// <summary>
    /// ����������� ���������� ����� � ����� ���������
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(GameObject item)
    {
        //��������� ���������� �������� ����� ���������
        _textCount = item.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        //���� ���� ������, �� ��������� ���������� ��������� � �����
        if(_textCount.text.Equals(""))
        {
            _countItemInSlot++;
        }
        //���� ���� �� ������, �� ��������� �������� ����������  � ����� 
        else
        {
            _countItemInSlot = int.Parse(_textCount.text);
            _countItemInSlot++;
        }
        _textCount.text = _countItemInSlot.ToString();
    }
}
