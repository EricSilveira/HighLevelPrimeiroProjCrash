/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Apresentacao de valores                                          ***/
/*****                                                                        ***/
/*** 2.0   - Frutas                                                           ***/
/*****                                                                        ***/
/*** 3.0   - Vidas                                                            ***/
/*****                                                                        ***/
/*** 4.0   - Carregar proxima fase                                            ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Estatica para fazer referencia a classe e não ao objeto usado para comunicar com as funçoes deste objeto
    public static GameManager gm;
    //3.0   - Para a vida do player
    private int vidas  = 2;
    //2.0   - Para as frutas coletadas pelo player 
    private int frutas = 0;

    // Metodo para inicializar variáveis ​​ou estados antes do início do aplicativo.
    void Awake(){
        //4.0   - Para receber notificações após a conclusão do carregamento da cena necessario para o metodo no final
        SceneManager.sceneLoaded += OnTelaParaReiniciar; 
        //Destroi o objeto se ja existe se não existir ira manter
        if (gm == null){
            gm = this;
            DontDestroyOnLoad(gameObject);
        }else
            Destroy(gameObject);
    }

    //Metodo inicial chamado antes da atualização do primeiro quadro
    void Start(){
        AtualizaHud(); 
    }

    //3.0   - Define o numero de vidas
    public void SetVidas(int vida){
        vidas += vida;
        //3.0   - Verifica se a vida esta maior ou igual a zero para atualizar na tela
        if (vidas >= 0){
            AtualizaHud();
        }
    }

    //3.0   - Retorna o numero de vidas definido na função acima
    public int GetVidas(){
        return vidas;
    }

    //2.0   - Define o numero de frutas
    public void SetFrutas(int fruta){
        //2.0   - Incrementa a fruta com a nova coletada
        frutas += fruta;
        //2.0   - Quando coletar + de 50 frutas ganha uma vida e reinicia para zero frutas
        if (frutas >= 50){
            frutas = 0;
            vidas += 1;
        }
        AtualizaHud();
    }


    //1.0   - Metodo para trazer a vida e frutas na tela
    public void AtualizaHud(){
        GameObject.Find("VidasText").GetComponent<Text>().text = vidas.ToString();
        GameObject.Find("FrutaText").GetComponent<Text>().text = frutas.ToString();
    }

    //1.0   - Metodo para que quando entre no menu reinicie as vidas e frutas
    //******Esse metodo esta depreciate quer dizer que foi descontinuado e usado um novo que esta logo abaixo
    //public void OnLevelWasLoaded(){
    //    if (SceneManager.GetActiveScene().buildIndex == 0){
    //        vidas  = 2;
    //        frutas = 0;
    //    }
    //}

    void OnTelaParaReiniciar(Scene scene, LoadSceneMode sceneMode){
        if (SceneManager.GetActiveScene().buildIndex == 0){
            vidas  = 2;
            frutas = 0;
        }
    }
}
    