using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Player : NetworkBehaviour
{
    [SyncVar]
    public GameObject currentInteractableObj = null;

    GameObject weapon;
    GameObject player;

    public RuntimeAnimatorController animWeapon;
    public RuntimeAnimatorController animWeapon2;


    //public RuntimeAnimatorController animatorController;

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }

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

            if (gameObject.layer == 9)
            {
                Debug.Log(other.name);
                currentInteractableObj = other.gameObject;
                Destroy(other.gameObject);
                gameObject.GetComponent<Animator>().runtimeAnimatorController = animWeapon as RuntimeAnimatorController;
            }
            else
            {
                Debug.Log(other.name);
                currentInteractableObj = other.gameObject;
                Destroy(other.gameObject);
                gameObject.GetComponent<Animator>().runtimeAnimatorController = animWeapon2 as RuntimeAnimatorController;
            }

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
}
