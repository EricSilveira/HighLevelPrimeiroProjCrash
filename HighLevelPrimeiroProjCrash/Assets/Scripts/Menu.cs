 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Metodo para carregar a a cena do menu setado na interface unity
    public void CarregaFase(int cena)
    {
        SceneManager.LoadScene(cena);
    }

    //Metodo para sair do jogo 
    public void Sair()
    {
        Application.Quit();
    }
}
