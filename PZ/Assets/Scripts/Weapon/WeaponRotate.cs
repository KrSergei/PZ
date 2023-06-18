using UnityEngine;

public class WeaponRotate : MonoBehaviour
{

    public float maxAngleRotate = 50f;
    public float speedRotate;

    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private Transform _target;



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void RotateWeapon(Vector3 currentAngle)
    {
        float angle = Vector3.Angle(currentAngle, _weapon.transform.position);
        if (angle <= maxAngleRotate || angle > 130 || angle < 180)
        {
           //transform.LookAt(_target);
        }
        else Debug.Log("Border angle");
    }
}
