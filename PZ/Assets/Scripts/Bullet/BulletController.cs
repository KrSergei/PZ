using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;

    public static Action<GameObject> isTimeLifeOver;

    private float _remaidTime;    

    void Start()
    {
        _remaidTime = lifeTime;
    }
 
    void Update()
    {
        if (_remaidTime > 0) _remaidTime -= Time.deltaTime;
        else Deactivate();
    }

    private void Deactivate()
    {
        isTimeLifeOver?.Invoke(gameObject);
    }
}
