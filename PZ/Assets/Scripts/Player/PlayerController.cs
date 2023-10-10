using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Rigidbody2D _rb;
    public float force;

    public WeaponRotate weaponRotate;

    private float _horizontal;
    private float _vertical;
    private Vector3 _resultDestination;

    public Vector3 ResultDestination { get => _resultDestination; private set => _resultDestination = value; }

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
    }
}
