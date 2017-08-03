using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    public float speed ;
    private Rigidbody2D player;

	// Use this for initialization
	void Start () {

        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!isLocalPlayer)
        {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        player.velocity = new Vector2(moveHorizontal , moveVertical) * speed * 2;

    }
}
