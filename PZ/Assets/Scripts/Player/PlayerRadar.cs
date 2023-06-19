using System;
using UnityEngine;

public class PlayerRadar : MonoBehaviour
{
    public static Action onTriggeredMonster;
    
    public float radiusRadar;
    
    private CircleCollider2D _collider;
    [SerializeField]
    private Transform _radarBorderSprite;

    void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        SetSizeRadarBorder();
    }

    /// <summary>
    /// Установка границ радара в зависимости от радиуса
    /// </summary>
    public void SetSizeRadarBorder()
    {
        //установка размера коллайдера
        _collider.radius = radiusRadar;
        //вычисление вектора для масштабирования
        Vector2 renderScale = new(_radarBorderSprite.localScale.x * radiusRadar, _radarBorderSprite.localScale.y * radiusRadar);
        //установка размера картинки
        _radarBorderSprite.transform.localScale = renderScale;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider != null)
        {
            if (collider.TryGetComponent<Monster>(out var monster))
            {
                onTriggeredMonster?.Invoke();
            }
        }
    }
}
