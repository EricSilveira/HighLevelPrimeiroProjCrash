using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
    //Metodo para o box colider, que se trata de quando algo encosta no que é definido na interface, usado para morte em buracos
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerLife>().PerdeVida();
            Destroy(gameObject);
        }

    }
}
