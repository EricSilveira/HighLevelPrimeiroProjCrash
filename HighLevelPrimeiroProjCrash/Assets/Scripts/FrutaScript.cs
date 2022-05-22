using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaScript : MonoBehaviour
{
    //Para a��es do audio
    AudioSource      audioS;
    //Para trocar as anima��es do player
    Animator anim;
    //Para declarar o circulo de colis�o da fruta
    CircleCollider2D col;

    //Metodo inicial chamado antes da atualiza��o do primeiro quadro
    void Start()
    {
        //Inicia��o da variavel para que possa selecionar as anima��es do personagem
        anim = gameObject.GetComponent<Animator>();
        //Inicia��o da variavel para que possa manipular o objeto
        col = gameObject.GetComponent<CircleCollider2D>();
        //Inicia��o da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
    }

    //Metodo para o box colider, que se trata de quando algo encosta no que � definido na interface
    void OnTriggerEnter2D(Collider2D other)
    {
        //Quando o player encosta no objeto ele vai ativar a musica, fazer a anima��o, incrementar o coletor, desabilitar o objeto e depois do tempo de 0,667 vai destrui-lo 
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.Play();
            anim.SetTrigger("Coletando");
            GameManager.gm.SetFrutas(1);
            col.enabled = false;
            Destroy(gameObject, 0.667f);
        }
    }
}
