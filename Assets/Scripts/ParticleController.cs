using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Class code source: https://www.youtube.com/watch?v=52hW2y6D8sw

    [SerializeField] ParticleSystem movementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRB;

    float counter;

    private void Update()
    {
        counter += Time.deltaTime;
        if (Mathf.Abs(playerRB.linearVelocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }
}
