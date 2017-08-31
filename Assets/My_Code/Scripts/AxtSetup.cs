using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AxtSetup : NetworkBehaviour {

    //Zerstört die Waffe, das gameobject auf dem das script liegt 
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();

        //falls die waffe auf ein gamobject mit dem tag player trifft, ziehe ihm leben ab
        if(health != null && collision.gameObject.tag == "Player")
        {
            health.TakeDamage(10);
        }

    }
     
}
