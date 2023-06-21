using Cysharp.Threading.Tasks;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float lifeTime;

    void Start()
    {
        Deactivate();
    }

    private async void Deactivate()
    {
        Debug.Log((int)lifeTime);
        await UniTask.Delay((int)lifeTime);
        
        gameObject.SetActive(false);
        ObjectPool.instance.AddBulletToStorage(gameObject);       
    } 
}