/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao                                                     ***/
/*****                                                                        ***/
/*** 2.0   - Pulo                                                             ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //1.0   - Para velocidade da movimentação do player
    public float        speed;
    //2.0   - Para a força do pulo
    public float        jumpForce;
    //1.0   - Para o lado que o player esta virado
    private bool        facingRight = true;
    //2.0   - Para o pulo
    private bool        jump = false;
    //1.0   - Para manipular o player
    private Rigidbody2D rb;
    //1.0   - Para trocar as animacoes do player
    private Animator    anim;
    //2.0   - Para indicar se esta no chao para poder pular
    private bool        noChao = false;
    //2.0   - Para checar se esta no chão ou não
    private Transform   groundCheck;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start(){
        //1.0   - Para inicializacao
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim        = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }

    void Update(){
        //2.0   - Verifica se existe chao abaixo
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //2.0   - Valida se esta no chão para pular, pulando e mudando animação para a de pulo
        if (Input.GetButtonDown("Jump") && noChao){
            jump = true;
            anim.SetTrigger("Pulou");
        }
    }

    //Se baseia na fisica do jogo
    void FixedUpdate(){
        //1.0   - Este texto Horizontal esta definido no project setings input na unity (referindo-se ao eixo(escala) X) de velocidade 
        float h  = Input.GetAxisRaw("Horizontal");
        //1.0   - Seleciona a transicao da animação no caso Velocidade e usa o valor oabsoluto com o Mathf.Abs pois para direita temos positivos e para esquerda negativo
        anim.SetFloat("Velocidade", Mathf.Abs(h));
        //1.0   - Movimentacao do personagem
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        //1.0   - Se o botao apertado eh maior que zero e nao esta virado para direita
        if (h > 0 && !facingRight){
            Flip();
        //1.0   - Se o botao apertado eh menor que zero e esta virado para direita
        } else if (h < 0 && facingRight){
            Flip();
        }

        //2.0   - Faz a validacao se esta pulando regula o tamanho do pulo
        if (jump){
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }

    //1.0   - Inverte o valor pra que o personagem vire pro lado oposto
    void Flip(){
        //1.0   - Se for verdadeiro vai virar falso se for falso vai virar verdadeiro
        facingRight          = !facingRight;
        //1.0   - Aqui pega o vector 3 no caso os 3 vetores x y z do transform e coloco em uma variavel
        Vector3 theScale     = transform.localScale;
        //1.0   - Aqui inverto o eixo x
        theScale.x          *= -1;
        //1.0   - Coloco de volta o valor do eixo x no transform
        transform.localScale = theScale;
    }
}
