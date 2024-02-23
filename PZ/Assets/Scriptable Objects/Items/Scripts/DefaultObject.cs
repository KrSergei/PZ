using UnityEngine;

[CreateAssetMenu(fileName ="New Defaul Object", menuName = "Inventory/Items/Default")]
public class DefaultObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
