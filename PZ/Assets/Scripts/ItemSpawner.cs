using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public ItemsPools itemsPools;
    [SerializeField] private List<string> _storageName = new();
    [SerializeField] private List<Transform> _spawnItemsStorages = new();
    private Dictionary<string, GameObject> _storages = new();
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnItemsStorages.Add(transform.GetChild(i));
            _storages.Add(GetKeyName(transform.GetChild(i).gameObject), transform.GetChild(i).gameObject);
            _storageName.Add(GetKeyName(transform.GetChild(i).gameObject));
        }
    }

    public void StartSpawnItem(string itemName)
    {
        //Get list spots storage by name
        ItemsSpotStorage currentItemSpotStorage = _storages[itemName].GetComponent<ItemsSpotStorage>();
        //Get length storage
        int countItems = currentItemSpotStorage.GetCountSpawnedItems();
        //Get items pool by name
        Pool currentPool = itemsPools.GetPool(itemName);
        //Position for spawn
        Transform spawnPos;
        for (int i = 0; i < countItems; i++)
        {
            spawnPos = currentItemSpotStorage.GetSpotSpawn(i);
            currentPool.GetItem(spawnPos.transform.position);
        }
    }

    private string GetKeyName(GameObject storage)
    {
        return storage.GetComponent<ItemsSpotStorage>().GetNameSpotStorage();
    }
}
