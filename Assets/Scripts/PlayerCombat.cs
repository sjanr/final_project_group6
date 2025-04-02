
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float checkDistance = 1f; 
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float GunBlockLauncherCooldown = 0.5f;
    [SerializeField] private ParticleSystem gunParticles;
    [SerializeField] private Animator recoil;
    private float ShotTime = -Mathf.Infinity;
    [SerializeField] private LayerMask blockLayerMask;

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
        //get block above player
        Vector2 origin = transform.position;   
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.up, checkDistance,blockLayerMask);
        Debug.DrawRay(origin, Vector2.up * checkDistance, Color.red, 1f);


         if (hit.collider != null)
        {
            if (hit)
            {
                AudioManager.instance.playSound(AudioManager.instance.breakClip);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void GunBlockLauncher()
    {
        if (Time.time - ShotTime < GunBlockLauncherCooldown){
            Debug.Log("still on cooldown");
            return; // still on cooldown
        }
        
        ShotTime = Time.time;
        //implement a bullet been shot in direction facing
        //1 = right, -1 = left

        //code to get direction
        float facingDirection = transform.localScale.x > 0 ? -1f : 1f;
        Vector2 dir = new Vector2(facingDirection, 0f);

     
        Debug.Log("Spawning projectile!");
        //display the projectile
        GameObject proj = Instantiate(projectile, firePoint.position, Quaternion.identity);
        gunParticles.Play();
        recoil.SetTrigger("Shoot");
        AudioManager.instance.playSound(AudioManager.instance.shootClip);
        Debug.Log("Projectile position: " + proj.transform.position);
        proj.GetComponent<Projectile>().Init(dir);
    }
}

