using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public float force;
    public WeaponRotate weaponRotate;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private bool _isTurnToRight = true;

    private float _horizontal;
    private float _vertical;
    private Vector2 _resultDestination;

    public Vector2 ResultDestination { get => _resultDestination; private set => _resultDestination = value; }

    void Start()
    {     
        _rb = GetComponent<Rigidbody2D>();
        weaponRotate = GetComponentInChildren<WeaponRotate>();
    }

    private void Update()
    {
        _horizontal = joystick.Horizontal;
        _vertical = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        //Построение результируещего вектора направления
        ResultDestination = new Vector2(_horizontal, _vertical) * force * Time.fixedDeltaTime;
        //Задание движения игрока
        _rb.AddForce(ResultDestination);
        weaponRotate.RotateWeapon(joystick);
        TurnSpriteRenderInRightDirection(_horizontal);
    }

    private void TurnSpriteRenderInRightDirection(float direction)
    {
        if ((direction < 0 && !_isTurnToRight) || (direction > 0 && _isTurnToRight))
        {  
            SetVelosityXToZero();
            _isTurnToRight = !_isTurnToRight;
        }
    }
    private void SetVelosityXToZero()
    {
        float velocityY = _rb.velocity.y;
        _rb.velocity = new Vector2(0f, velocityY);
    }
}