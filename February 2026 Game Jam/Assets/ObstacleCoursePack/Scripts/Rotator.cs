using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 90f;

    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(
            rotationAxis * rotationSpeed * Time.fixedDeltaTime
        );

        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}