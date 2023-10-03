using UnityEngine;

public class MonsterDropItem : MonoBehaviour
{
    public Items items;
    private void Awake()
    {
        items = FindObjectOfType<Items>();
    }
    public void DropRandomItem()
    {
        items.DropChoicedItemsPool(GetRandom(), transform.position);
    }

    private int GetRandom()
    {
        return Random.Range(0, items.GetAmounItems() -1);
    }
}
