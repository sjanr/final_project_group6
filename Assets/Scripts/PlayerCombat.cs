
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float checkDistance = 1f; 
    private char weapon;//used to check which weapon is currently in use

    private void OnEnable()
    {
        inputHandler.HammerBrickBreak += HammerBrickBreak;
        inputHandler.GunBlockLauncher += GunBlockLauncher;
    }

    private void OnDisable()
    {
        inputHandler.HammerBrickBreak -= HammerBrickBreak;
        inputHandler.GunBlockLauncher -= GunBlockLauncher;
    }


    //break block above
    private void HammerBrickBreak()
    {
        Vector2 origin = transform.position;   
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.up, checkDistance);
        Debug.DrawRay(origin, Vector2.up * checkDistance, Color.red, 1f);


        if (hit.collider != null && hit.collider.CompareTag("block"))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    private void GunBlockLauncher()
    {
        //implement a bullet been shot in direction of mouse
    }
}

