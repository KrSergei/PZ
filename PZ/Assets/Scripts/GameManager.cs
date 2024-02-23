using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string AMMO = "ammo";
    public static GameManager instance;

    public int startAmount;
    public Pool pool;
    public GameObject monsterSpawnArea;
    [SerializeField] private ItemSpawner _itemSpawner;
    [SerializeField] private GameObject _itemsPools;
    private void Start()
    {
        GetPlayerPosition();
        //SpawnMonster();
        InitSpawnItems();
    }

    private void GetPlayerPosition()
    {
        Vector3 playerPosition = FindObjectOfType<Player>().transform.position;
    }
    private void SpawnMonster()
    {
        for (int i = 0; i < startAmount; i++)
        {
            pool.Init(GetPositionSpawnedMonster());
        }
    }
    private Vector3 GetPositionSpawnedMonster()
    {
        float sizeX = monsterSpawnArea.GetComponent<BoxCollider2D>().size.x;
        float sizeY = monsterSpawnArea.GetComponent<BoxCollider2D>().size.y;
        Vector3 position = new Vector3(Random.Range(sizeX * -0.5f, sizeX * 0.5f), Random.Range(sizeY * -0.5f, sizeY * 0.5f), 0f);
           
        return position;
    }

    private void InitSpawnItems()
    {
        _itemSpawner.StartSpawnItem(AMMO);
    }
}