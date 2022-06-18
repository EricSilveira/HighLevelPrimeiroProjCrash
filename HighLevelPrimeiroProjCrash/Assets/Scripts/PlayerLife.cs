/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Controle de vida do player                                       ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //1.0   - Para setar se o player esta vivo
    private bool        vivo = true;
    //1.0   - Para declarar o audio
    public  AudioClip   DeathSound;
    //1.0   - Para acoes do audio
    private AudioSource audioS;
    //1.0   - Para trocar as animacoes do player
    private Animator    anim;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start(){
        //1.0   - Iniciacao da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
        //1.0   - Iniciacao da variavel para que possa selecionar as animacoes do personagem
        anim   = gameObject.GetComponent<Animator>();
        //1.0   - Chamada da classe GamerManager usando variavel estatica gm para acessar o metodo AtualizanHud para atualizar a exibicao de frutas coletadas e vida
        GameManager.gm.AtualizaHud();
    }

    //1.0   - Metodo para quando o player morre
    public void PerdeVida(){
        if (vivo){
            //1.0   - Pega o audio
            audioS.clip = DeathSound;
            //1.0   - Tocar o audio pego acima
            audioS.Play();
            //1.0   - Seta que o player morreu
            vivo = false;
            //1.0   - Para trocar a animacao de morte
            anim.SetTrigger("Morreu");
            //1.0   - Chamada da classe GamerManager usando variavel estatica gm para acessar o metodo SetVidas enviando um negativo para mostrar que perdeu uma vida
            GameManager.gm.SetVidas(-1);
            //1.0   - Desativa o ataque pois o player foi morto
            gameObject.GetComponent<PlayerAtaque>().enabled = false;
            //1.0   - Desativa a movimentação pois o player foi morto            
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    public void Reset(){
        //Quando a vida for maior que zero ou zero ele começa do inicio da tela senão ele vai para a cena de game over no caso deste projeto 4
        if (GameManager.gm.GetVidas() >= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else{
            SceneManager.LoadScene(4);
        }
    }
}
