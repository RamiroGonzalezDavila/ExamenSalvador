using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InterfacesExam;

public class AnimatorController : MonoBehaviour, IAnimationParameters
{
    //Obtenemos el animator de nuestro objeto
     public UnityEngine.Animator animatorController { get; set; }

     //Metodos declarados
     public void SetBool(string name, bool value)
     {
         animatorController.SetBool(name, value);
     }
     
     public void SetFloat(string name, float value)
     {
         animatorController.SetFloat(name, value);
     }
      public void SetInt(string name, int value)
     {
         animatorController.SetInteger(name, value);
     }
      public void SetTrigger(string name)
     {
         animatorController.SetTrigger(name);
     }
}
