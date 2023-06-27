using UnityEngine;
using UnityEngine.Events;

public class ButtonDoDelete : MonoBehaviour
{
    [Header("Event")]
    [SerializeField] private EvenInt onDoDelete;

    public void DoDelete()
    {
        onDoDelete?.Invoke(GetComponentInParent<ButtonDelete>().indexButton);
    }
}
[System.Serializable]
public class EvenInt : UnityEvent<int> { }