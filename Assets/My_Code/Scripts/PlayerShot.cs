using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShot : NetworkBehaviour {


    public GameObject axtShot;
    private Transform axtSpawnForShoot;
    public Vector2 vector2;


    void Start () {

    }
	
	void Update () {

        axtSpawnForShoot = GetComponent<PlayerMovement>().axtSpawn;

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
        vector2 = GetComponent<PlayerMovement>().actualDirection;  //holt sich die Richtung in die der Spieler guckt
        Debug.Log("Richtung Spieler: " + vector2);

        GameObject axt = Instantiate(axtShot, axtSpawnForShoot.position, axtSpawnForShoot.rotation);
        axt.GetComponent<Rigidbody2D>().velocity = new Vector2(vector2.x, vector2.y) * 40; 
        NetworkServer.Spawn(axt);
        Destroy(axt, 6.0f);  //zerstört nach 6 sekunden das GameObject
    }
}
