using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Ammo,
    Equipment,
    Defaault,
    Monster
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite itemIcon;
    public ItemType type;
    [TextArea(15, 20)]
    public string decsription;
}
