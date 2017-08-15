using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameObject currentInteractableObj = null;
   // public Sprite spriteSword;
    GameObject weapon;
    GameObject player;
    public int startingHealth = 6;
    public int currentHealth;

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

        //Function if you press button e to pick up a weapon/object
        if (Input.GetButtonDown("Interact") && currentInteractableObj)
        {
            //not used yet
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
