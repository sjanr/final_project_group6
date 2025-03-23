using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float yOffset = 2f;
    [SerializeField] private float minX = -5f; // Camera won't go left past this X

    private void Update()
    {
        float clampedX = Mathf.Max(player.position.x, minX); // Prevent camera from going left past minX

        this.transform.position = new Vector3(
            clampedX,
            player.position.y + yOffset,
            this.transform.position.z
        );
    }
}
