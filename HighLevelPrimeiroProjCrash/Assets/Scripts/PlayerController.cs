using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Para velocidade da movimentação do player
    public float        speed;
    //Para a força do pulo
    public float        jumpForce;
    //Para o lado que o player esta virado
    private bool        facingRight = true;
    //Para o pulo
    private bool        jump = false;
    //Para manipular o player
    private Rigidbody2D rb;
    //Para trocar as animações do player
    private Animator    anim;
    //Para indicar se esta no chão para poder pular
    private bool        noChao = false;
    //Para checar se esta no chão ou não
    private Transform   groundCheck;

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start()
    {
        //Para iniciação
        rb          = gameObject.GetComponent<Rigidbody2D>();
        anim        = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }

    void Update()
    {
        //Verifica se existe chão abaixo
        noChao   = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //Valida se esta no chão para pular, pulando e mudando animação para a de pulo
        if (Input.GetButtonDown("Jump") && noChao)
        {
            jump = true;
            anim.SetTrigger("Pulou");
        }
    }
    //Se baseia na fisica do jogo
    void FixedUpdate()
    {
        // este texto Horizontal esta definido no project setings input na unity (referindo-se ao eixo(escala) X) de velocidade 
        float h  = Input.GetAxisRaw("Horizontal");
        //seleciona a transição da animação no caso Velocidade e usa o valor oabsoluto com o Mathf.Abs pois para direita temos positivos e para esquerda negativo
        anim.SetFloat("Velocidade", Mathf.Abs(h));
        //Movimentação do personagem
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        //se o botão apertado é maior que zero e não esta virado para direita
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        //se o botão apertado é menor que zero e esta virado para direita
        else if (h < 0 && facingRight)
        {
            Flip();
        }

        //Faz a validação se esta pulando regula o tamanho do pulo
        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }

    //Inverte o valor pra que o personagem vire pro lado oposto
    void Flip()
    {
        //se for verdadeiro vai virar falso se for falso vai virar verdadeiro
        facingRight = !facingRight;
        //aqui pega o vector 3 no caso os 3 vetores x y z do transform e coloco em uma variavel
        Vector3 theScale     = transform.localScale;
        //aqui inverto o eixo x
              theScale.x    *= -1;
        //coloco de volta o valor do eixo x no transform
        transform.localScale = theScale;

    }
}
