using UnityEngine;

public class ResetScript : MonoBehaviour
{

    public GameObject scoreCounter;
    public GameObject bow;
    public Transform bowResetLocation;
    ScoreUpdater scoreUpdater;
    BowLogic arrowUpdater;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreUpdater = scoreCounter.GetComponent<ScoreUpdater>();
        arrowUpdater = bow.GetComponent<BowLogic>();
    }

    public void ActivateReset() {
        scoreUpdater.SetScore(0);
        arrowUpdater.SetArrowCount(10);

        GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
        foreach(GameObject arrow in arrows) {
            if (arrow.name == "Arrow") {
                Destroy(arrow);
            }
        }
        bow.transform.position = bowResetLocation.position;
        bow.transform.rotation = bowResetLocation.rotation;
    }
}
