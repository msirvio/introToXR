using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)
    //CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    
    bool grabbing = false;

    //Position and rotation
    private Vector3 relativePos;
    private Vector3 deltaPos;
    private Vector3 previousPos;
    private Quaternion deltaRot;
    private Quaternion previousRot;

    //For the extra feature
    //bool isMultiplied = false;
    //public InputActionReference actionForMultiplier;

    private void Start()
    {
        action.action.Enable();
        //actionForMultiplier.action.Enable();
        /* DOUBLE GRAB DISABLED
        // Find the other hand
        foreach(CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }*/
    }

    void Update()
    {
        //Extra feature
        //isMultiplied = actionForMultiplier.action.IsPressed();

        grabbing = action.action.IsPressed();
        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
                //DOUBLE GRAB DISABLED
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : null;//otherHand.grabbedObject;

            if (grabbedObject)
            {
                // Change these to add the delta position and rotation instead
                // Save the position and rotation at the end of Update function, so you can compare previous pos/rot to current here

                deltaPos = transform.position - previousPos;
                deltaRot = transform.rotation * Quaternion.Inverse(previousRot);

                //Vector from hand to object, rotated correctly
                relativePos = grabbedObject.position - transform.position;
                relativePos = deltaRot * relativePos;



                //EXIT LEVER or other object
                if (grabbedObject.gameObject.name == "ExitLever") {
                    grabbedObject.LookAt(transform, Vector3.up);
                    float rotationX = grabbedObject.eulerAngles.x;
                    grabbedObject.rotation = Quaternion.Euler(rotationX, 0, 0);

                    if (rotationX < 20.0f) {
                        QuitScript.Quit();
                    }

                } else {
                    //Grabbed object's new pos and rot
                    grabbedObject.position = transform.position + relativePos + deltaPos;
                    grabbedObject.rotation = deltaRot * grabbedObject.rotation;
                }


                //Add second rotation and position change, if multiplication is set on!
                /*if (isMultiplied) {
                    grabbedObject.rotation = deltaRot * grabbedObject.rotation;
                    relativePos = deltaRot * relativePos;
                    grabbedObject.position = transform.position + relativePos + deltaPos;
                }*/

                //grabbedObject.position = transform.position;
                //grabbedObject.rotation = transform.rotation;
            }
        }
        // If let go of button, release object
        else if (grabbedObject)
            grabbedObject = null;

        // Should save the current position and rotation here
        previousPos = transform.position;
        previousRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if(t && t.tag.ToLower()=="grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if( t && t.tag.ToLower()=="grabbable")
            nearObjects.Remove(t);
    }
}