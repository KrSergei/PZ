using UnityEngine;
public enum ItemType
{
    Ammo,
    Equipment,
    Default,
    Monster
}

public abstract class ItemObject : ScriptableObject
{
    public string Name;
    public GameObject prefab;
    public Sprite itemIcon;
    public ItemType type;
    [TextArea(15, 20)]
    public string decsription;
}
