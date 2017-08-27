using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{

    GameObject player;
    bool playerInRange;

    public int startingHealth = 100;
    [SyncVar]
    public int currentHealth;

    public Sprite[] HeartSprites;
    private Image HeartUI;

    bool isDead;
    float maxDistance = 15f;

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
        Debug.Log("Players current Health is " + currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (isLocalPlayer)
        {
            CheckForAttack();
        }

        if (playerInRange)
        {
            //Attack(); old attack method
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You hit " + other.name);

        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            Debug.Log("Player in Range = " + playerInRange);


        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void CheckForAttack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Debug.Log("You hit the button for attack ");
        //    CmdHitPlayer(GameObject.Find("WeaponManager").GetComponent<WeaponManager>().attackDamage);
            CmdHitPlayer(10);
        }
    }

    [Command]
    void CmdHitPlayer(int amount)
    {
        Debug.Log("cmdHitPlayer wurde ausgeführt vorm server check");
        Debug.Log(amount);
        if (isServer)
        {
            Debug.Log("cmdHitPlayer wurde ausgeführt");
            Vector2 vector2 = GetComponent<PlayerMovement>().actualDirection;
            Vector3 vector3 = new Vector3(vector2.x, vector2.y, 0);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, vector2);
            Debug.DrawLine(transform.position,vector3);
            if (hit.collider != null)
            {
                // hit.transform.gameObject.GetComponent<Health>().currentHealth -= 11; //für testzwecke 
                hit.collider.GetComponent<Health>().currentHealth -= amount;    //ziehe dem vom raycast getroffenen Player Leben ab
                Debug.Log(transform.name + " got " + hit.collider.GetComponent<Health>().currentHealth + " health.");


            }

            //Player Death
            if (currentHealth <= 0 && !isDead)
            {
                Die();
            }
        }
    }

    ////The function TakeDamage will only run on the Server
    //[Command]
    //public void CmdTakeDamage(int amount)
    //{
    //    if (!isServer)
    //    {
    //        return;
    //    }

    //    currentHealth -= amount;

    //    Debug.Log(currentHealth);
    //    HeartUI.sprite = HeartSprites[currentHealth];

    //    //Player Death
    //    if (currentHealth <= 0 && !isDead)
    //    {
    //        Die();
    //    }

    //}

    //void Attack()
    //{
    //    if (currentHealth > 0)
    //    {
    //        CmdTakeDamage(attackDamage);
    //    }
    //}

    //if currenthealth = 0 the player dies 
    void Die()
    {
        isDead = true;
        SceneManager.LoadScene("Death", LoadSceneMode.Additive);
    }
}
