using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {


    [SerializeField]
    private int remoteLayerName = 10;



    void Start()
    {
        if (!isLocalPlayer)
        {
            AssignRemoteLayer();
        }

        RegisterPlayer();
    }

    //assign an ID for the Player
    void RegisterPlayer()
    {
        string _ID = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
    }



    void AssignRemoteLayer()
    {
        gameObject.layer = remoteLayerName;
    }

}
