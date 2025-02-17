using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{

    TextMeshProUGUI text;
    public int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }
}
