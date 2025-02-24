using UnityEngine;

public class ResetScript : MonoBehaviour
{

    public GameObject scoreCounter;
    public GameObject bow;
    bool readyToReset = false;
    ScoreUpdater scoreUpdater;
    BowLogic arrowUpdater;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreUpdater = scoreCounter.GetComponent<ScoreUpdater>();
        arrowUpdater = bow.GetComponent<BowLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToReset) {

            scoreUpdater.SetScore(0);
            arrowUpdater.SetArrowCount(10);

            GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
            foreach(GameObject arrow in arrows) {
                if (arrow.name == "Arrow") {
                    Destroy(arrow);
                }
            }

            readyToReset = false;
        }
    }

    public void ActivateReset() {
        readyToReset = true;
    }
}
