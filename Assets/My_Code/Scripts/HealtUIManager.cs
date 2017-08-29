using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtUIManager : MonoBehaviour {


	public Sprite[] HeartSpritesP1;
	public Sprite[] HeartSpritesP2;
	public Image HeartUI1;
	public Image HeartUI2;

	public static int health; 


	// Use this for initialization


	void Start () {

		//player1 = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Health> (); 
	}
	
	// Update is called once per frame
	void Update () {

		//if (gameObject.layer == 9) {
			HeartUI1.sprite = HeartSpritesP1 [health]; 
		//}
		//if (gameObject.layer == 10) {
			HeartUI2.sprite = HeartSpritesP2 [health]; 
		//}


		
	}
}
