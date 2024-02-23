using System.Collections.Generic;
using UnityEngine;

public class ItemsPools : MonoBehaviour
{
    public int PRELOAD_COUNT = 10;
    public Dictionary<string, Pool> itemPool = new ();


    private void Start()
    {
        //�������� ����� ���������, ������� ����� �������� ����� ������ �������
        for (int i = 0; i < transform.childCount; i++)
        {
            //pools.Add(transform.GetChild(i).GetComponent<Pool>());
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
        //itemPool[index].GetItem(position);
    }
}
