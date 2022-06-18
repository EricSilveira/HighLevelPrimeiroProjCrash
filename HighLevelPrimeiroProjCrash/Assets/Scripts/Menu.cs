/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Menu para inicio ou sair do jogo                                 ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //1.0   - Metodo para carregar a a cena do menu setado na interface unity
    public void CarregaFase(int cena){
        SceneManager.LoadScene(cena);
    }

    //1.0   - Metodo para sair do jogo 
    public void Sair(){
        Application.Quit();
    }
}
