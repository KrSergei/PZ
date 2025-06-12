using UnityEngine;
using Zenject;

public class SceneInstallers : MonoInstaller
{
    [SerializeField]
    private MoveInput _moveInput;

    [SerializeField]
    private Vector3 _cameraOffset = new Vector3(0, 0, -10);

    public override void InstallBindings()
    {
        this.Container
             .Bind<IPlayer>()
             .FromComponentInHierarchy()
             .AsSingle();

        this.Container
            .Bind<Camera>()
            .FromComponentInHierarchy()
            .AsSingle()
            .WithArguments(_cameraOffset);
    }
}

