using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    GameObject player;
    bool playerInRange;

    public int startingHealth = 6;
    [SyncVar]
    public int currentHealth;

    public int attackDamage = 1;

    public Sprite[] HeartSprites;
    private Image HeartUI;

    bool isDead;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        HeartUI.sprite = HeartSprites[6];
    }
	
	// Update is called once per frame
	void Update () {

        if (playerInRange)
        {
            Attack();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
            Debug.Log("PlayerHealth" + " :" + currentHealth);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    //The function TakeDamage will only run on the Server
    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;

        Debug.Log(currentHealth);
        HeartUI.sprite = HeartSprites[currentHealth];

        //Player Death
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }

    }

    void Attack()
    {
        if (currentHealth > 0)
        {
            TakeDamage(attackDamage);
        }
    }
    //if currenthealth = 0 the player dies 
    void Die()
    {
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
