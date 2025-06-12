using Cysharp.Threading.Tasks;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    public float offset;

    public SpriteRenderer weaponSpriteRenderer;

    /// <summary>
    /// Поворот оружия по направлению движения джойстика. Принимает параметром текущий джойстик управления
    /// </summary>
    /// <param name="currentJoystick"></param>
    public void RotateWeapon(Joystick currentJoystick)
    {
        float rotateZ = Mathf.Atan2(currentJoystick.Vertical, currentJoystick.Horizontal) * Mathf.Rad2Deg;
        CheckDestination(rotateZ);
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
    }

    async public void RotateWeapon(Vector2 direction)
    {
        //float rotateZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        float rotateZ = Vector2.SignedAngle(Vector2.right, new Vector2(direction.x, direction.y));

        CheckDestination(rotateZ);
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        await UniTask.CompletedTask;
    }

    /// <summary>
    /// Инверсия изображения оружия в зависимости от угла поворота джойстика.
    /// </summary>
    /// <param name="angle"></param>
    private void CheckDestination(float angle)
    {
        if (angle >= 90f || angle <= - 90f)
            weaponSpriteRenderer.flipY = true;      
        else
            weaponSpriteRenderer.flipY = false;
    }
}
