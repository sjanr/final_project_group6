using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float baseYOffset = 8.2f;
    [SerializeField] private float minX = -5f;
    [SerializeField] private float transitionSpeed = 1f; // how quickly it transitions

    private float currentYOffset;

    private void Start()
    {
        currentYOffset = baseYOffset;
    }

    private void Update()
    {
        float clampedX = Mathf.Max(player.position.x, minX);

        // Decide the target offset based on height
        float targetYOffset = player.position.y < 2f ? baseYOffset : 0f;

        // Smoothly transition toward the target offset
        currentYOffset = Mathf.Lerp(currentYOffset, targetYOffset, Time.deltaTime * transitionSpeed);

        // Apply camera position
        this.transform.position = new Vector3(
            clampedX,
            player.position.y + currentYOffset,
            this.transform.position.z
        );
    }
}
