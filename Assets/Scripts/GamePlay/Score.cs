using UnityEngine;
using TMPro;

public class ScoreByDistance : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; // Text แสดง High Score

    private Vector3 startPos;
    private float score;

    void Start()
    {
        // เก็บตำแหน่งเริ่มต้น
        startPos = player.position;

        // โหลด High Score ที่เคยบันทึก
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        if (highScoreText != null)
            highScoreText.text = "Best: " + Mathf.FloorToInt(highScore).ToString();
    }

    void Update()
    {
        // คำนวณระยะทาง
        float distance = player.position.z - startPos.z;
        score = distance;

        // อัปเดตข้อความคะแนนปัจจุบัน
        scoreText.text = "Meter: " + Mathf.FloorToInt(score).ToString();

        // เช็คว่าได้สถิติใหม่ไหม
        if (score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();

            if (highScoreText != null)
                highScoreText.text = "Best Meter: " + Mathf.FloorToInt(score).ToString();
        }
    }
}
