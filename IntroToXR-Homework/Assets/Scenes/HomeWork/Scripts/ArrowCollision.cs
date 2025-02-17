using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    public bool hit = false;
    public GameObject scoreCounter;
    /*void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.CompareTag("target"))
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Arrow Collision!: " + hit2);
            hit2 = true;
        }
    }*/

    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("target") && !hit) {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            int point = collision.gameObject.GetComponent<CollisionChecker>().points;
            Debug.Log("Arrow trigger: " + point);
            scoreCounter.GetComponent<ScoreUpdater>().score += point;
            //Destroy(collision.gameObject);
            hit = true;
        }
    }
}
