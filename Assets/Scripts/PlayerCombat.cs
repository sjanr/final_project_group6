
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float checkDistance = 1f; 
    private char weapon='1';//used to check which weapon is currently in use

    private void OnEnable()
    {
        inputHandler.OnAttackInput += ChooseAttack;
    }

    private void OnDisable()
    {
        inputHandler.OnAttackInput -= ChooseAttack;
    }

    private void ChooseAttack(){
        //use switch to add more weapons later
        switch(weapon){
            case '1':
                Debug.Log("hammer time");
                BreakBlockAbove();
                break;
            case '2':
                Debug.Log("pew pew - americans favouite children toy");
                break;
            default:
                Debug.Log("hammer time");
                break;

        }
    }

    //break block above
    private void BreakBlockAbove()
    {
        Vector2 origin = transform.position;   
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.up, checkDistance);
        Debug.DrawRay(origin, Vector2.up * checkDistance, Color.red, 1f);


        if (hit.collider != null && hit.collider.CompareTag("block"))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    private void Shoot()
    {
        //implement a bullet been shot in direction of mouse
    }
}

