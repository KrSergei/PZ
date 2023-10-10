using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private bool isTargetDetected;
    [SerializeField] private float speed;
    [SerializeField] private GameObject targetPosition;
    private Vector3 _currentdestination;
    void Update()
    {
        if (isTargetDetected)
        {
            Vector3 direction = targetPosition.transform.position - transform.position;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            _currentdestination = direction;
        }
    }

    public void IsTargetLocked(GameObject target)
    {
        targetPosition = target;
        isTargetDetected = true;
    }


    public Vector3 GetCurrentDestination()
    {
        return _currentdestination;
    } 
}
