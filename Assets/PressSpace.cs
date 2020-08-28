using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpace : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.jogador.PodeEntrar == true)
        {
            gameObject.SetActive(true);
            print("verdadeiro!!");
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
