using UnityEngine;

public class MonsterRotate : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer[] _monsterRenderers; //массив спрайтов дл€ поворота 
   

    void Start()
    {
        _monsterRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    /// <summary>
    /// ѕроверка и поворот в зависимости от знака координаты по оси ’. ≈сли угол равен или больше 0, по поворот вправо, ниче поворот влево
    /// </summary>
    private void Rotate()
    {
        Vector3 currentdDstination = GetComponent<MonsterMovement>().GetCurrentDestination();
        if (currentdDstination.x >= 0)
        {
            foreach (var renderer in _monsterRenderers) renderer.flipX = true;
        }
        else
        {
            foreach (var renderer in _monsterRenderers) renderer.flipX = false;
        }
    }
}
