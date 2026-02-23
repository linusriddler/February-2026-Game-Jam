using UnityEngine;

public class RotationSinglePressButton : MonoBehaviour
{
    public Rigidbody objectToRotate;

    public Vector3 rotationAmount = new Vector3(0, 90f, 0); // rotate 90 degrees on Y
    public float rotationSpeed = 90f; // degrees per second

    private Quaternion startRotation;
    private Quaternion targetRotation;

    private bool activated = false;
    private bool isRotating = false;

    void Start()
    {
        startRotation = objectToRotate.rotation;
        targetRotation = startRotation * Quaternion.Euler(rotationAmount);
    }

    void FixedUpdate()
    {
        if (!isRotating) return;

        Quaternion newRotation = Quaternion.RotateTowards(
            objectToRotate.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime
        );

        objectToRotate.MoveRotation(newRotation);

        if (Quaternion.Angle(objectToRotate.rotation, targetRotation) < 0.1f)
        {
            objectToRotate.MoveRotation(targetRotation);
            isRotating = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;
            isRotating = true;
        }
    }
}