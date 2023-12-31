using UnityEngine;

public class MonsterRotate : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] _monsterRenderers; //������ �������� ��� �������� 
   

    void Start()
    {
        _monsterRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    /// <summary>
    /// �������� � ������� � ����������� �� ����� ���������� �� ��� �. ���� ���� ����� ��� ������ 0, �� ������� ������, ����� ������� �����
    /// </summary>
    private void Rotate()
    {
        Vector3 currentDirection = GetComponent<MonsterMovement>().GetCurrentDestination();
        if (currentDirection.x >= 0)
        {
            foreach (var renderer in _monsterRenderers) renderer.flipX = true;
        }
        else
        {
            foreach (var renderer in _monsterRenderers) renderer.flipX = false;
        }
    }
}
