using UnityEngine;
using Zenject;

public class MoveController : IFixedTickable
{
    private readonly IPlayer _player;
    private readonly IMoveInput _moveInput;
    
    public MoveController(IPlayer player, IMoveInput moveInput)
    {
        _player = player;
        _moveInput = moveInput;
    }

    void IFixedTickable.FixedTick()
    {
        this._player.Move(this._moveInput.GetDirection(), Time.fixedDeltaTime);
    }
}
