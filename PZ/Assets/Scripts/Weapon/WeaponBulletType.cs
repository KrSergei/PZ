using UnityEngine;

public class WeaponBulletType : MonoBehaviour
{
    public AmmoObject bullet;

    public GameObject GetBulletPrefab()
    {
        return bullet.prefabDealingDamage;
    }

    public int GetBulletDamage()
    {
        return bullet.damageValue;
    }
}
