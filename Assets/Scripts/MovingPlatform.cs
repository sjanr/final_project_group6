using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;

    [Header("Platform Settings")]
    public float speed = 2f;
    public bool moveForward = true;

    private void Update()
    {
        if (moveForward)
        {
            platform.position = Vector2.MoveTowards(platform.position, endPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(platform.position, endPoint.position) < 0.1f)
                moveForward = false;
        }
        else
        {
            platform.position = Vector2.MoveTowards(platform.position, startPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(platform.position, startPoint.position) < 0.1f)
                moveForward = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(startPoint.position, endPoint.position);

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(startPoint.position, new Vector3(1, 1, 0));

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(endPoint.position, new Vector3(1, 1, 0));
        }
    }
}
