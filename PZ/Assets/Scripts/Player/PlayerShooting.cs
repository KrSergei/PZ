using Cysharp.Threading.Tasks;
using ObjecPool;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    #region fields
    private const int BULLET_PRELOAD_COUNT = 10;

    [Header("������")]
    public Transform weapon;
    public Transform shootSpot;
    public GameObject bulletPrefab;
    public float offsetRotateBullet;
    public float timeBetweenShoot;

    [SerializeField]
    private float _remaindtime;
    [SerializeField]
    private Transform _bulletsStorage;
    private PoolBase<GameObject> _bulletPool;
    #endregion

    #region private method
    private void Awake()
    {
        _bulletPool = new PoolBase<GameObject>(Preload, GetAction, ReturnAction, BULLET_PRELOAD_COUNT);
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
        if (_remaindtime > 0)
            _remaindtime -= Time.fixedDeltaTime;
    }

    /// <summary>
    /// ���������� ��������, ����� ������� ���� �� ���� � ��������� ����� ��������
    /// </summary>
    private void DoShoot()
    {
        if (_remaindtime <= 0)
        {
            GameObject bullet = _bulletPool.Get();
            bullet.transform.rotation = weapon.rotation;            
            bullet.transform.position = shootSpot.position;
            bullet.SetActive(true);
            _remaindtime = timeBetweenShoot;
            ReturnToPool(bullet);
        }
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
        //await UniTask.Delay((int)lifeTimeBullet * 1000);
        //����������� ����
        bullet.SetActive(false);
    }
    #endregion

    #region public method
    /// <summary>
    /// �������� ���� ������� "����"
    /// </summary>
    /// <returns></returns>
    public GameObject Preload()
    {
        GameObject item = Instantiate(bulletPrefab);
        item.transform.parent = _bulletsStorage;
        return item;
    }
    public void GetAction(GameObject bullet)=> bulletPrefab.gameObject.SetActive(true); 
    public void ReturnAction(GameObject bullet)=> bulletPrefab.gameObject.SetActive(false);
    #endregion
}