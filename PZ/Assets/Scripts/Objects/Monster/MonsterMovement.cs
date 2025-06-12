using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private bool isTargetDetected;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 targetPosition;
    private Vector3 _currentDirection;
    void Update()
    {
        if (isTargetDetected)
        {
            Vector3 direction = targetPosition - transform.position;
            transform.Translate(speed * Time.deltaTime * direction, Space.World);
            _currentDirection = direction;
        }
    }



    public void IsTargetLocked(Vector3  targetPosition)
    {
        this.targetPosition = targetPosition;
        isTargetDetected = true;
    }


    public Vector3 GetCurrentDestination()
    {
        return _currentDirection;
    } 
}
