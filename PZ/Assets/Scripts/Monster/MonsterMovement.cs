using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private bool isTargetDetected;
    [SerializeField] private float speed;
    [SerializeField] private GameObject targetPosition;
    private Vector3 _currentDirection;
    void Update()
    {
        if (isTargetDetected)
        {
            Vector3 direction = targetPosition.transform.position - transform.position;
            transform.Translate(speed * Time.deltaTime * direction, Space.World);
            _currentDirection = direction;
        }
    }

    public void IsTargetLocked(GameObject target)
    {
        targetPosition = target;
        isTargetDetected = true;
    }


    public Vector3 GetCurrentDestination()
    {
        return _currentDirection;
    } 
}
