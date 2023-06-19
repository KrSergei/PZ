using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{

    public float timeBetweenShoot; //пауза между выстрелами

    public Transform bulletSpot; //позиция генерации пули
    
    [SerializeField]
    private GameObject _bullet;

    private Queue<GameObject> _bullets = new Queue<GameObject>();
    private float _remaindtime;
    private void OnEnable()
    {
        PlayerRadar.onTriggeredMonster += DoShoot;
    }
    private void OnDisable()
    {
        PlayerRadar.onTriggeredMonster -= DoShoot;
    }

    private void DoShoot()
    {
        if (_remaindtime <= 0)
        {
            Instantiate(_bullet, bulletSpot.position, Quaternion.identity);
            _remaindtime = timeBetweenShoot;
        } 
        else _remaindtime -= Time.deltaTime;
    }
}
