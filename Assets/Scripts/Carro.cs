using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour {

    public WheelCollider[] colisoresroda;

    float eixoapertado = 0f;
    float aceleracao;
    Rigidbody rb;
    public float forçaparar;
    public float força;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void Update () {
        eixoapertado = Input.GetAxis("Horizontal");
        aceleracao = Input.GetAxis("Vertical");
	}

    private void FixedUpdate()
    {
        for (int i = 0; i < colisoresroda.Length; i++)
        {
            colisoresroda[i].steerAngle = eixoapertado * 15f;
            colisoresroda[i].motorTorque = 1f;
        }

        if(aceleracao< -.5f)
        {
            rb.AddForce(-transform.forward * forçaparar);
            aceleracao = 0;
        }

        rb.AddForce(transform.forward * aceleracao * força);
    }
}
