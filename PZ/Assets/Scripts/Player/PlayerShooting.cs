using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform shootSpot;

    public float timeBetweenShoot;
    [SerializeField]
    private float _remaindtime;
    private void OnEnable()
    {
        PlayerRadar.onLokedMonster += DoShoot;
    }

    private void OnDisable()
    {
        PlayerRadar.onLokedMonster -= DoShoot;
    }
    private void Update()
    {
        if (_remaindtime > 0)
            _remaindtime -= Time.deltaTime;
    }

    /// <summary>
    /// Реализация выстрела, выбор префаба пули из пула 
    /// </summary>
    private void DoShoot()
    {
        if(_remaindtime <= 0)
        {
            GameObject bullet = ObjectPool.instance.GetBulletQueue();
            if (bullet != null)
            {
                bullet.transform.position = ObjectPool.instance.bulletsSpotSpawn.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);
                _remaindtime = timeBetweenShoot;
            }
        }
    }
}
