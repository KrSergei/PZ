using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    public static BulletsPool instance;

    public Transform bulletsStorage;
    [SerializeField] private GameObject _bulletPrefab;
    private Queue<GameObject> _bullets = new Queue<GameObject>();

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// Метод возвращает объект пуля для
    /// </summary>
    /// <returns></returns>
    public GameObject GetItemFromPool()
    {
        GameObject item;
        if (_bullets.Count == 0)
        {
            item = Instantiate(_bulletPrefab);
            _bullets.Enqueue(item);
           
            return item;
        }
        else
        {
            item = _bullets.Dequeue();
            item.transform.parent = null;
            return item;
        }
    }

    public void AddItemToPool(GameObject item)
    {
        item.transform.parent = bulletsStorage;
        _bullets.Enqueue(item);
    }
}
