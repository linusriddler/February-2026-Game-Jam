using UnityEngine;

public class Button : MonoBehaviour
{
    public Transform objectToMove;

    public Vector3 loweredOffset = new Vector3(0, -2f, 0);
    public float moveSpeed = 3f;

    private Vector3 startPosition;
    private Vector3 loweredPosition;
    private bool isPressed = false;

    void Start()
    {
        startPosition = objectToMove.position;
        loweredPosition = startPosition + loweredOffset;
    }

    void Update()
    {
        Vector3 target = isPressed ? loweredPosition : startPosition;
        objectToMove.position = Vector3.Lerp(objectToMove.position, target, moveSpeed * Time.deltaTime);
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