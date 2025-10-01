using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject deadUI; // UI ที่จะแสดงเมื่อผู้เล่นตาย
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        deadUI.SetActive(true); // แสดง UI
        Time.timeScale = 0f; // หยุดเวลาในเกม
    }

    public void Retry()
    {
        Time.timeScale = 1f; // กลับมาเล่นเกมต่อ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // โหลดซีนปัจจุบันใหม่
    }

    public void Quit()
    {
        Time.timeScale = 1f; // กลับมาเล่นเกมต่อ
        SceneManager.LoadScene("MainMenu"); // โหลดซีน MainMenu
    }
}
