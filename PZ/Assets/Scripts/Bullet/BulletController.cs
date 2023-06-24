using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{    
    public float speed;
    public Rigidbody2D rb;

    [SerializeField]
    private float lifeTime;

    public float LifeTime { get => lifeTime;  private set => lifeTime = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);       
    }
}