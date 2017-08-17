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
    }

    void AssignRemoteLayer()
    {
        gameObject.layer = remoteLayerName;
    }

}
