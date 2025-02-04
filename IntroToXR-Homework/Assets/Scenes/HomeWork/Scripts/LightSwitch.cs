using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public InputActionReference action;
    public Light light;
    void Start()
    {
        light = GetComponent<Light>();
        Color originalColor = light.color;

        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (light.color == originalColor) {
                light.color = Color.blue;
            } else {
                light.color = originalColor;
            }
        };
    }
}
