using System.Collections.Generic;
using UnityEngine;

public class ItemsSpotStorage : MonoBehaviour
{
    [SerializeField] private string _nameSpotStorage;
    [SerializeField] private List<Transform> _spawnSpotsStorage = new ();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnSpotsStorage.Add(transform.GetChild(i));
        }
        CheckNameStorage();
    }

    //Set name for spawnSpotStorage
    private void CheckNameStorage() { if(_nameSpotStorage == null) _nameSpotStorage = transform.name;}
    //Get count spots of spawn 
    public int GetCountSpawnedItems(){ return _spawnSpotsStorage.Count; }
    //Get position by index from sapwn spots storage
    public Transform GetSpotSpawn(int index) { return _spawnSpotsStorage[index].transform;}
    //Get name spots storage
    public string GetNameSpotStorage() { return _nameSpotStorage; }
}
