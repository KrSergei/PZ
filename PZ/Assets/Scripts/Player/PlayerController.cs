using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Animator animator;
    //порог значения джойстика по оси х, при котором включается анимация walk_up или walk_down, в зависимости от знака(положительное или отрицательное)
    public float valueForSwitchAnimation; 
    public float force;

    public WeaponRotate weaponRotate;

    private float _horizontal;
    private float _vertical;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rb;
    private Vector2 _resultDestination;
    [SerializeField] private bool _isTurnToRight = true;

    public Vector2 ResultDestination { get => _resultDestination; private set => _resultDestination = value; }

    void Start()
    {
        animator =  GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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

        if (_horizontal != 0)
        {   
            if (Mathf.Abs(_horizontal) > valueForSwitchAnimation) {

                animator.Play("walk");
            } 
            else if (Mathf.Abs(_horizontal) < valueForSwitchAnimation && _vertical < 0)
            {
                animator.Play("walk_down");
            }
            else if (Mathf.Abs(_horizontal) < valueForSwitchAnimation && _vertical > 0) {

                animator.Play("walk_up");
            } 
        }
        else
        {
            SetVelosityXToZero();
            animator.Play("idle");
        }
    }

    private void TurnSpriteRenderInRightDirection(float direction)
    {
        if ((direction < 0 && !_isTurnToRight) || (direction > 0 && _isTurnToRight))
        {
            //transform.localScale *= new Vector2(-1, 1);
            _spriteRenderer.flipX = _isTurnToRight;
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
