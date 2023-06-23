using UnityEngine;

public class PlayerRotate : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer[] _playerSpriteRenderers; //массив спрайтов дл€ поворота (включает в себ€ тело игорока и его оружие)

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
    /// ѕроверка и поворот персонажжа в зависимости от знака координаты по оси ’. ≈сли угол равен или больше 0, по поворот вправо, ниче поворот влево
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
