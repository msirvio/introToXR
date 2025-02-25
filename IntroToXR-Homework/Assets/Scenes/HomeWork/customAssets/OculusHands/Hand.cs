using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    //Animation
    Animator animator;
    private float gripTarget;
    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    public float animationSpeed;

    //Physics
    public GameObject followObject;
    public float followSpeed = 30f;
    public float rotateSpeed = 100f;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Animation
        animator = GetComponent<Animator>();

        //Physics
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //AnimateHand();
    }

    void FixedUpdate() {
        PhysicsMove();
        AnimateHand();
    }

    private void PhysicsMove() {
        //Position
        var positionWithOffset = followTarget.position + positionOffset;
        //var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.linearVelocity = (positionWithOffset - transform.position) / Time.fixedDeltaTime; //.normalized * (followSpeed * distance);

        //Rotation
        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);

        if (Mathf.Abs(axis.magnitude) != Mathf.Infinity) {
            if (angle > 180.0f) {
                angle -= 360.0f;
            }
            Vector3 rotationDifferenceInDegree = angle * axis;
            body.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
        }
    }

    internal void SetGrip(float target) {
        gripTarget = target;
    }

    internal void SetTrigger(float target) {
        triggerTarget = target;
    }

    private void AnimateHand() {
        if (gripCurrent != gripTarget) {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.fixedDeltaTime * animationSpeed);
            animator.SetFloat("Grip", gripCurrent);
        }
        if (triggerCurrent != triggerTarget) {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.fixedDeltaTime * animationSpeed);
            animator.SetFloat("Trigger", triggerCurrent);
        }
    }

}
