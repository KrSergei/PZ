using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int PRELOAD_COUNT = 10;
    public List<GameObject> canDpopedItemsPools = new List<GameObject>();  

    private void Awake()
    {
        //�������� ����� ���������, ������� ����� �������� ����� ������ �������
        for (int i = 0; i < canDpopedItemsPools.Count; i++)
        {
            GameObject prefab = canDpopedItemsPools[i].GetComponent<Pool>().GetPrefab();
        }
    }

    /// <summary>
    /// ������� ������ ������
    /// </summary>
    /// <returns></returns>
    public int GetAmounItems() => canDpopedItemsPools.Count;

    /// <summary>
    /// �������� ������� �� ���� � ��������� �������� � � ��������� �������
    /// </summary>
    /// <param name="index"></param>
    /// <param name="position"></param>
    public void DropChoicedItemsPool(int index, Vector3 position)
    {
        canDpopedItemsPools[index].GetComponent<Pool>().GetItem(position);
    }
}
