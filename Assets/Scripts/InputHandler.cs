
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour{

    public System.Action HammerBrickBreak;
    public System.Action GunBlockLauncher;
    private char weapon = '1';

    void Update(){
        
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            //switch weapon
            weapon = weapon == '1' ? '2' : '1';
            Debug.Log("Switched to weapon " + weapon);
        }

        //attack with left click
        if (Input.GetMouseButtonDown(0))
        {
            switch (weapon)
            {
                case '1':
                    HammerBrickBreak?.Invoke();
                    break;
                case '2':
                    GunBlockLauncher?.Invoke();
                    break;
            }
        }

        

    }

    
}

