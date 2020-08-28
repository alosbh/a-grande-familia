using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    static public Player jogador;
    public Personagem personagem;

    public bool emCorrida = false;
    
    public bool PodeSair = false;
    public bool PodeEntrar = false;

    public Text tituloslide;
    public Slider slide;
    public Text titulopreço;
    public Text preço;
    public Text preçoacumulado;
    public GameObject presspace;


    float valoracumulado;
    public float addvaloracumulado;

    public Passageiro PassageiroAtual;

    private void Awake()
    {
        jogador = this;

    }
    void Start () {
       
	}
	
	
	void Update () {

        Movimento();

        if (Input.GetButtonDown("Jump") && PodeEntrar)
        {
            IniciarCorrida();
        }
        if (Input.GetButtonDown("Jump") && PodeSair)
        {
            TerminarCorrida();
        }
        if (PodeEntrar)
        {
            presspace.SetActive(true);
        }
        else
        {
            presspace.SetActive(false);
        }
        
		
	}
    void Movimento()
    {



        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        
        personagem.transform.Rotate(0, x, 0);
        personagem.transform.Translate(0, 0, z * personagem.Velocidade);

    }

    void IniciarCorrida()
    {
        goldenpath.designtrick.target = PassageiroAtual.destino;
        PodeEntrar = false;
        emCorrida = true;
        PassageiroAtual.partida.gameObject.SetActive(false);
        PassageiroAtual.Pessoa.SetActive(false);
        
        titulopreço.gameObject.active = true;
        tituloslide.gameObject.active = true;
        slide.gameObject.active = true;
        preço.gameObject.active = true;
       

    }
    void TerminarCorrida()
    {
        goldenpath.designtrick.valor = 0;
        valoracumulado += addvaloracumulado;
        preçoacumulado.text = ((int)valoracumulado).ToString();
        addvaloracumulado = 0;
        emCorrida = false;
        PodeSair = false;
        titulopreço.gameObject.active = false;
        tituloslide.gameObject.active = false;
        slide.gameObject.active = false;
        preço.gameObject.active = false;
        PassageiroAtual.Pessoa.transform.position = new Vector3(jogador.personagem.transform.position.x,PassageiroAtual.Pessoa.transform.position.y, jogador.personagem.transform.position.z-0.5f);
        PassageiroAtual.Pessoa.transform.Rotate(0,180f,0);
        PassageiroAtual.Pessoa.SetActive(true);
        PassageiroAtual.destino.gameObject.SetActive(false);
    }
}

