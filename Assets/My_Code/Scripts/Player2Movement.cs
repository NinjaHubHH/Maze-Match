using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{

    public float speed = 0.1f;
    private Rigidbody2D player;

    // Use this for initialization
    void Start()
    {

        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector2.up * speed);
        }

        //float move = Input.GetAxis("Horizontal");

        //player.velocity = new Vector2(move * speed, player.velocity.y);

        // transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime,speed * Input.GetAxis("Vertical") * Time.deltaTime, 0f);

    }
}
