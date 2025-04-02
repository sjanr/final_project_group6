
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour{

    [Header("Launcher")]
    [SerializeField] GameObject launcher;
    public System.Action HammerBrickBreak;
    public System.Action GunBlockLauncher;
    public enum WeaponType { Weapon1, Weapon2 }
    private WeaponType currentWeapon = WeaponType.Weapon1;

    [Header("Player Movement Reference")]
    [SerializeField] private PlayerMovement movement;

    void Update(){

        bool isGrounded = movement.grounded;
        if (currentWeapon == WeaponType.Weapon2 && !isGrounded) { launcher.SetActive(false); }
        if (currentWeapon == WeaponType.Weapon2 && isGrounded) { launcher.SetActive(true); }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //switch weapon
            currentWeapon = currentWeapon == WeaponType.Weapon1 ? WeaponType.Weapon2 : WeaponType.Weapon1;
            Debug.Log("switched to " + currentWeapon);

            //set launcher sprite active when 'e' pressed
            if (currentWeapon == WeaponType.Weapon1) { launcher.SetActive(false); }
            if (currentWeapon == WeaponType.Weapon2) { launcher.SetActive(true); }
        }

        //attack with left click
        if (Input.GetMouseButtonDown(0))
        {
            switch (currentWeapon)
            {
                case WeaponType.Weapon1:
                    Debug.Log("weapon hammer activated");
                    HammerBrickBreak?.Invoke();
                    break;
                case WeaponType.Weapon2:
                    Debug.Log("weapon gun activated");
                    if (!isGrounded) { break; }
                    GunBlockLauncher?.Invoke();
                    break;
            }
        }
    }
}

