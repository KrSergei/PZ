using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monster/SimpleMonster")]
public class MonsterObject : ItemObject
{
    public int damage;
    public int health;
    public float speed;
    public void Awake()
    {
        type = ItemType.Monster;
    }
}
