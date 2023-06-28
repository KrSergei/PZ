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
    /// ��������� ������ ������ � ����������� �� �������
    /// </summary>
    private void SetSizeRadarBorder()
    {
        //��������� ������� ����������
        _collider.radius = radiusRadar;
        //���������� ������� ��� ���������������
        Vector2 renderScale = new(_radarBorderSprite.localScale.x * radiusRadar, _radarBorderSprite.localScale.y * radiusRadar);
        //��������� ������� ��������
        _radarBorderSprite.transform.localScale = renderScale;
    }

    private void FixedUpdate()
    {

        //���� ���� ����, ���������� ������������ �������� ������ 0
        if (_lokedMonster > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(shootSpot.position, shootSpot.transform.right, radiusRadar * 5, layer);
            //���� ��� ���������� � ����������� �������, �� ������� �������
            if (hit.collider != null) onLokedMonster?.Invoke();
        }
    } 

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //��������� ���������� �������������� ��������
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
        //��������� ���������� �������������� ��������
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