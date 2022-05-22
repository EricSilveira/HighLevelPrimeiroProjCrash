using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //Para setar se o player esta vivo
    bool             vivo = true;
    //Para declarar o audio
    public AudioClip DeathSound;
    //Para a��es do audio
    AudioSource      audioS;
    //Para trocar as anima��es do player
    Animator         anim;

    //Metodo inicial chamado antes da atualiza��o do primeiro quadro
    void Start()
    {
        //Inicia��o da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
        //Inicia��o da variavel para que possa selecionar as anima��es do personagem
        anim = gameObject.GetComponent<Animator>();
        //Chamada da classe GamerManager usando variavel estatica gm para acessar o metodo AtualizanHud para atualizar a exibi��ode frutas coletadas e vida
        GameManager.gm.AtualizaHud();
    }

    //Metodo para quando o player morre
    public void PerdeVida()
    {
        if (vivo)
        {
            //Pega o audio
            audioS.clip = DeathSound;
            //Tocar o audio pego acima
            audioS.Play();
            //Seta que o player morreu
            vivo = false;
            //Para trocar a anima��o de morte
            anim.SetTrigger("Morreu");
            //Chamada da classe GamerManager usando variavel estatica gm para acessar o metodo SetVidas enviando um negativo para mostrar que perdeu uma vida
            GameManager.gm.SetVidas(-1);
            //Desativa o ataque pois o player foi morto
            gameObject.GetComponent<PlayerAtaque>().enabled = false;
            //Desativa a movimenta��o pois o player foi morto            
            gameObject.GetComponent<PlayerController>().enabled = false;

        }

    }

    public void Reset()
    {
        //Quando a vida for maior que zero ou zero ele come�a do inicio da tela sen�o ele vai para a cena de game over no caso deste projeto 4
        if (GameManager.gm.GetVidas() >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }
}
