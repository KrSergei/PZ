using ObjecPool;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    public string nameItemInPool;
    public int PRELOAD_COUNT = 10;
    public Transform itemStorage;
    [SerializeField] private ItemObject _spawnedItem;
    private PoolBase<GameObject> _spawnedItems;
    private void Awake()
    {
        if (instance == null) instance = this;
        _spawnedItems = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, PRELOAD_COUNT);
    }

    public void Init(Vector3 position)
    {
        GetItem(position);
    }
    public GameObject GetPrefab()
    {   
        return _spawnedItem.prefab;
    }

    public void GetItem(Vector3 position)
    {
        //Создание объекта
        GameObject item = _spawnedItems.Get();
        item.transform.position = position;
        item.SetActive(true);
        //возврат в пул
        _spawnedItems.Return(item);
    }

    public GameObject Preload()
    {
        //создание объекта
        GameObject item = Instantiate(_spawnedItem.prefab);
        //установка родиьеля для созданного объъекта
        item.transform.parent = transform;
        //присвоение имени для пула объектов.
        if(nameItemInPool == "") SetNameForpoolByItem(_spawnedItem.Name);
        return item;
    }

    private void SetNameForpoolByItem(string name)
    {
        nameItemInPool = name;
    }
    public void GetAction(GameObject item) => _spawnedItem.prefab.SetActive(true);
    public void ReturnAction(GameObject item) => _spawnedItem.prefab.SetActive(false);
}
