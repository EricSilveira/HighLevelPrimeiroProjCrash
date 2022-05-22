using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtaque : MonoBehaviour
{
    //Para marcar o tempo da animação
    public  float intervaloDeAtaque;
    //Para efetuar o proximo ataque
    private float proximoAtaque;
    //Para ações do audio
    private AudioSource audioS;
    //Para declarar o audio
    public AudioClip spinSound;
    //Para trocar as animações do player
    Animator anim;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start()
    {
        //Iniciação da variavel para que possa selecionar as animações do personagem
        anim = gameObject.GetComponent<Animator>();
        //Iniciação da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //Valida se botão esquerdo do mouse esta sendo pressionado e verifica o momento do jogo 
        //if (Input./GetButtonDown("Fire1") && Time.time > proximoAtaque)
        //Alterado para a tecla z para o ataque para não ser necessario o uso de mouse
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
        //Carrega a animação de ataque
        anim.SetTrigger("Ataque");
        //Define o tempo entre um ataque e outro
        proximoAtaque = Time.time + intervaloDeAtaque;
    }
}
