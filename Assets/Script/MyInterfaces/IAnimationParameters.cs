using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfacesExam{
    //Interfaz para controlar los parametros de aniamciones
    public interface IAnimationParameters
    {
        //Obtenemos el componenet de Animator
        public Animator animatorController {get; set;}

        //Metodos
        public void SetInt(string name, int value);
        public void SetFloat(string name, float value);
        public void SetBool(string name, bool value);
        public void SetTrigger(string name);
    }


}
