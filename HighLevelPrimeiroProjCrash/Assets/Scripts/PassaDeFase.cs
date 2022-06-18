/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Alterar cena                                                     ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PassaDeFase : MonoBehaviour
{
    //1.0   - Metodo para o box colider que se trata de quando algo encosta no que eh definido na interface
    void OnTriggerEnter2D(Collider2D other){
        //1.0   - Quando o player encosta no objeto ele vai para a proxima tela que voce define no build setings da unity
        if (other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
