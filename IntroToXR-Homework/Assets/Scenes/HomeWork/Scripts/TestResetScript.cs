using UnityEngine;
using UnityEngine.InputSystem;

public class TestResetScript : MonoBehaviour
{
    public InputActionReference action;
    public GameObject button;

    ResetScript reset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reset = button.GetComponent<ResetScript>();
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            reset.ActivateReset();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
