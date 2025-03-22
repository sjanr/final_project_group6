using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    private void LateUpdate()
    {
        transform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, transform.position.z);
    }
}
