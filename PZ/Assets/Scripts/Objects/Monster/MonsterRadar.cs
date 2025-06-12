using UnityEngine;
using UnityEngine.Events;

public class MonsterRadar : MonoBehaviour
{
    public UnityEvent<Vector3> onPlayerDetected;
    public Vector3 target;

    public float radiusRadar;
    public CircleCollider2D _collider;

    void Start()
    {
        _collider.radius = radiusRadar;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {            
            if (collider.TryGetComponent<PlayerCollision>(out var player))
            {
                target = player.transform.position;
                onPlayerDetected?.Invoke(target);
            }
        }
    }
}
