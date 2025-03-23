
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour{

     public System.Action OnAttackInput;


    void Update(){
        
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.E)){
            //switch weapon
        }
        if (Input.GetMouseButtonDown(0)){ //left clcik
            //trigger attack
            OnAttackInput?.Invoke();
        }

        

    }

    
}

