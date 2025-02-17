using UnityEngine;

public class StringUpdater : MonoBehaviour
{
    LineRenderer lineRenderer;
    public GameObject gripPoint;
    public GameObject pullObject;

    float x = -0.2f;
    float y = 0.0f;
    float z = 0.0125f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 tempVector = pullObject.transform.position - gripPoint.transform.position;
        //x = tempVector[0];
        //Vector3 vector = new Vector3(x, y, z);
        //lineRenderer.SetPosition(1, vector);
    }
}
