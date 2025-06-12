using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private Joystick _joystick;

    [SerializeField]
    private Vector3 _cameraOffset = new Vector3(0, 0, -10);

    public override void InstallBindings()
    {
        this.Container
            .Bind<Camera>()
            .FromComponentInHierarchy()
            .AsSingle();

        this.Container
            .Bind<Joystick>()
            .FromInstance(this._joystick)
            .AsSingle();

        this.Container
             .Bind<IPlayer>()
             .FromInstance(this._player)
             .AsSingle()
             .WithArguments(this._joystick);

        //this.Container
        //    .BindInterfacesTo<CameraMovement>()
        //    .AsCached()
        //    .WithArguments(this._cameraOffset);


        this.Container
           .Bind<IMoveInput>()
           .To<MoveInput>()
           .AsSingle();

        this.Container
            .BindInterfacesAndSelfTo<MoveController>()
            .AsCached();
    }
}
