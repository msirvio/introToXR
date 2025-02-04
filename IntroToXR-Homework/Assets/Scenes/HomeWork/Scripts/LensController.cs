using UnityEngine;

public class LensController : MonoBehaviour {

    public Transform playerCamera;
    public Transform lensCamera;
    
    //Helper is an object, offset from the lens and pointed the opposite direction. 
    //Lens camera is set to look straight at it. 
    //See magnifying glass...
    public Transform helper;

    void Update() {
        //LensObject will look at player
        transform.LookAt(playerCamera, transform.parent.up);

        //Aim lens camera at helper (opposite direction)
        lensCamera.LookAt(helper);
        lensCamera.rotation = helper.rotation;
    }
}
