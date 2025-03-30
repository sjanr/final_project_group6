
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour{

    [Header("Launcher")]
    [SerializeField] GameObject launcher;
    public System.Action HammerBrickBreak;
    public System.Action GunBlockLauncher;
    public enum WeaponType { Weapon1, Weapon2 }
    private WeaponType currentWeapon = WeaponType.Weapon1;

    [Header("Ground Checks")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float groundCheckRadius = 0.1f;
    private bool grounded;

    void Update(){

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // Make sure launcher disappears when player jumps
        if (currentWeapon == WeaponType.Weapon2 && !grounded) { launcher.SetActive(false); }
        if (currentWeapon == WeaponType.Weapon2 && grounded) { launcher.SetActive(true); }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //switch weapon
            currentWeapon = currentWeapon == WeaponType.Weapon1 ? WeaponType.Weapon2 : WeaponType.Weapon1;
            Debug.Log("switched to " + currentWeapon);

            // Set launcher sprite active when 'e' pressed
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
                    GunBlockLauncher?.Invoke();
                    break;
            }
        }
    }
}

