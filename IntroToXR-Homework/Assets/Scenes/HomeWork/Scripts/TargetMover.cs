using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    bool moveRight = true;
    float speed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight) {
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, speed);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, startPosition.position, speed);
        }

        //Change direction if at target
        if (transform.position.Equals(startPosition.position) ||
            transform.position.Equals(endPosition.position)) {
            moveRight = !moveRight;
        }
    }
}
