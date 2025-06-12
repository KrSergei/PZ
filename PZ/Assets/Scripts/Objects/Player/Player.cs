using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IPlayer
{
    public event Action OnDeath;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _force;
    [SerializeField] private bool _isTurnToLeft = true;

    [SerializeField] private SpriteRenderer[] _playerSpriteRenderers;
    [SerializeField] private WeaponRotate _weaponRotate;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();       
    }
    public Vector2 GetPosition()
    {
       return this.transform.position;
    }

    public void Move(Vector2 direction, float deltatime)
    {
        this._rb.AddForce(direction * (deltatime * _force));
        TurnSpriteRenderInRightDirection(direction.x);
        _weaponRotate.RotateWeapon(direction);
    }

    [ContextMenu("Death")]
    public void Death()
    {
        this.OnDeath?.Invoke();
    }

    Vector2 IPlayer.GetPosition()
    {
        return GetPosition();
    }
       
    /// <summary>
    /// Сброс скорости при повороте персонажа
    /// </summary>
    /// <param name="directionX"></param>
    private void TurnSpriteRenderInRightDirection(float directionX)
    {
        if ((directionX < 0 && !_isTurnToLeft) || (directionX > 0 && _isTurnToLeft))
        {            
            float velocityY = _rb.velocity.y;
            _rb.velocity = new Vector2(0f, velocityY);
            _isTurnToLeft = !_isTurnToLeft;
            RotateBoby(directionX);
        }
    }

    /// <summary>
    /// Проверка и поворот персонажжа в зависимости от знака координаты по оси Х. 
    /// Если угол равен или больше 0, по поворот вправо, ниче поворот влево
    /// </summary>
    private void RotateBoby(float directionX)
    {
        if (directionX >= 0)
        {
            foreach (var renderer in _playerSpriteRenderers) renderer.flipX = false;
        }
        else
        {
            foreach (var renderer in _playerSpriteRenderers) renderer.flipX = true;
        }
    }
}
