using UnityEngine;
using UnityEngine.InputSystem;

public class BowLogic : MonoBehaviour
{
    bool grabbing = false;
    bool readyToShoot = false;
    public Transform gripPoint;
    public Transform pullPoint;
    public Transform defaultPoint;
    public Transform shootPoint;
    public Transform helper;
    public GameObject arrow;
    public GameObject bowString;
    Rigidbody arrowRigidBody;
    LineRenderer lineRenderer;
    public InputActionReference action1;
    public InputActionReference action2;

    float x = -0.2f;
    float y = 0.0f;
    float z = 0.0125f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action1.action.Enable();
        action2.action.Enable();
        lineRenderer = bowString.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        grabbing = action1.action.IsPressed() && action2.action.IsPressed();
        defaultPoint.LookAt(gripPoint);
        pullPoint.LookAt(gripPoint);
        shootPoint.LookAt(helper);
        shootPoint.Rotate(0, -90, 0);

        if (!grabbing) {
            if (readyToShoot) {
                //TAKE THE SHOT
                GameObject projectile = Instantiate(
                    arrow, 
                    shootPoint.position,
                    shootPoint.rotation
                );
                projectile.tag = "arrow";
                arrowRigidBody = projectile.GetComponent<Rigidbody>();
                //arrowRigidBody.velocity = Vector3.zero;
                if (arrowRigidBody != null) {
                    arrowRigidBody.AddForce(
                        defaultPoint.forward * 10, 
                        ForceMode.VelocityChange
                    );
                }

                pullPoint.position = defaultPoint.position;
                readyToShoot = false;
                lineRenderer.SetPosition(1, new Vector3(x, y, z));
            }
        } else {
            //Vector3 relativePos = gripPoint.transform.position - defaultPosition.transform.position;
            arrow.transform.position = pullPoint.position;
            Vector3 tempVector = pullPoint.position - gripPoint.position;
            float temp = tempVector[0];
            //arrow.transform.position += new Vector3(x, 0, 0);
            arrow.transform.LookAt(gripPoint);
            arrow.transform.Rotate(0, -90, 0);

            readyToShoot = true;

            Vector3 vector = new Vector3(x, y, z);
            lineRenderer.SetPosition(1, arrow.transform.position - gripPoint.transform.position);
        }
    }
}
