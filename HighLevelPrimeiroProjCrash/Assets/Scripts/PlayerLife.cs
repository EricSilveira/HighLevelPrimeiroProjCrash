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
    //Para ações do audio
    AudioSource      audioS;
    //Para trocar as animações do player
    Animator         anim;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start()
    {
        //Iniciação da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
        //Iniciação da variavel para que possa selecionar as animações do personagem
        anim = gameObject.GetComponent<Animator>();
        //Chamada da classe GamerManager usando variavel estatica gm para acessar o metodo AtualizanHud para atualizar a exibiçãode frutas coletadas e vida
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
            //Para trocar a animação de morte
            anim.SetTrigger("Morreu");
            //Chamada da classe GamerManager usando variavel estatica gm para acessar o metodo SetVidas enviando um negativo para mostrar que perdeu uma vida
            GameManager.gm.SetVidas(-1);
            //Desativa o ataque pois o player foi morto
            gameObject.GetComponent<PlayerAtaque>().enabled = false;
            //Desativa a movimentação pois o player foi morto            
            gameObject.GetComponent<PlayerController>().enabled = false;

        }

    }

    public void Reset()
    {
        //Quando a vida for maior que zero ou zero ele começa do inicio da tela senão ele vai para a cena de game over no caso deste projeto 4
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
