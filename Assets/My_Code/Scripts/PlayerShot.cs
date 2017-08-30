using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShot : NetworkBehaviour {


    public GameObject axtShot;
    public Transform axtSpawn;
    public Vector2 vector2;


    void Start () {
        vector2 = GetComponent<PlayerMovement>().actualDirection;  //holt sich die Richtung in die der Spieler guckt
    }
	
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetButtonDown("Fire"))
        {
            CmdFire();
        }

    }

    [Command]
    void CmdFire()
    {
        GameObject axt = Instantiate(axtShot, axtSpawn.position, axtSpawn.rotation);
        axt.GetComponent<Rigidbody2D>().velocity = axt.transform.right * 15; // edit here
        NetworkServer.Spawn(axt);
        Destroy(axt, 6.0f);  //zerstört nach 6 sekunden das GameObject
    }
}
