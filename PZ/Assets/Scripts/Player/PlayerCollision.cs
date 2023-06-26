using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public InventoryObject inventory;

    [Header("Events")]
    [SerializeField] EvenGameObj onCollisionPlayer;
    
    private void OnTriggerEnter2D(Collider2D collaider)
    {
        //if (collaider.gameObject.TryGetComponent<Item>(out var item))
        //{
        //    Debug.Log("Collision");
        //    onCollisionPlayer?.Invoke(collaider.gameObject);

        //}
        onCollisionPlayer.Invoke(collaider.gameObject);
        //var _item = collaider.GetComponent<Item>();
        //if (_item)
        //{
        //    inventory.AddItem(_item.item, 1);
        //    //ToDo back to objectpool
        //    collaider.gameObject.SetActive(false);
        //}

    }
}

[System.Serializable]
public class EvenGameObj : UnityEvent<GameObject> { }
