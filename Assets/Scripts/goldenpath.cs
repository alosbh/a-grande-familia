using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class goldenpath : MonoBehaviour
{
    public Transform source;
    public Transform target;
    public NavMeshPath caminho;
    private float elapsed = 0.0f;
    public float dist;
    public float latedist;
    NavMeshAgent pathagent;
    public Text tituloslide;
    public Slider slide;
    public Text titulopreço;
    public Text preço;

    public float valor=0;

    static public goldenpath designtrick;
    void Start()
    {
        designtrick = this;
        caminho = new NavMeshPath();
        elapsed = 0.0f;
        pathagent = GetComponent<NavMeshAgent>();
       
        slide.value = 1f;
        
    }

    void Update()
    {
       
        
        if (Player.jogador.emCorrida)
        {
            elapsed += Time.deltaTime;
            if (elapsed > 0.2f)
            {
                elapsed -= .2f;
                NavMesh.CalculatePath(source.position, target.position, NavMesh.AllAreas, caminho);
            }

            dist = PathLength(caminho);
            OnDrawGizmosSelected(caminho);
            valor += Time.deltaTime / 3;
            Player.jogador.addvaloracumulado = valor;
            preço.text = ((int)valor).ToString();
            //print(dist);
            StartCoroutine(Esperar(0.1f));
        }
        
      
    }

    
    void OnDrawGizmosSelected(NavMeshPath caminho)
    {

      
        var line = this.GetComponent<LineRenderer>();
       

       
        line.SetVertexCount(caminho.corners.Length);

        
        for (int i = 0; i < caminho.corners.Length; i++)
        {
            Vector3 poslinha = new Vector3(caminho.corners[i].x, 0.501f, caminho.corners[i].z);
            line.SetPosition(i, caminho.corners[i]);
            
            
        }

    }
    
    float PathLength(NavMeshPath path)
    {
        if (path.corners.Length < 2)
            return 0;

        Vector3 previousCorner = path.corners[0];
        float lengthSoFar = 0.0F;
        int i = 1;
        while (i < path.corners.Length)
        {

            Vector3 currentCorner = path.corners[i];
            lengthSoFar += Vector3.Distance(previousCorner, currentCorner);
            previousCorner = currentCorner;
            i++;
        }
        return lengthSoFar;
    }
    IEnumerator Esperar(float sec)
    {
        float frame1 = PathLength(caminho);
       // print("antes:" + frame1);
        yield return new WaitForSeconds(sec);
        float frame2 = PathLength(caminho);
        // print("depois:" + frame2);
        float variation = frame2 - frame1;
        variation = variation / 200;
        if(variation>0.004f) variation = 0.002f;
        if (variation ==0) variation = 0.002f;
        slide.value -= (variation);
    }
}
