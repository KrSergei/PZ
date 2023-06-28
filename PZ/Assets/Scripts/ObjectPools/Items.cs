using ObjecPool;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int PRELOAD_COUNT = 10;
    public List<Object> items = new List<Object>();

    public List<GameObject> canDpopedItemsPools = new List<GameObject>();
   

    private void Awake()
    {
        for (int i = 0; i < canDpopedItemsPools.Count; i++)
        {
            GameObject prefab = canDpopedItemsPools[i].GetComponent<Pool>().GetPrefab();
        }
       
        
        //_droppedBulletPool = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, PRELOAD_COUNT);
    }

    public GameObject GetChoicedItemsPool(int index)
    {
        return canDpopedItemsPools[index];
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
