using UnityEngine;

public class RotationStopper : MonoBehaviour
{
    public GameObject rotatingObject;
    private bool isPressed = false;
    public Rotator scriptToDisable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed == true)
        {
            scriptToDisable.enabled = false;
        }
        else
        {
            scriptToDisable.enabled = true;
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
