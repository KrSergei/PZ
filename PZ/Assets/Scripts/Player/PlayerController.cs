using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed; //�������� ������������
    public CharacterController characterController;
    public Joystick joystick;

    public WeaponRotate weaponRotate;

    private float _horizontal;
    private float _vertical;
    private Vector3 _resultDestination;

    public Vector3 ResultDestination { get => _resultDestination; private set => _resultDestination = value; }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        weaponRotate = GetComponentInChildren<WeaponRotate>();
    }

    private void Update()
    {
        _horizontal = joystick.Horizontal;
        _vertical = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        //���������� ��������������� ������� �����������
        ResultDestination = new Vector3(_horizontal, _vertical, 0f);
        //������� �������� ������
        characterController.Move(ResultDestination * _speed *  Time.fixedDeltaTime);
        Debug.Log(_horizontal + " " + _vertical);
        weaponRotate.RotateWeapon(joystick);
    }
}
