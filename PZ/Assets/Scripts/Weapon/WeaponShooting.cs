using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    public float timeBetweenShoot; //пауза между выстрелами
    public Transform bulletSpot; //позиция генерации пули
    
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _magazine;
    [SerializeField]
    private Queue<GameObject> _bullets = new Queue<GameObject>();
    private float _remaindtime;

    private void OnEnable()
    {
        //PlayerRadar.onTriggeredMonster += DoShoot;
        //BulletController.isTimeLifeOver += AddBulletToStorage;
    }
    private void OnDisable()
    {
        //PlayerRadar.onTriggeredMonster -= DoShoot;
        //BulletController.isTimeLifeOver -= AddBulletToStorage;
    }

    private void DoShoot()
    {
        if (_remaindtime <= 0)
        {
            //GameObject bullet = Instantiate(GetBullet(), bulletSpot.position, Quaternion.identity);
            _remaindtime = timeBetweenShoot;
        } 
        else _remaindtime -= Time.deltaTime;
    }

    /// <summary>
    /// Метод возвращает объект пуля для
    /// </summary>
    /// <returns></returns>
    //private GameObject GetBullet()
    //{
    //    //Debug.Log("Bullets count = " + _bullets.Count);
    //    //GameObject bullet;
    //    //if (_bullets.Count == 0) bullet = _bullet;
    //    //else bullet = _bullets.Dequeue();
    //    ////GameObject bullet = (_bullets.Count == 0) ? _bullet : _bullets.Dequeue();
    //    //bullet.SetActive(true);
    //    //bullet.transform.parent = null;
    //    //return bullet;
    //}

    //private void AddBulletToStorage(GameObject currentBullet)
    //{
    //    //currentBullet.transform.parent = _magazine;
    //    //currentBullet.SetActive(false);
    //    //_bullets.Enqueue(currentBullet);
    //}
}
