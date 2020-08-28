using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {
    public float Velocidade;
    
   
	
	void Start () {
        
	}
	
	
	void Update () {

        
        
        
    }
   void OnTriggerEnter(Collider col) {

        if(col.gameObject.tag == "IniciarViagem")
        {
            Player.jogador.PodeEntrar = true;
            
            Player.jogador.PassageiroAtual = col.gameObject.transform.parent.gameObject.GetComponent<Passageiro>();
        }
        if (col.gameObject.tag == "TerminarViagem")
        {
            Player.jogador.PodeEntrar = true;
            Player.jogador.PodeSair = true;
        }

    }
    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "IniciarViagem")
        {
            Player.jogador.PodeEntrar = false;
        }
        if (col.gameObject.tag == "TerminarViagem")
        {
            Player.jogador.PodeSair = false;
        }
    }   

}
