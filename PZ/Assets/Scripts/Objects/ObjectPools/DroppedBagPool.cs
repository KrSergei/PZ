using ObjecPool;
using System.Collections.Generic;
using UnityEngine;

public class DroppedBagPool : MonoBehaviour
{
    public static DroppedBagPool instance;
    public int PRELOAD_COUNT;
    public Transform bulletsStorage;
    [SerializeField] private GameObject _droppedBagPrefab;
    [SerializeField] private EqupmentObject _droppedBag;
    private Queue<GameObject> _droppedBags = new Queue<GameObject>();
    private PoolBase<GameObject> _droppedBulletPool;
    private void Awake()
    {
        if (instance == null) instance = this;
        _droppedBagPrefab = _droppedBag.prefab;
        //_droppedBulletPool = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, PRELOAD_COUNT);
    }

    public GameObject GetItemFromPool()
    {
        GameObject item;
        if (_droppedBags.Count == 0)
        {
            item = Instantiate(_droppedBagPrefab);
            _droppedBags.Enqueue(item);

            return item;
        }
        else
        {
            item = _droppedBags.Dequeue();
            item.transform.parent = null;
            return item;
        }
    }

    public void AddItemToPool(GameObject item)
    {
        item.transform.parent = bulletsStorage;
        _droppedBags.Enqueue(item);
    }


    //public GameObject Preload()
    //{
    //    GameObject item = Instantiate(bulletPrefab);
    //    bulletPrefab.GetComponent<BulletDamage>().damage = GetComponentInChildren<WeaponBulletType>().GetBulletDamage();
    //    item.transform.parent = _bulletsStorage;
    //    return item;
    //}
    //public void GetAction(GameObject bullet) => bulletPrefab.gameObject.SetActive(true);
    //public void ReturnAction(GameObject bullet) => bulletPrefab.gameObject.SetActive(false);

}
