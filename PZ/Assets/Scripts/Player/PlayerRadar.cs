using System;
using UnityEngine;

public class PlayerRadar : MonoBehaviour
{
    #region fields
    public static Action onLokedMonster;

    public Transform shootSpot;
    public LayerMask layer;  
    public float radiusRadar;

    private CircleCollider2D _collider;
    [SerializeField]
    private Transform _radarBorderSprite;
    [SerializeField]
    private int _lokedMonster;
    [SerializeField]
    private float _remaindtime;
    #endregion

    #region private methods
    private void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        SetSizeRadarBorder();
    }

    /// <summary>
    /// Установка границ радара в зависимости от радиуса
    /// </summary>
    private void SetSizeRadarBorder()
    {
        //установка размера коллайдера
        _collider.radius = radiusRadar;
        //вычисление вектора для масштабирования
        Vector2 renderScale = new(_radarBorderSprite.localScale.x * radiusRadar, _radarBorderSprite.localScale.y * radiusRadar);
        //установка размера картинки
        _radarBorderSprite.transform.localScale = renderScale;
    }

    private void FixedUpdate()
    {

        //Пуск луча если, количество обнаруженных монстров больше 0
        if (_lokedMonster > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(shootSpot.position, shootSpot.transform.right, radiusRadar * 5, layer);
            //Если луч столкнулся с коллайдером монстра, то сделать выстрел
            if (hit.collider != null) onLokedMonster?.Invoke();
        }
    } 

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //инкремент количества обнаруживаемых монстров
        if (collider != null)
        {
            if (collider.TryGetComponent<Monster>(out var monster))
            {
                _lokedMonster++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //декремент количества обнаруживаемых монстров
        if (collider != null)
        {
            if (collider.TryGetComponent<Monster>(out var monster))
            {
                _lokedMonster--;
            }
        }
    }
    #endregion
}