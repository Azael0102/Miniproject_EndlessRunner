using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highScoreText.text = "Best Meter: " + Mathf.FloorToInt(highScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
