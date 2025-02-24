using UnityEngine;
using TMPro;

public class ArrowCountUpdater : MonoBehaviour
{
    TextMeshProUGUI text;
    public GameObject bow;
    BowLogic bowlogic; 
    public int arrows = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        bowlogic = bow.GetComponent<BowLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Arrows left: " + bowlogic.arrowsLeft;
    }
}
