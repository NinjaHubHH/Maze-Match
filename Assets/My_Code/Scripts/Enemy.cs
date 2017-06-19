using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int attackDamage = 1;

    public GameObject player;
    Player playerHealth;
    bool playerInRange;

	void Awake () {

        player = GameObject.FindGameObjectWithTag("Character");
        playerHealth = player.GetComponent<Player>();
	}

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


	
	// Update is called once per frame
	void Update () {
		
        if (playerInRange)
        {
            Attack();
        }
      //  if(playerHealth.currentHealth <= 0)
      //  {
            //animator settings here "Deathclip"
      //  }

	}

    void Attack()
    {
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
