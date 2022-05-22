using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaScript : MonoBehaviour
{
    //Para declarar o circulo de colisão da fruta   
    Animator anim;
    //Para a força do bulo quando o player pular encima doa caixa   
    public float jumpForce;
    //Para setar quantas frutas tera na caixa
    public int frutas;
    //Para setar a animação da fruta quando pular na caixa
    public GameObject frutaPrefab;
    //Para declarar o audio
    public AudioClip[] audios;
    //Para ações do audio
    AudioSource audioS;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start()
    {
        //Iniciação da variavel para que possa selecionar as animações do personagem
        anim = gameObject.GetComponent<Animator>();
        //Iniciação da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
    }

    //Metodo para o box colider, que se trata de quando algo encosta no que é definido na interface
    void OnTriggerEnter2D(Collider2D other)
    {
        //Quando o player encosta no objeto ele vai ativar a musica, vai incrementar o pulo, e trocar a animação da caixa
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.clip = audios[0];
            audioS.Play();
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            anim.SetTrigger("Colidindo");
            //Vai coletar as frutas definidas quando chegar a 0 o objeto ira destruir e apresentara o som
            if (frutas > 0)
            {
                GameObject tempFrutas = Instantiate(frutaPrefab, transform.position, transform.rotation) as GameObject;
                tempFrutas.GetComponent<Animator>().SetTrigger("Coletando");
                tempFrutas.GetComponent<AudioSource>().Play();
                frutas -= 1;
                GameManager.gm.SetFrutas(1);
                Destroy(tempFrutas, 0.667f);
                if (frutas == 0)
                {
                    //Pega o audio
                    audioS.clip = audios[1];
                    //Tocar o audio pego acima
                    AudioSource.PlayClipAtPoint(audios[1], transform.position);

                    Destroy(gameObject);
                }
            }
            else
            {
                //Pega o audio
                audioS.clip = audios[1];
                //Tocar o audio pego acima
                AudioSource.PlayClipAtPoint(audios[1], transform.position);

                Destroy(gameObject);
            }
        }
    }

}
