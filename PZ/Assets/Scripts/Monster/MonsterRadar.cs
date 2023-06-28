using UnityEngine;
using UnityEngine.Events;

public class MonsterRadar : MonoBehaviour
{
    public UnityEvent<GameObject> onPlayerDetected;
    public GameObject target;

    public float radiusRadar;
    public CircleCollider2D _collider;

    void Start()
    {
        _collider.radius = radiusRadar;
    }

    // Update is called once per frame
  

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {            
            if (collider.TryGetComponent<PlayerCollision>(out var player))
            {
                target = player.gameObject;
                onPlayerDetected?.Invoke(target);
            }
        }
    }
}
