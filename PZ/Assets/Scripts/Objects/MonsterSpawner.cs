using ObjecPool;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public int startAmountMonster;
    public Transform monstersPool;
    public GameObject monsterPrefab;
    public BoxCollider2D areaSpawn;

    [SerializeField] private float _sizeX;
    [SerializeField] private float _sizeY;
    private PoolBase<GameObject> _monsters;

    private void Awake()
    {
        areaSpawn.GetComponent<BoxCollider2D>();
        areaSpawn.size = new Vector2( _sizeX, _sizeY);
        _monsters = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, startAmountMonster);
    }

    public void GetItem(Transform position)
    {
        //Создание пули
        GameObject item = _monsters.Get();
        item.transform.position = position.position;
        item.SetActive(true);
        //возврат в пул
        _monsters.Return(item);
    }

    public GameObject Preload()
    {
        GameObject item = Instantiate(monsterPrefab);
        monsterPrefab.GetComponent<BulletDamage>().damage = GetComponentInChildren<WeaponBulletType>().GetBulletDamage();
        item.transform.parent = monstersPool;
        return item;
    }
    public void GetAction(GameObject bullet) => monsterPrefab.gameObject.SetActive(true);
    public void ReturnAction(GameObject bullet) => monsterPrefab.gameObject.SetActive(false);

}
