using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PassaDeFase : MonoBehaviour
{
    //Metodo para o box colider que se trata de quando algo encosta no que é definido na interface
    void OnTriggerEnter2D(Collider2D other)
    {
        //Quando o player encosta no objeto ele vai para a proxima tela que voce define no build setings da unity
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
