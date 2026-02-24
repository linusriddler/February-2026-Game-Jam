using UnityEngine;

public class CreationButton : MonoBehaviour
{
    public GameObject createdObject;

    private bool isPressed = false;

    void Start()
    {
        createdObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isPressed == true)
        {
            createdObject.SetActive(true);
        }
        else
        {
            createdObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = false;
        }
    }
}