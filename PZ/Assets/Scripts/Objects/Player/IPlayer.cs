using System;
using UnityEngine;

public interface IPlayer 
{
    event Action OnDeath;

    void Move(Vector2 direction, float deltatime);

    Vector2 GetPosition();
}
