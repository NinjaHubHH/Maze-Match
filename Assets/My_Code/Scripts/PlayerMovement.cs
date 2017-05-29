using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {

        speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {

        
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime,speed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);

    }
}
