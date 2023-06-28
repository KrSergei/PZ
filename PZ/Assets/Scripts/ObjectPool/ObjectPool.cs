using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
  
    public Transform bulletsSpotSpawn;
    public Transform bulletsStorage;
    [SerializeField] private GameObject _bulletPrefab;

    private Queue<GameObject> _bullets = new Queue<GameObject>();

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// Метод возвращает объект пуля для
    /// </summary>
    /// <returns></returns>
    public GameObject GetBulletQueue()
    {
        GameObject bullet;
        if (_bullets.Count == 0)
        {
            bullet = Instantiate(_bulletPrefab);
            _bullets.Enqueue(bullet);
           
            return bullet;
        }
        else
        {
            bullet = _bullets.Dequeue();
            bullet.transform.parent = null;
            return bullet;
        }
    }

    public void AddBulletToStorage(GameObject currentBullet)
    {
        currentBullet.transform.parent = bulletsStorage;
        _bullets.Enqueue(currentBullet);
    }
}
