using UnityEngine;

public class PlayerDoShoot : MonoBehaviour
{    

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Debug.Log("Do Shoot space");
    }
}
