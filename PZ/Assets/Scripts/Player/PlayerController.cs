using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed; //скорость передвижения
    public CharacterController characterController;
    public Joystick joystick;    

    private float _horizontal;
    private float _vertical;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _horizontal = joystick.Horizontal;
        _vertical = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        characterController.Move(new Vector3(_horizontal, _vertical, 0f) * _speed *  Time.fixedDeltaTime);
    }
}
