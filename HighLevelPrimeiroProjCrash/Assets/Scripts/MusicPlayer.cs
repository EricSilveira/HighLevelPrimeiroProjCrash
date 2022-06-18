/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Selecao de muusica inicial do jogo                               ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //1.0   - Para declaracao da musica de fundo
    private static MusicPlayer mp;

    //1.0   - Metodo para inicializar variaveis ​​ou estados antes do inicio do aplicativo.
    void Awake(){
        //1.0   - Verifica se esta vazia a musica se nao tiver ele inicia senao ele destroi o objeto
        if (mp == null){ 
            mp = this;
            DontDestroyOnLoad(gameObject);
        } else{
            Destroy(gameObject);
        }
    }
}
