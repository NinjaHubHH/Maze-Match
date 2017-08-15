using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public Transform[] playerPrefabs;

    public void OnServerInit()
    {
        Network.Instantiate(player1Prefab, transform.position, transform.rotation, 0);
    }


    public void OnClientConnect()
    {
        Network.Instantiate(player2Prefab, transform.position, transform.rotation, 0);
    }
}
