using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AxtSetup : NetworkBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();

        if(health != null && collision.gameObject.tag == "Player")
        {
            health.TakeDamage(10);
        }

    }
     
}
