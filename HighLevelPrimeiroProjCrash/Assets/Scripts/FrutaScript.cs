/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Som para o objeto                                                ***/
/*****                                                                        ***/
/*** 2.0   - Animacao do objeto                                               ***/
/*****                                                                        ***/
/*** 3.0   - Acao do objeto                                                   ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaScript : MonoBehaviour
{
    //1.0   - Para acoes do audio
    AudioSource     audioS;
    //2.0   - Para trocar as animacoes do objeto
    private Animator anim;
    //3.0   - Para declarar o circulo de colisao da fruta
    CircleCollider2D col;

    //Metodo inicial chamado antes da atualizacao do primeiro quadro
    void Start(){
        //2.0   - Iniciacao da variavel para que possa selecionar as animacoes do objeto    
        anim   = gameObject.GetComponent<Animator>();
        //3.0   - Iniciacao da variavel para que possa manipular o objeto
        col    = gameObject.GetComponent<CircleCollider2D>();
        //1.0   - Iniciacao da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
    }

    //Metodo para o box colider, que se trata de quando algo encosta no que eh definido na interface
    void OnTriggerEnter2D(Collider2D other){
        //3.0   - Quando o player encosta no objeto 
        if (other.gameObject.CompareTag("Player")){
            //1.0   - Ativa o som
            audioS.Play();
            //2.0   - Troca a animacao
            anim.SetTrigger("Coletando");
            //3.0   - Chama a classe para adicionar o objeto coletado
            GameManager.gm.SetFrutas(1);
            col.enabled = false;
            //3.0   - Destroi o objeto
            Destroy(gameObject, 0.667f);
        }
    }
}
