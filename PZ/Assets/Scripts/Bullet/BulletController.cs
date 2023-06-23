using UnityEngine;

public class BulletController : MonoBehaviour
{    
    public float speed;

    public Rigidbody2D rb;
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private bool _isPhisicsBody;

    public float LifeTime { get => lifeTime;  private set => lifeTime = value; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _isPhisicsBody = rb ? true : false;
    }


    private void FixedUpdate()
    {
        if (_isPhisicsBody) rb.AddForce(Vector2.right * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        else transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }
}