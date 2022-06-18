/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Som para o ataque                                                ***/
/*****                                                                        ***/
/*** 2.0   - Animacao do ataque                                               ***/
/*****                                                                        ***/
/*** 3.0   - Acao do ataque                                                   ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtaque : MonoBehaviour
{
    //3.0   - Para marcar o tempo da animacao
    public  float intervaloDeAtaque;
    //Para efetuar o proximo ataque
    private float     proximoAtaque;
    //1.0   - Para acoes do audio
    private AudioSource      audioS;
    //1.0   - Para declarar o audio
    public  AudioClip     spinSound;
    //2.0   - Para trocar as animações do player
    private Animator           anim;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start(){
        //2.0   - Iniciacao da variavel para que possa selecionar as animacoes do personagem
        anim   = gameObject.GetComponent<Animator>();
        //1.0   - Iniciacao da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
    }

    void Update(){
        //3.0   - Valida se botao esquerdo do mouse esta sendo pressionado e verifica o momento do jogo 
        //if (Input./GetButtonDown("Fire1") && Time.time > proximoAtaque)
        //3.0   - Alterado para a tecla z para o ataque para nao ser necessario o uso de mouse ou do CTRL esquerdo
        if (Input.GetKey(KeyCode.Z) && Time.time > proximoAtaque){
            Atacando();
        }
    }

    void Atacando(){
        //1.0   - Pega o audio
        audioS.clip   = spinSound;
        //1.0   - Tocar o audio pego acima
        audioS.Play();
        //2.0   - Carrega a animacao de ataque
        anim.SetTrigger("Ataque");
        //3.0   - Define o tempo entre um ataque e outro
        proximoAtaque = Time.time + intervaloDeAtaque;
    }
}
