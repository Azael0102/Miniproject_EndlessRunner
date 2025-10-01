using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject deadUI; // UI �����ʴ�����ͼ����蹵��
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
        deadUI.SetActive(true); // �ʴ� UI
        Time.timeScale = 0f; // ��ش�������
    }

    public void Retry()
    {
        Time.timeScale = 1f; // ��Ѻ����������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ��Ŵ�չ�Ѩ�غѹ����
    }

    public void Quit()
    {
        Time.timeScale = 1f; // ��Ѻ����������
        SceneManager.LoadScene("MainMenu"); // ��Ŵ�չ MainMenu
    }
}
