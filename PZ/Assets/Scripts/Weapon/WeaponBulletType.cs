using UnityEngine;

public class WeaponBulletType : MonoBehaviour
{
    public AmmoObject bullet;

    public GameObject GetBulletPrefab()
    {
        return bullet.prefab;
    }

    public int GetBulletDamage()
    {
        return bullet.damageValue;
    }
}
