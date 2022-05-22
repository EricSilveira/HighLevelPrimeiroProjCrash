using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    //Para o ataque quando horizontal 
    public float forcaHorizontal   = 15;
    //Para o ataque quando vertical
    public float forcaVertical     = 10;
    //Tempo que levara para destruir o objeto
    public float tempoDeDestruicao =  1;
    //Para guardar o valor inicial da força horizontal
    float forcaHorizontalPadrao;

    // Start is called before the first frame update
    void Start()
    {
        forcaHorizontalPadrao      = forcaHorizontal;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Metodo para o box colider, que se trata de quando algo encosta no que é definido na interface
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().enabled = false;
            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();
            foreach(BoxCollider2D box in boxes)
            {
                box.enabled      = false;
            }
            if (other.transform.position.x < transform.position.x)
            {
                forcaHorizontal *= -1;
            }
                
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaHorizontal, forcaVertical), ForceMode2D.Impulse);
            Destroy(other.gameObject, tempoDeDestruicao);
            forcaHorizontal      = forcaHorizontalPadrao;
        }
    }
}
