using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnWeapon : NetworkBehaviour
{

    public GameObject[] weapons;
    private Transform[] spawnPoints;
    public Vector3 centerPoint;
    private float screenCenterY;
    private float screenCenterX;

    // Use this for initialization
    void Start()
    {

        //get the position in the middle where the weapons are going to spawn
        screenCenterY = Screen.width;
        screenCenterX = Screen.height;
        Debug.Log("Screen Center: " + "x: " + screenCenterX + "y: " + screenCenterY);


        //fill the array of spawnPoints
        for (int i = 0; i < 20; i++)
        {

        }

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Spawn()
    {
        //random index for a weapon of the weaponArray
        // int index = Random.Range(0, spawnPoints.Length);

        //Instanstiate for the center of the screen - does not work like it should
        //  Instantiate(weapons[Random.Range(0,weapons.Length)], new Vector3(screenCenterX, screenCenterY, 0), Quaternion.identity);

        //Instanstiate at the centerPoint 
        GameObject weapon = Instantiate(weapons[Random.Range(0, weapons.Length)], new Vector3(centerPoint.x, centerPoint.y, centerPoint.z), Quaternion.identity);
        //NetworkServer.Spawn(weapon);
    }

}
