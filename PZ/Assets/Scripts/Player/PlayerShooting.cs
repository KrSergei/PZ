using Cysharp.Threading.Tasks;
using ObjecPool;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    #region fields
    private const int BULLET_PRELOAD_COUNT = 10;

    [Header("Weapon")]
    public Transform weapon;
    public Transform shootSpot;
    public GameObject bulletPrefab;
    public float offsetRotateBullet;
    public float timeBetweenShoot;
    public Inventory inventory;

    [SerializeField] private float _remaindTime;
    [SerializeField] private bool _canShoot;
    [SerializeField] private Transform _bulletsStorage;
    private PoolBase<GameObject> _bulletPool;
    #endregion

    #region private method
    private void Awake()
    {
        //получение префаба пули текущего оружия
        bulletPrefab = GetComponentInChildren<WeaponBulletType>().GetBulletPrefab();
        _bulletPool = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, BULLET_PRELOAD_COUNT);
        inventory = GetComponent<Inventory>();
    }
    private void OnEnable()
    {
        PlayerRadar.onLokedMonster += DoShoot;
    }
    private void OnDisable()
    {
        PlayerRadar.onLokedMonster -= DoShoot;
    }
    private void FixedUpdate()
    {
        if (_remaindTime > 0)
            _remaindTime -= Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.Space)) DoShoot();
    }

    /// <summary>
    /// Возврат объекта через указанное время существования
    /// </summary>
    /// <param name="bullet"></param>
    private async void ReturnToPool(GameObject bullet)
    {
        //получение времени существования пули
        float time = bullet.GetComponent<BulletController>().LifeTime;
        //возврат пули в пул
        _bulletPool.Return(bullet);
        //отсчет времени до деактивации пули
        await UniTask.Delay((int)time * 1000);
        //деактивация пули
        bullet.SetActive(false);
    }
    #endregion

    #region public method
    /// <summary>
    /// Реализация выстрела, выбор префаба пули из пула и установка точки стрельбы
    /// </summary>
    public void DoShoot()
    {
        if (_remaindTime <= 0)
        {
            //проверка на наличие патронов в инвентаре
            if (inventory.CanShoot()) 
            {
                //Создание пули
                GameObject bullet = _bulletPool.Get();
                bullet.transform.rotation = weapon.rotation;
                bullet.transform.position = shootSpot.position;
                bullet.SetActive(true);
                //обновление времени восстановления
                _remaindTime = timeBetweenShoot;
                //возврат пули в пул
                ReturnToPool(bullet);
            }
        }
    }

    /// <summary>
    /// Создание пула объекта "пуля"
    /// </summary>
    /// <returns></returns>
    public GameObject Preload()
    {
        GameObject item = Instantiate(bulletPrefab);
        bulletPrefab.GetComponent<BulletDamage>().damage = GetComponentInChildren<WeaponBulletType>().GetBulletDamage();
        item.transform.parent = _bulletsStorage;
        return item;
    }
    public void GetAction(GameObject bullet)=> bulletPrefab.gameObject.SetActive(true); 
    public void ReturnAction(GameObject bullet)=> bulletPrefab.gameObject.SetActive(false);
    #endregion
}