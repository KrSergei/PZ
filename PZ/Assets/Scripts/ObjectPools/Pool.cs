using ObjecPool;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    public int PRELOAD_COUNT = 10;
    public Transform bulletsStorage;
    [SerializeField] private GameObject _spawnedItemPrefab;
    [SerializeField] private ItemObject _spawnedItem;
    private PoolBase<GameObject> _spawnedItems;
    private void Awake()
    {
        if (instance == null) instance = this;
        _spawnedItems = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, PRELOAD_COUNT);
    }

    public void Init(Vector3 position)
    {
        //GetItem(position);
    }
    public GameObject GetPrefab()
    {
        return _spawnedItem.prefab;
    }

    public void GetItem(Transform position)
    {
        //Создание объекта
        GameObject item = _spawnedItems.Get();
        item.transform.position = position.position;
        item.SetActive(true);
        //возврат в пул
        _spawnedItems.Return(item);
    }

    public GameObject Preload()
    {
        GameObject item = Instantiate(_spawnedItem.prefab);
        item.transform.parent = transform;
        return item;
    }
    public void GetAction(GameObject item) => _spawnedItem.prefab.gameObject.SetActive(true);
    public void ReturnAction(GameObject item) => _spawnedItem.prefab.gameObject.SetActive(false);
}
