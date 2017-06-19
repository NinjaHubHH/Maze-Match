using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameObject currentInteractableObj = null;
    public Sprite spriteSword;
    GameObject weapon;
    GameObject player;
    public int startingHealth = 6;
    public int currentHealth;

    public Sprite[] HeartSprites;
    public Image HeartUI;

    bool isDead;

    // Called in the beginning
    void Awake () {

        currentHealth = startingHealth;
        HeartUI.sprite = HeartSprites[6];
    }
	
	// Update is called once per frame
	void Update () {

        //Function if you press button e to pick up a weapon/object
        if (Input.GetButtonDown("Interact") && currentInteractableObj)
        {
        }


	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interactableO"))
        {
            Debug.Log(other.name);
            currentInteractableObj = other.gameObject;
            Destroy(other.gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteSword;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        HeartUI.sprite = HeartSprites[currentHealth];

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

    void Die()
    {
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
