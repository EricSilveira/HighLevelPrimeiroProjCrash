using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrutaScript : MonoBehaviour
{
    //Para ações do audio
    AudioSource      audioS;
    //Para trocar as animações do player
    Animator anim;
    //Para declarar o circulo de colisão da fruta
    CircleCollider2D col;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start()
    {
        //Iniciação da variavel para que possa selecionar as animações do personagem
        anim = gameObject.GetComponent<Animator>();
        //Iniciação da variavel para que possa manipular o objeto
        col = gameObject.GetComponent<CircleCollider2D>();
        //Iniciação da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
    }

    //Metodo para o box colider, que se trata de quando algo encosta no que é definido na interface
    void OnTriggerEnter2D(Collider2D other)
    {
        //Quando o player encosta no objeto ele vai ativar a musica, fazer a animação, incrementar o coletor, desabilitar o objeto e depois do tempo de 0,667 vai destrui-lo 
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
