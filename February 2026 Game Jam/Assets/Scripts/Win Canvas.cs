using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{
    public GameObject WinScreen;
    [SerializeField] private string menuSceneName;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuSceneName);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
