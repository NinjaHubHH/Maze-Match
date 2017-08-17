using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class HostGame : MonoBehaviour {

    [SerializeField]
    private uint roomSize = 2; // player count in the room

    private string roomName;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker(); //enable the matchmaker check
        }
    }

    public void SetRoomName (string _name)
    {
        roomName = _name; //set the room name to the input field input
    }

    public void CreateRoom()
    {
        if(roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room" + roomName + "with room for" + roomSize + "player.");
            //Create room
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "","","",0,0, networkManager.OnMatchCreate);
        }
    }

}
