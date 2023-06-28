
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private bool isTargetDetected;
    [SerializeField] private float speed;
    [SerializeField] private GameObject targetPosition;
    void Update()
    {
        if (isTargetDetected)
        {
            Vector3 direction = targetPosition.transform.position - transform.position;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    public void IsTargetLocked(GameObject target)
    {
        targetPosition = target;
        isTargetDetected = true;
    }
}
