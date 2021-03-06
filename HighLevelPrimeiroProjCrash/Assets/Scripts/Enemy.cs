/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao                                                     ***/
/*****                                                                        ***/
/*** 2.0   - Morte inimigo                                                    ***/
/*****                                                                        ***/
/*** 3.0   - Morte player                                                     ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //2.0   - Para a?oes do audio
    private AudioSource audioS;
    //1.0   - Para manipucao do inimigo
    private Rigidbody2D rb;
    //1.0   - Para realizar a checagem do chao
    private Transform   groundCheck;
    //1.0   - Para velocidade da movimentacao do inimigo
    public  float       speed;
    //1.0   - Para o lado que o inimigo esta virado
    private bool        facingRight = false;
    //1.0   - Para indicar se esta no chao
    private bool        noChao      = false;
    //2.0   - Para a for?a do bulo quando o player pular encima do inimigo
    public  float       jumpForce = 700;

    void Start(){
        //1.0   - Para inicializacao
        rb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("EnemyGroundCheck");
        audioS = gameObject.GetComponent<AudioSource>();
    }

    void Update(){
        //1.0   - Verifica se existe chao abaixo
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //1.0   - Quando nao tiver chao vai inverter a velocidade
        if (!noChao)
            speed *= -1;
    }

    //Se baseia na fisica do jogo
    void FixedUpdate(){
        rb.velocity = new Vector2(speed, rb.velocity.y);
        //1.0   - Valida o lado que o inimigo esta virado
        if (speed > 0 && !facingRight){
            Flip();
        } else if (speed < 0 && facingRight){
            Flip();
        }
    }

    //1.0   - Inverte o valor pra que o personagem vire pro lado oposto
    void Flip(){
        facingRight          = !facingRight;
        Vector3 theScale     = transform.localScale;
                 theScale.x *= -1;
        transform.localScale = theScale;
    }

    //2.0   - Metodo para o box colider, que se trata de quando algo encosta no que eh definido na interface
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            audioS.Play();
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            
            foreach(BoxCollider2D box in boxes){
                box.enabled  = false;
            }
            
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            speed    = 0;
            transform.Rotate(new Vector3(0, 0, -180));
            Destroy(gameObject, 3);
        }
    }

    //3.0   - Metodo para o box colider, que se trata de quando algo encosta no que eh definido na interface
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerLife>().PerdeVida();
        }
    }
}
