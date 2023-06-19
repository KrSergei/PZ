using UnityEngine;

public class PlayerRadar : MonoBehaviour
{
    public float radiusRadar;

    [SerializeField]
    private new CircleCollider2D collider;

    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.radius = radiusRadar;
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");
    }
}
