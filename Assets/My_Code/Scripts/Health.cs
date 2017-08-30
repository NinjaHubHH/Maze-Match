using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{

    bool playerInRange;

    public const int startingHealth = 3;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth;

    public Sprite[] HeartSprites;
    public Image HeartUI;

    bool isDead;

    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
        Debug.Log("Players current Health is " + currentHealth);

    }

    void Update()
    {
        if (isLocalPlayer)
        {
            CheckForAttack();
        }
    }


    void OnTriggerEnter2D(Collider2D other) // Only for Testing and debugging
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
            CmdHitPlayer(GameObject.Find("WeaponManager").GetComponent<WeaponManager>().attackDamage);
        }
    }

    [Command]
    void CmdHitPlayer(int amount)
    {
        Debug.Log("cmdHitPlayer wurde ausgeführt vorm server");
        Debug.Log("Angriffsstärke " + amount);

        if (isServer)
        {
            Debug.Log("cmdHitPlayer wurde ausgeführt");
            Vector2 vector2 = GetComponent<PlayerMovement>().actualDirection;  //holt sich die Richtung in die der Spieler guckt für den Raycast
            Vector3 vector3 = new Vector3(vector2.x, vector2.y, 0); //nur für Debug drawLine
            RaycastHit2D hit = Physics2D.Raycast(transform.position, vector2);  //Raycast von der aktuellen position, in Richtung in die der Spieler guckt
            Debug.DrawLine(transform.position, vector3);

            if (hit.collider != null) 
            {
                Health healthComponent = hit.collider.GetComponent<Health>();
                healthComponent.currentHealth -= amount;    //ziehe dem vom raycast getroffenen Player Leben ab
                Debug.Log(hit.collider.name + " got " + healthComponent.currentHealth + " health.");


                //Player Death
                if (healthComponent.currentHealth <= 0 && !isDead)
                {
                    Die(hit.collider.name);
                    Debug.Log(hit.collider.name + " ist gestorben");
                }
            }
        }
    }


    void OnChangeHealth(int currentHealth)
    {
        HeartUI.sprite = HeartSprites[currentHealth];
    }

    void Die(string player)
    {
        isDead = true;
        if (isServer)
        {
            if (player == "Player 2") //player id abfrage
            {
                SceneManager.LoadScene("Win", LoadSceneMode.Additive); //hier müsste eine meldung oder scene kommen, in der steht, dass der spieler gewonnen hat
            }
            if (player == "Player 1") //player id abfrage
            {
                SceneManager.LoadScene("Death", LoadSceneMode.Additive); //hier müsste eine meldung oder scene kommen, in der steht, dass Spieler verloren hat
            }
        }

    }
}
