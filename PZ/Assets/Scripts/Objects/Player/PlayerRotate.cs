using UnityEngine;

public class PlayerRotate : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer[] _playerSpriteRenderers; //������ �������� ��� �������� (�������� � ���� ���� ������� � ��� ������)

    [SerializeField]
    private PlayerController _playerController;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    /// <summary>
    /// �������� � ������� ���������� � ����������� �� ����� ���������� �� ��� �. ���� ���� ����� ��� ������ 0, �� ������� ������, ���� ������� �����
    /// </summary>
    private void Rotate()
    {
        if (_playerController.ResultDestination.x >= 0)
        {
            foreach (var renderer in _playerSpriteRenderers) renderer.flipX = false;
        }
        else
        {
            foreach (var renderer in _playerSpriteRenderers) renderer.flipX = true;
        }
    }
}
