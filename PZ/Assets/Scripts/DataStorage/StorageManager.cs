using System.Collections;
using UnityEngine;

namespace Assets.Scripts.DataStorage
{
    public class StorageManager : MonoBehaviour
    {
        private Storage _storage;
        private GameData _gameData;

        public GameObject testCube;

        private void Start()
        {
            _storage = new Storage();
            Load();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L)) 
                Load();
            if (Input.GetKeyDown(KeyCode.S)) 
                Save();

        }
        private void Save()
        {
            _gameData.PlayerPosition = testCube.transform.position;
            _storage.Save(_gameData);
            Debug.Log("Save game");
        } 
        private void Load()
        {
            _gameData = (GameData)_storage.Load(new GameData());
            Debug.Log("Load game");
            testCube.transform.position = _gameData.PlayerPosition;
            Debug.Log(_gameData.IndexInventorySlot);
            Debug.Log(_gameData.NameIntemInSlot);
            Debug.Log(_gameData.CountItemInSlot);
        }
    }
}