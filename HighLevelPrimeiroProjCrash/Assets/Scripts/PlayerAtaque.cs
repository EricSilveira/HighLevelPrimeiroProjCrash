using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtaque : MonoBehaviour
{
    //Para marcar o tempo da anima��o
    public  float intervaloDeAtaque;
    //Para efetuar o proximo ataque
    private float proximoAtaque;
    //Para a��es do audio
    private AudioSource audioS;
    //Para declarar o audio
    public AudioClip spinSound;
    //Para trocar as anima��es do player
    Animator anim;

    //Metodo inicial chamado antes da atualiza��o do primeiro quadro
    void Start()
    {
        //Inicia��o da variavel para que possa selecionar as anima��es do personagem
        anim = gameObject.GetComponent<Animator>();
        //Inicia��o da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //Valida se bot�o esquerdo do mouse esta sendo pressionado e verifica o momento do jogo 
        //if (Input./GetButtonDown("Fire1") && Time.time > proximoAtaque)
        //Alterado para a tecla z para o ataque para n�o ser necessario o uso de mouse
        if (Input.GetKey(KeyCode.Z) && Time.time > proximoAtaque)
        {
            Atacando();
        }
    }

    void Atacando()
    {
        //Pega o audio
        audioS.clip   = spinSound;
        //Tocar o audio pego acima
        audioS.Play();
        //Carrega a anima��o de ataque
        anim.SetTrigger("Ataque");
        //Define o tempo entre um ataque e outro
        proximoAtaque = Time.time + intervaloDeAtaque;
    }
}
