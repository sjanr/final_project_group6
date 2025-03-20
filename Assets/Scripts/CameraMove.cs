using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        this.transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z);
    }

}
