using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerRadar.onTriggeredMonster += DoShoot;
    }
    private void OnDisable()
    {
        PlayerRadar.onTriggeredMonster -= DoShoot;
    }

    private void DoShoot()
    {

    }
}
