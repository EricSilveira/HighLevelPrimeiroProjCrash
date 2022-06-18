/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Acao Caixa                                                       ***/
/*****                                                                        ***/
/*** 2.0   - Invocacao de frutas                                              ***/
/*****                                                                        ***/
/*** 3.0   - Efeito player                                                    ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaScript : MonoBehaviour
{
    //1.0   - Para declarar o circulo de colisão da fruta   
    Animator anim;
    //3.0   - Para a força do pulo quando o player pular encima doa caixa   
    public float jumpForce;
    //2.0   - Para setar quantas frutas tera na caixa
    public int frutas;
    //2.0   - Para setar a animação da fruta quando pular na caixa
    public GameObject frutaPrefab;
    //1.0   - Para declarar o audio
    public AudioClip[] audios;
    //1.0   - Para ações do audio
    AudioSource audioS;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start(){
        //1.0   - Iniciacao da variavel para que possa selecionar as animacoes do personagem
        anim = gameObject.GetComponent<Animator>();
        //1.0   - Iniciacao da variavel para que possa selecionar o audio e executar
        audioS = gameObject.GetComponent<AudioSource>();
    }

    //Metodo para o box colider, que se trata de quando algo encosta no que eh definido na interface
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            //1.0   - Seleciona o audio e toca
            audioS.clip = audios[0];
            audioS.Play();
            //3.0   - Zera o eixo X e eixo Y
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //3.0   - Adiciona forca do pulo cada vez que pular na caixa
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            //2.0   - Realiza a animacao da caixa
            anim.SetTrigger("Colidindo");

            //2.0   - Vai coletar as frutas definidas quando chegar a 0 o objeto ira destruir e apresentara o som
            if (frutas > 0){
                GameObject tempFrutas = Instantiate(frutaPrefab, transform.position, transform.rotation) as GameObject;
                tempFrutas.GetComponent<Animator>().SetTrigger("Coletando");
                tempFrutas.GetComponent<AudioSource>().Play();
                frutas -= 1;
                GameManager.gm.SetFrutas(1);
                Destroy(tempFrutas, 0.667f);
                
                if (frutas == 0){
                    //1.0   - Pega o audio
                    audioS.clip = audios[1];
                    //1.0   - Tocar o audio pego acima
                    AudioSource.PlayClipAtPoint(audios[1], transform.position);
                    Destroy(gameObject);
                }

            } else{
                //1.0   - Pega o audio
                audioS.clip = audios[1];
                //1.0   - Tocar o audio pego acima
                AudioSource.PlayClipAtPoint(audios[1], transform.position);
                Destroy(gameObject);
            }
        }
    }
}
