using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float yOffset = 2f; // Adjust this in the Inspector

    private void Update()
    {
        this.transform.position = new Vector3(
            player.position.x,
            player.position.y + yOffset, // Add the offset here
            this.transform.position.z
        );
    }
}
