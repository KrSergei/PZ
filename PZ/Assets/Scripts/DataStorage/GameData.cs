using System;
using UnityEngine;

[Serializable]
public class GameData 
{
    private Vector3 _playerPosition;
    private int _indexInventorySlot;
    private string _nameIntemInSlot;
    private int _countItemInSlot;


    public Vector3 PlayerPosition { get => _playerPosition; set => _playerPosition = value; }
    public int IndexInventorySlot { get => _indexInventorySlot; set => _indexInventorySlot = value; }
    public string NameIntemInSlot { get => _nameIntemInSlot; set => _nameIntemInSlot = value; }
    public int CountItemInSlot { get => _countItemInSlot; set => _countItemInSlot = value; }


    public GameData() 
    {
        PlayerPosition = Vector3.zero;
        IndexInventorySlot = 0;
        NameIntemInSlot = "ammo";
        CountItemInSlot = 100;
    }
}
