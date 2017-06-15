using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public GameObject currentInteractableObj = null;
    public Sprite spriteSword;
    GameObject weapon;
    GameObject player;
    public int startingHealth = 6;
    public int currentHealth;

    	// Use this for initialization
	void Start () {

        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

        //Function if you press button e to pick up a weapon/object
        if (Input.GetButtonDown("Interact") && currentInteractableObj)
        {
        }

        //Player Death
        if (currentHealth <= 0)
        {
            Die();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
