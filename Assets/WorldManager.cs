using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WorldManager : MonoBehaviour
{
    public AudioMixer audioMixer; //Asignacion de mixer de audio para modificar boton
    bool timeStoped = false; //Bandera para saber si mi tiempo esta pausado
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //Input del jugador con la letra P
        {
            if (timeStoped) //Si nuestra bandera es verdadera el tiempo esta pausado, entonces lo restablece
            {
                Time.timeScale = 1.0f;
                audioMixer.SetFloat("Master", Time.timeScale); //Coloca el volumen en 1 para escuchar la musica otra vez
            }else //En caso contrario para el tiempo
            {
                Time.timeScale = 0f;
                audioMixer.SetFloat("Master", -80f); //Coloca la musica en -80 para quitar el sonido
            }
            timeStoped = !timeStoped; //Intercambio de bandera para saber si el tiempo esta parado o no
        }
    }
}
