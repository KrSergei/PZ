using System;
using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;

    public static Action<GameObject> isTimeLifeOver;
    private float _remaidTime;

    void Start()
    {
        //_remaidTime = lifeTime;
        StartCoroutine(Deactivate());
    }

    //void Update()
    //{
    //    if (_remaidTime > 0) _remaidTime -= Time.deltaTime;
    //    else DeactivateBullet();
    //}

    //private void DeactivateBullet()
    //{
    //    Debug.Log(_remaidTime);
    //    gameObject.SetActive(false);
    //}

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(lifeTime);
        ObjectPool.instance.AddBulletToStorage(gameObject);

        //gameObject.SetActive(false);
    }
}