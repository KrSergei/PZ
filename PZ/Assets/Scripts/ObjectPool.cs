using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField]
    private List<GameObject> _bulletsPool = new List<GameObject>();

    [SerializeField]
    private Queue<GameObject> _bullets = new Queue<GameObject>();


    public float timeBetweenShoot;
    public int magazinCapacity;

    public Transform bulletsSpotSpawn;
    public Transform bulletsStorage;
    [SerializeField] private GameObject _bulletPrefab;
    private float _remaindtime;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        //for (int i = 0; i < magazinCapacity; i++)
        //{
        //    GameObject bullet = Instantiate(_bulletPrefab);
        //    bullet.SetActive(false);
        //    bullet.transform.parent = transform;
        //    _bulletsPool.Add(bullet);
        //}
        _remaindtime = timeBetweenShoot;
    }
    //private void OnEnable()
    //{
    //    PlayerRadar.onTriggeredMonster += DoShoot;
    //    BulletController.isTimeLifeOver += AddBulletToStorage;
    //}

    //private void OnDisable()
    //{
    //    PlayerRadar.onTriggeredMonster -= DoShoot;
    //    BulletController.isTimeLifeOver -= AddBulletToStorage;
    //}

    private void Update()
    {
        if (_remaindtime > 0)
        {
            _remaindtime -= Time.deltaTime;
        }
    }

    private void DoShoot()
    {
        GameObject bullet = GetBullet();
        //bullet.SetActive(true);
        //_remaindtime = timeBetweenShoot;
        //if (_remaindtime <= 0)
        //{
        //    GameObject bullet = GetBullet();
        //    bullet.SetActive(true);
        //    _remaindtime = timeBetweenShoot;
        //    Debug.Log("remaindtime afte shoot - " + _remaindtime);
        //}
    }

    /// <summary>
    /// Метод возвращает объект пуля для
    /// </summary>
    /// <returns></returns>
    public GameObject GetBullet()
    {
        Debug.Log("Get bullet");
        for (int i = 0; i < _bulletsPool.Count; i++)
        {
            if(_bulletsPool.Count == 0)
            {
                GameObject bullet = _bulletPrefab;
                _bulletsPool.Add(bullet);
                return bullet;
            }else if(!_bulletsPool[i].activeInHierarchy)
            {
                
                return _bulletsPool[i];
            }
        }
        _remaindtime = timeBetweenShoot;
        return null;
    }
    //private void AddBulletToStorage(GameObject currentBullet)
    //{
    //    currentBullet.SetActive(false);
    //}


    /// <summary>
    /// Метод возвращает объект пуля для
    /// </summary>
    /// <returns></returns>
    public GameObject GetBulletQueue()
    {
        GameObject bullet;
        Debug.Log(_remaindtime);
        if (_remaindtime <= 0)
        {
            Debug.Log("Get bullet");
            if (_bullets.Count == 0)
                bullet = Instantiate(_bulletPrefab, bulletsSpotSpawn.position, Quaternion.identity);
            else
                bullet = _bullets.Dequeue();

            bullet.SetActive(true);
            bullet.transform.parent = null;
            _remaindtime = timeBetweenShoot;
            return bullet;
        }
        else return null;
    }

    public void AddBulletToStorage(GameObject currentBullet)
    {
        currentBullet.transform.parent = transform;
        currentBullet.SetActive(false);
        _bullets.Enqueue(currentBullet);
    }

}
