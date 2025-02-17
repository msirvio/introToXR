using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public int points = 1;
    public bool hit = false;

    Rigidbody rigidbody;
    /*void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.CompareTag("arrow"))
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Arrow Hit! Points: ");
            hit = true;
        }
    }

    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("arrow")) {
            rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            Debug.Log("Arrow in trigger zone, points: " + points);
            //Destroy(collision.gameObject);
        }
    }*/
}
