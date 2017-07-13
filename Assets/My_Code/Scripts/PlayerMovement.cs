using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed ;
    private Rigidbody2D player;

	// Use this for initialization
	void Start () {

        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        player.velocity = new Vector2(moveHorizontal * speed * 2, moveVertical * speed * 2);

    }
}
