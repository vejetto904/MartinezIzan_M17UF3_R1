using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Serializable]
    public class World
    {
        public PlayerData _playerData;
    }
    [Serializable]
    public class PlayerData
    {
        public float posX;
        public float posY;
        public float posZ;
        public float health;
        public PlayerInventory playerInventory;
    }
    [Serializable]
    public class PlayerInventory
    {
        public string[] items;
        public PlayerInventory(string[] items)
        {
            this.items = items;
        }
    }

    World _world;

    private void Awake()
    {
        try
        {
            //Read the json file
            StreamReader sr = File.OpenText("./Assets/Scripts/Data.json");
            string content = sr.ReadToEnd();
            sr.Close();
            _world = JsonUtility.FromJson<World>(content);
            //if(_world._playerData.playerInventory.items.Length > 0) InventoryItems.Instance.checkInventory(_world._playerData.playerInventory.items);
            //MainPlayer.Instance.setPlayer(_world._playerData.positionX, _world._playerData.positionY, _world._playerData.positionZ, _world._playerData.health);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    public void saveData()
    {
        //Update player data at this time
        _world._playerData.posX = PlayerInputs.instance.transform.position.x;
        _world._playerData.posY = PlayerInputs.instance.transform.position.y;
        _world._playerData.posZ = PlayerInputs.instance.transform.position.z;
        //_world._playerData.health = PlayerInputs.instance.player.health;
        string[] inventory = Inventory.instance.getCurrentInventory();
        _world._playerData.playerInventory = new PlayerInventory(inventory);

        try
        {
            StreamWriter sw = new StreamWriter("./Assets/Scripts/Data.json");
            string json = JsonUtility.ToJson(_world);
            sw.WriteLine(json);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
