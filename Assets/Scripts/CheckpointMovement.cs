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

    //simple movement script for the checkpoint boss
    void Update()
    {
        float movement = moveSpeed * Time.deltaTime;
        if (movingRight)
        {
            transform.Translate(Vector2.right * movement);
            if (Vector2.Distance(transform.position, startPos) >= moveDistance)
            {
                movingRight = false;
                transform.localScale = new Vector3((float)-0.25, (float)0.25, (float)0.25);
            }
        }
        else
        {
            transform.Translate(Vector2.left * movement);
            if (Vector2.Distance(transform.position, startPos) <= 0.1f)
            {
                movingRight = true;
                transform.localScale = new Vector3((float)0.25, (float)0.25, (float)0.25);
            }
        }
    }
}