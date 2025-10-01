using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToPlay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (howToPlay != null && howToPlay.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape))
            {
                howToPlay.SetActive(false);
                if (mainMenu != null)
                {
                    mainMenu.SetActive(true);
                }
            }
                
        }
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void HowToPlay()
    {
        if (howToPlay != null && mainMenu != null)
        {
            mainMenu.SetActive(false);
            howToPlay.SetActive(true);
        }
    }

    public void OpenCredit()
    {
        SceneManager.LoadScene("EndCreditScene");
    }
}
