using JetBrains.Annotations;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public GameObject Menu;

    void Start()
    {
        gameObject.SetActive(false);
    }

    
    public void howToPlay()
    {
        Menu.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Back()
    {
        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
    
}
