using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public GameObject target;
    
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 10 * Time.deltaTime);
    }
}
