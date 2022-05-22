using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //Para declaração da musica de fundo
    private static MusicPlayer mp;

    // Metodo para inicializar variáveis ​​ou estados antes do início do aplicativo.
    void Awake()
    {
        //Verifica se esta vazia a musica se não tiver ele inicia senão ele destroi o objeto
        if (mp == null) { 
            mp = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

}
