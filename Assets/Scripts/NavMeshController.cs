using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Transform destino;
    
    Transform initial;
    void Start()
    {
        initial = transform;
    }

    void Update()
    {

        transform.position = initial.position;
        //OnDrawGizmosSelected();

        agent.SetDestination(destino.position);
       // print(agent.remainingDistance);
        //StartCoroutine(Calculardist(agent));
    }

    private IEnumerator Calculardist(NavMeshAgent agent)
    {
        if (agent.pathPending)
        {
            yield return null;
        }


        else
        {
            float distancia = agent.remainingDistance;
            print(distancia);

        }


    }
}


