using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField]
    private Queue<GameObject> _bullets = new Queue<GameObject>();

    public Transform bulletsSpotSpawn;
    public Transform bulletsStorage;
    [SerializeField] private GameObject _bulletPrefab;

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

        //if (_bullets.Count == 0)
        bullet = Instantiate(_bulletPrefab);
        //else
        //    bullet = _bullets.Dequeue();

        bullet.SetActive(true);
        bullet.transform.parent = null;
        return bullet;
    }

    public void AddBulletToStorage(GameObject currentBullet)
    {
        //Debug.Log("Deactivate");
        currentBullet.transform.parent = bulletsStorage;
        currentBullet.SetActive(!gameObject.activeInHierarchy);
       _bullets.Enqueue(currentBullet);
    }

}
