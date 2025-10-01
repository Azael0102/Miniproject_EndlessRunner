using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredit : MonoBehaviour
{
    public RectTransform creditText; // Assign in Inspector
    public float scrollSpeed = 50f; // Speed of scrolling
    public float endY = 1000f; // Y position to reset to
    public string mainMenuSceneName = "MainMenu"; // Name of the main menu scene
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        creditText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (creditText.anchoredPosition.y >= endY)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
