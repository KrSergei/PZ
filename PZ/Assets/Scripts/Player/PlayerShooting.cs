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
        //��������� ������� ���� �������� ������
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
    /// ������� ������� ����� ��������� ����� �������������
    /// </summary>
    /// <param name="bullet"></param>
    private async void ReturnToPool(GameObject bullet)
    {
        //��������� ������� ������������� ����
        float time = bullet.GetComponent<BulletController>().LifeTime;
        //������� ���� � ���
        _bulletPool.Return(bullet);
        //������ ������� �� ����������� ����
        await UniTask.Delay((int)time * 1000);
        //����������� ����
        bullet.SetActive(false);
    }
    #endregion

    #region public method
    /// <summary>
    /// ���������� ��������, ����� ������� ���� �� ���� � ��������� ����� ��������
    /// </summary>
    public void DoShoot()
    {
        if (_remaindTime <= 0)
        {
            //�������� �� ������� �������� � ���������
            if (inventory.CanShoot()) 
            {
                //�������� ����
                GameObject bullet = _bulletPool.Get();
                bullet.transform.rotation = weapon.rotation;
                bullet.transform.position = shootSpot.position;
                bullet.SetActive(true);
                //���������� ������� ��������������
                _remaindTime = timeBetweenShoot;
                //������� ���� � ���
                ReturnToPool(bullet);
            }
        }
    }

    /// <summary>
    /// �������� ���� ������� "����"
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