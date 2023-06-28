using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo Object", menuName = "Inventory/Items/Ammo")]
public class AmmoObject : ItemObject
{
    public GameObject prefabDealingDamage;
    public int damageValue;

    public void Awake()
    {
        type = ItemType.Ammo;
    }
}
