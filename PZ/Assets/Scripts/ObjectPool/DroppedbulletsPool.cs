using System.Collections.Generic;
using UnityEngine;

public class DroppedBulletsPool : MonoBehaviour
{
    public static DroppedBulletsPool instance;

    public Transform bulletsStorage;
    [SerializeField] private GameObject _droppedBulletPrefab;   

    private Queue<GameObject> _droppedBullets = new Queue<GameObject>();

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
        if (_droppedBullets.Count == 0)
        {
            item = Instantiate(_droppedBulletPrefab);
            _droppedBullets.Enqueue(item);

            return item;
        }
        else
        {
            item = _droppedBullets.Dequeue();
            item.transform.parent = null;
            return item;
        }
    }

    public void AddItemToPool(GameObject item)
    {
        item.transform.parent = bulletsStorage;
        _droppedBullets.Enqueue(item);
    }
}
