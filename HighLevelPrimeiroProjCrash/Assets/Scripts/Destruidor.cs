/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Morte player                                                     ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruidor : MonoBehaviour
{
    //1.0   - Metodo para o box colider, que se trata de quando algo encosta no que eh definido na interface, usado para morte em buracos, o objeto é colocado junto a camera
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            other.GetComponent<PlayerLife>().PerdeVida();
            Destroy(gameObject);
        }
    }
}
