using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Para ações do audio
    AudioSource audioS;
    //Para manipução do inimigo
    Rigidbody2D rb;
    //Para realizar a checagem do chao
    Transform groundCheck;
    //Para velocidade da movimentação do inimigo
    public float speed;
    //Para o lado que o player esta virado
    bool facingRight       = false;
    //Para indicar se esta no chão
    bool noChao            = false;
    //Para a força do bulo quando o player pular encima do inimigo
    public float jumpForce = 700;

    // Start is called before the first frame update
    void Start()
    {
        //Para iniciação
        rb          = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("EnemyGroundCheck");
        audioS = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //Verifica se existe chão abaixo
        noChao     = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //Quando não tiver chão vai inverter a velocidade
        if (!noChao)
            speed *= -1;
    }

    //Se baseia na fisica do jogo
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        //Valida o lado que o inimigo esta virado
        if (speed > 0 && !facingRight)
        {
            Flip();
        }
        else if (speed < 0 && facingRight)
        {
            Flip();
        }
    }

    //Inverte o valor pra que o personagem vire pro lado oposto
    void Flip()
    {
        facingRight          = !facingRight;
        Vector3 theScale     = transform.localScale;
                 theScale.x *= -1;
        transform.localScale = theScale;
    }

    //Metodo para o box colider, que se trata de quando algo encosta no que é definido na interface
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.Play();
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach(BoxCollider2D box in boxes)
            {
                box.enabled  = false;
            }
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            speed    = 0;
            transform.Rotate(new Vector3(0, 0, -180));
            Destroy(gameObject, 3);
        }

    }
    //Metodo para o box colider, que se trata de quando algo encosta no que é definido na interface
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().PerdeVida();
        }
    }
}
