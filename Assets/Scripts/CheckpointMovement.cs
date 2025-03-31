using UnityEngine;

public class MovingCheckpoint : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 5f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = moveSpeed * Time.deltaTime;
        if (movingRight)
        {
            transform.Translate(Vector2.right * movement);
            if (Vector2.Distance(transform.position, startPos) >= moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * movement);
            if (Vector2.Distance(transform.position, startPos) <= 0.1f)
                movingRight = true;
        }
    }
}