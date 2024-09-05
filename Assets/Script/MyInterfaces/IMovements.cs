using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfacesExam {
    //Interfaz para controlar el movimiento de nuestros agentes
    public interface IMovements
    {
        //Obtenemmos el objeto de Caharacter controller
        public CharacterController controller {get; set;}

        //Metodos
        public void move(Vector3 direction);
        public void jump();
        public void groundCharacter();
        public bool isGrounded();


    }

}
