using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int slotsCount;
    public GameObject slotPrefab;

    public int x_Space_Beetwen_Items;
    public int number_of_column;

    void Start()
    {
        CreateDisplay();
    }

    /// <summary>
    /// ��������� �������� ���������
    /// </summary>
    private void CreateDisplay()
    {
        for (int i = 0; i < slotsCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab, Vector2.zero, Quaternion.identity, transform);
            slot.transform.localPosition = GetPosition(i);
                if(i < inventory.container.Count)
            {
                //��������� ������ �������� � �����
                slot.gameObject.GetComponent<Image>().sprite = GetIconItem(inventory.container[i]);
                //����� ��������� ��������� � �����
                slot.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
            }
        }   
    }

    /// <summary>
    /// �������� ������� ���������� ����� ���������
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private Vector3 GetPosition(int i)
    {
        return new Vector3(x_Space_Beetwen_Items * (i % number_of_column), 0f, 0f);
    }

    /// <summary>
    /// ������� ������ ��������
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private Sprite GetIconItem(InvemtorySlot item)
    {
        return item.item.prefab.GetComponent<SpriteRenderer>().sprite; 
    }
}
