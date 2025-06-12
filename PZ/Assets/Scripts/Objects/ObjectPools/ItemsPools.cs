using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemsPools : MonoBehaviour
{
    public int PRELOAD_COUNT = 3;
    public Dictionary<string, Pool> itemPool = new ();


    private void Start()
    {
        //�������� ����� ���������, ������� ����� �������� ����� ������ �������
        for (int i = 0; i < transform.childCount; i++)
        {            
            itemPool.Add(transform.GetChild(i).GetComponent<Pool>().nameItemInPool, transform.GetChild(i).GetComponent<Pool>());
        }
    }

    public Pool GetPool(string namePool)
    {
        return itemPool[namePool].GetComponent<Pool>();
    }

    /// <summary>
    /// ������� ������ ������
    /// </summary>
    /// <returns></returns>
    public int GetAmounItems() => itemPool.Count; 

    /// <summary>
    /// �������� ������� �� ���� � ��������� �������� � � ��������� �������
    /// </summary>
    /// <param name="index"></param>
    /// <param name="position"></param>
    public void SpawnChoicedItemsPool(int index, Vector3 position)
    {
        var nameItem = itemPool.ElementAt(index).Key;
        itemPool[nameItem].GetItem(position);
    }
}
