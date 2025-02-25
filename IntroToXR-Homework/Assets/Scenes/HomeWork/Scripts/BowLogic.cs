using UnityEngine;
using UnityEngine.InputSystem;

public class BowLogic : MonoBehaviour
{
    bool grabbing = false;
    bool readyToShoot = false;
    public GameObject leftHand;
    public GameObject rightHand;
    public Transform gripPoint;
    public GameObject pullPoint;
    public Transform defaultPoint;
    public Transform shootPoint;
    public Transform helper;
    public GameObject arrow;
    public GameObject bowString;
    Rigidbody arrowRigidBody;
    LineRenderer lineRenderer;
    CustomGrab leftGrab, rightGrab;

    public int arrowsLeft = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = bowString.GetComponent<LineRenderer>();
        leftGrab = leftHand.GetComponent<CustomGrab>();
        rightGrab = rightHand.GetComponent<CustomGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        bool leftGrabbing = false;
        bool rightGrabbing = false;

        if (leftGrab.grabbedObject != null) {
            if (GameObject.ReferenceEquals(leftGrab.grabbedObject.gameObject, pullPoint)) {
                leftGrabbing = true;
            }
        } 
        if (rightGrab.grabbedObject != null) {
            if (GameObject.ReferenceEquals(rightGrab.grabbedObject.gameObject, pullPoint)) {
                rightGrabbing = true;
            }
        }

        grabbing = leftGrabbing || rightGrabbing;
        
        Vector3 fromPullToGrip = pullPoint.transform.position - gripPoint.position;
        fromPullToGrip = pullPoint.transform.rotation * fromPullToGrip;
        
        defaultPoint.LookAt(gripPoint);
        pullPoint.transform.LookAt(gripPoint);
        pullPoint.transform.Rotate(0, -90, 0);

        shootPoint.LookAt(helper);
        shootPoint.Rotate(0, -90, 0);

        if (arrowsLeft <= 0) {
            pullPoint.transform.position = defaultPoint.position;
        } else if (grabbing) {

            if (leftGrabbing) {
                pullPoint.transform.position = leftHand.transform.position;
            } else if (rightGrabbing) {
                pullPoint.transform.position = rightHand.transform.position;
            }
            arrow.transform.position = pullPoint.transform.position;
            arrow.transform.LookAt(gripPoint);
            arrow.transform.Rotate(0, -90, 0);

            readyToShoot = true;

            lineRenderer.SetPosition(1, pullPoint.transform.localPosition);

        } else if (readyToShoot) {
            //TAKE THE SHOT
            GameObject projectile = Instantiate(
                arrow, 
                shootPoint.position,
                pullPoint.transform.rotation
            );
            projectile.tag = "arrow";
            projectile.name = "Arrow";
            arrowRigidBody = projectile.GetComponent<Rigidbody>();

            if (arrowRigidBody != null) {
                arrowRigidBody.AddForce(
                    pullPoint.transform.right * 20 * fromPullToGrip.magnitude, 
                    ForceMode.VelocityChange
                );
            }

            arrowsLeft--;
            pullPoint.transform.position = defaultPoint.position;
            readyToShoot = false;
            float x = -0.2f, y = 0.0f, z = 0.0125f;
            lineRenderer.SetPosition(1, new Vector3(x, y, z));
        }
    }

    public void SetArrowCount(int arrowCount) {
        arrowsLeft = arrowCount;
    }
}
