using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

    public float speed ;
    private Rigidbody2D player;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> (); 

	}
	
	// Update is called once per frame
	void Update () {

		// trigger animations
		if (Input.GetKey ("s")) {
			animator.SetBool ("playerDown", true);
		} 
		else { animator.SetBool ("playerDown", false);
		}
		if (Input.GetKey ("w")) {
			animator.SetBool ("playerUp", true);
		} 
		else { animator.SetBool ("playerUp", false);
		}
		if (Input.GetKey ("a")) {
			animator.SetBool ("playerLeft", true);
		} 
		else { animator.SetBool ("playerLeft", false);
		}

		if (Input.GetKey ("d")) {
			animator.SetBool ("playerRight", true);
		} 
		else { animator.SetBool ("playerRight", false);
		}
		if (Input.GetKeyDown ("f")) {
			animator.SetTrigger ("hitAni");
		} 



        if (!isLocalPlayer)
        {
            return;
        }

        player = GetComponent<Rigidbody2D>();

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        player.velocity = new Vector2(moveHorizontal , moveVertical) * speed * 2;



    }
}
