using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public InputActionReference action;
    public GameObject player;
    public GameObject outsidePlane;


    void Start()
    {
        bool playerIsInside = true;
        Vector3 outsidePos = outsidePlane.transform.position;
        Vector3 insidePos = new Vector3(0,0,0);
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (playerIsInside) {
                player.transform.position = outsidePos;
            } else {
                player.transform.position = insidePos;
            }
            playerIsInside = !playerIsInside;
        };
    }
}
