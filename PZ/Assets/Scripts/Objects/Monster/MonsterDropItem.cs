using UnityEngine;

public class MonsterDropItem : MonoBehaviour
{
    public ItemsPools items;

    private void Awake()
    {
        items = FindObjectOfType<ItemsPools>();
    }

    public void DropItem()
    {        
        items.SpawnChoicedItemsPool(GetRandom(), transform.position);
    }

    private int GetRandom()
    {
        return Random.Range(0, items.GetAmounItems() -1);
    }
}
