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

        Vector3 fromPullToGrip = pullPoint.position - gripPoint.position;
        fromPullToGrip = pullPoint.rotation * fromPullToGrip;
        
        defaultPoint.LookAt(gripPoint);
        pullPoint.LookAt(gripPoint);
        pullPoint.Rotate(0, -90, 0);
        //transform.rotation = pullPoint.rotation;

        shootPoint.LookAt(helper);
        shootPoint.Rotate(0, -90, 0);

        if (!grabbing) {
            if (readyToShoot) {
                //TAKE THE SHOT
                GameObject projectile = Instantiate(
                    arrow, 
                    shootPoint.position,
                    pullPoint.rotation
                );
                projectile.tag = "arrow";
                arrowRigidBody = projectile.GetComponent<Rigidbody>();

                if (arrowRigidBody != null) {
                    arrowRigidBody.AddForce(
                        pullPoint.right * 20 * fromPullToGrip.magnitude, 
                        ForceMode.VelocityChange
                    );
                }

                pullPoint.position = defaultPoint.position;
                readyToShoot = false;
                float x = -0.2f, y = 0.0f, z = 0.0125f;
                lineRenderer.SetPosition(1, new Vector3(x, y, z));
            }
        } else {
            arrow.transform.position = pullPoint.position;
            arrow.transform.LookAt(gripPoint);
            arrow.transform.Rotate(0, -90, 0);

            readyToShoot = true;

            lineRenderer.SetPosition(1, pullPoint.localPosition);
        }
    }
}
