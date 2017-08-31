using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{

    public float speed;
    private Rigidbody2D player;
    private Animator animator;
    private ParticleSystem particle;

    [SyncVar]
    public Vector2 actualDirection;

    //position of where the axe will be spawn. it changes the transform with the players rotation
    [SyncVar]
    public Transform axtSpawn;

    public RuntimeAnimatorController anim1;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!isLocalPlayer)
        {
            return;
        }

        //Player Movement 
        player = GetComponent<Rigidbody2D>();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        player.velocity = new Vector2(moveHorizontal, moveVertical) * speed * 2;

        if (player.velocity.magnitude > 1.4f)
        {

            particle.enableEmission = true;
        }
        else
        {
            particle.enableEmission = false;
        }

        TriggerAnimations();

    }


    void TriggerAnimations()
    {
        // trigger animations
        if (Input.GetKey("s"))
        {
            animator.SetBool("playerDown", true);
            actualDirection = new Vector2(0, -1);
            axtSpawn.position = new Vector3(player.transform.position.x, player.transform.position.y - 25, 0);

        }
        else
        {
            animator.SetBool("playerDown", false);
        }

        if (Input.GetKey("w"))
        {
            animator.SetBool("playerUp", true);
            actualDirection = new Vector2(0, 1);
            axtSpawn.position = new Vector3(player.transform.position.x, player.transform.position.y + 25, 0);
        }
        else
        {
            animator.SetBool("playerUp", false);
        }
        if (Input.GetKey("a"))
        {
            animator.SetBool("playerLeft", true);
            actualDirection = new Vector2(-1, 0);
            axtSpawn.position = new Vector3(player.transform.position.x - 20, player.transform.position.y, 0);
        }
        else
        {
            animator.SetBool("playerLeft", false);
        }

        if (Input.GetKey("d"))
        {
            animator.SetBool("playerRight", true);
            actualDirection = new Vector2(1, 0);
            axtSpawn.position = new Vector3(player.transform.position.x + 15, player.transform.position.y, 0);
        }
        else
        {
            animator.SetBool("playerRight", false);
        }
        if (Input.GetKeyDown("f"))
        {
            animator.SetBool("hitAni", true);
        }
        else
        {
            animator.SetBool("hitAni", false);
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<Animator>().runtimeAnimatorController = anim1 as RuntimeAnimatorController;

    }
}
