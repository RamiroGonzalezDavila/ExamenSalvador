using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InterfacesExam;
public class MainPlayer : IMovements
{

    //Atributos

    //Velocidad
    private Vector3 playerVelocity;
    [SerializeField] float playerSpeed = 2.0f;

    //Triggers
    private bool playerOnGround;

    //Fisicas
    private float gravity = -9.81f;
    [SerializeField] float playerJumpHeight = 0f;
    public CharacterController controller { get; set; }

    //Aniamciones
    public AnimatorController animatorController;

    //Layers
    private LayerMask groundLayerMask;

    //Constructor
    public MainPlayer(CharacterController characterController, LayerMask groundMask)
    {
        controller = characterController;
        groundLayerMask = groundMask;

        // New AnimatorController
        animatorController = new AnimatorController();
        animatorController.animatorController = controller.GetComponentInChildren<Animator>();
    }

    //Metodos

    public void move(Vector3 direction){
        var localDirection = controller.transform.TransformDirection(direction);
        //Movemos el carachter controller en tiempo real
        controller.Move(localDirection * Time.deltaTime * playerSpeed);
        //Giramos al jugador según la dirección en la que se mueve
        controller.transform.Rotate(Vector3.up, direction.x * 2, Space.World);

        //Animaciones de Movimiento
        animatorController.SetFloat("Vertical", direction.z);
        animatorController.SetFloat("Horizontal", direction.x);

    }

    public void jump(){
        if(!isGrounded()  || playerVelocity.y > 0) return;

        //Modificamos su salto
        playerVelocity.y += Mathf.Sqrt(playerJumpHeight * -3.0f * gravity);
        controller.Move(playerVelocity * Time.deltaTime);

        //Animacion salto
        animatorController.SetBool("Jumping", true);
    }

    public void groundCharacter(){
        //Verificamos si esta flotando
        if (!isGrounded() && playerVelocity.y > 0)
        {
            //Dirigimos su velocidad al suelo
            playerVelocity.y = 0;
            return;
        }
    }

    public bool isGrounded(){
        //Dibujamos un raycast
        Debug.DrawRay(controller.transform.position, Vector3.down * .15f, Color.red);
        //Verificamos si el raycast esta dentro del suelo
        return Physics.Raycast(controller.transform.position, Vector3.down, out RaycastHit hit, .15f , groundLayerMask);
    }
}
