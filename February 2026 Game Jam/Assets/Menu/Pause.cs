using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject container;
    [SerializeField] private string menuSceneName;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        container.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1 && (Input.GetKeyDown(KeyCode.Escape)))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0 && (Input.GetKeyDown(KeyCode.Escape)))
        {
            Resume();
        }
    }

    public void Resume()
    {
            container.SetActive(false);
            Time.timeScale = 1;
        
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuSceneName);
    }
}
