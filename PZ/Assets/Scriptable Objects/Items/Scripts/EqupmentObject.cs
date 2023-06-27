using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory/Items/Equipment")]

public class EqupmentObject : ItemObject
{
    public int attackBonusValue;
    public int defenceValue;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
