using ObjecPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    public int PRELOAD_COUNT = 10;
    public Transform bulletsStorage;
    [SerializeField] private GameObject _droppedItemPrefab;
    [SerializeField] private ItemObject _droppedItem;
    //private Queue<GameObject> _droppedItems = new Queue<GameObject>();
    private PoolBase<GameObject> _droppedItems;
    private void Awake()
    {
        if (instance == null) instance = this;
        _droppedItems = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, PRELOAD_COUNT);
    }

    public GameObject GetPrefab()
    {
        return _droppedItem.prefab;
    }

    public void GetItem(Transform position)
    {
        //Создание пули
        GameObject item = _droppedItems.Get();
        item.transform.position = position.position;
        item.SetActive(true);
        //возврат в пул
        _droppedItems.Return(item);
    }

    public GameObject Preload()
    {
        GameObject item = Instantiate(_droppedItem.prefab);
        item.transform.parent = transform;
        return item;
    }
    public void GetAction(GameObject item) => _droppedItem.prefab.gameObject.SetActive(true);
    public void ReturnAction(GameObject item) => _droppedItem.prefab.gameObject.SetActive(false);
}
