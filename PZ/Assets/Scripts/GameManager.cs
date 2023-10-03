using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int startAmount;
    public Pool pool;
    public GameObject monsterSpawner;

    private void Start()
    {
        GetItem();
    }

    public void GetItem()
    {
        for (int i = 0; i < startAmount; i++)
        {
            pool.Init(GetPosition());
        }
    }

    private Vector3 GetPosition()
    {
        float sizeX = monsterSpawner.GetComponent<BoxCollider2D>().size.x;
        float sizeY = monsterSpawner.GetComponent<BoxCollider2D>().size.y;
        Vector3 position =  new Vector3(Random.Range(sizeX * -0.5f, sizeX * 0.5f), Random.Range(sizeY * -0.5f, sizeY * 0.5f), 0f);
           
        return transform.position = position;
    }
}
