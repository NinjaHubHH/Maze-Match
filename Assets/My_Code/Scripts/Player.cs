using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Player : NetworkBehaviour {

    public GameObject currentInteractableObj = null;
    GameObject weapon;
    GameObject player;
    Player playerHealth;
    public int startingHealth = 6;
    public int currentHealth;

    public int attackRate = 1;

    public Sprite[] HeartSprites;

    bool isDead;

	public RuntimeAnimatorController animWeapon;


	//public RuntimeAnimatorController animatorController;


    // Called in the beginning
    void Awake () {

        currentHealth = startingHealth;


    }

	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }

        //Function if you press button e to pick up a weapon/object
        if (Input.GetButtonDown("Interact") && currentInteractableObj)
        {
            //not used yet
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if an Object with the Tag "interactableO" is triggered then destroy this object(to hide it) and change the sprite
        if (other.CompareTag("interactableO"))
        {
            Debug.Log(other.name);
            currentInteractableObj = other.gameObject;
            Destroy(other.gameObject);
           	
			gameObject.GetComponent<Animator> ().runtimeAnimatorController = animWeapon as RuntimeAnimatorController; 

        }
    }
    public void Attack()
    {
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackRate);
        }
    }


    //Enemy calls this function when he damaged the player
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        Debug.Log(currentHealth);
       // HeartUI.sprite = HeartSprites[currentHealth];

        //Player Death
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interactableO"))
        {
            if (other.gameObject == currentInteractableObj)
            {
                currentInteractableObj = null;
            }
        }
    }

    //if currenthealth = 0 the player dies 
    void Die()
    {
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
