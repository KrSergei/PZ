using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private EvenGameObj onCollisionPlayer;
    
    private void OnTriggerEnter2D(Collider2D collaider)
    {
        onCollisionPlayer.Invoke(collaider.gameObject);
    }
}

[System.Serializable]
public class EvenGameObj : UnityEvent<GameObject> { }
