using UnityEngine;

public class BulletController : MonoBehaviour
{    
    public float speed;

    [SerializeField]
    private float lifeTime;

    public float LifeTime { get => lifeTime;  private set => lifeTime = value; }

    void Start()
    {
       
    }

    private void FixedUpdate()
    {
      
    }
}