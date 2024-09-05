using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InterfacesExam;

public class PlayerController : MonoBehaviour
{

    //Atributos
    public LayerMask groundMask;

    //Interfaz
    private IMovements character;

    // Start is called before the first frame update
    void Start()
    {
        //Instaciamos una clase jugador y llamamos a su constructor
        character = new MainPlayer(GetComponent<CharacterController>(),groundMask);
    }

    // Update is called once per frame
    void Update()
    {
        //Direccion en el que se mueve con el input
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Verificamos si esta estatico
        if(movementDirection != Vector3.zero)
        {
            //Si corre, llamamos a la función Move del controlador
            if(Input.GetKey(KeyCode.LeftShift))
            {
                character.move(movementDirection*2);
            }
            else{
                character.move(movementDirection);
            }
        }

        //Verificamos si salta
        if(Input.GetButtonDown("Jump"))
        {
            character.jump();
        }

        character.groundCharacter();
        
    }
}
