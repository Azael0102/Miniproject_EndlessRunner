using UnityEngine;
using TMPro;

public class ScoreByDistance : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; // Text �ʴ� High Score

    private Vector3 startPos;
    private float score;

    void Start()
    {
        // �纵��˹��������
        startPos = player.position;

        // ��Ŵ High Score ����ºѹ�֡
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        if (highScoreText != null)
            highScoreText.text = "Best: " + Mathf.FloorToInt(highScore).ToString();
    }

    void Update()
    {
        // �ӹǳ���зҧ
        float distance = player.position.z - startPos.z;
        score = distance;

        // �ѻവ��ͤ�����ṹ�Ѩ�غѹ
        scoreText.text = "Meter: " + Mathf.FloorToInt(score).ToString();

        // �������ʶԵ��������
        if (score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();

            if (highScoreText != null)
                highScoreText.text = "Best Meter: " + Mathf.FloorToInt(score).ToString();
        }
    }
}
