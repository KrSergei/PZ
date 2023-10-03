using UnityEngine;
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
    public ItemType type;
    [TextArea(15, 20)]
    public string decsription;
}
