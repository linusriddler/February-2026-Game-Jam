using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 3.0f;
    public Vector3 direction = Vector3.forward;
    private List<Rigidbody> objectsOnBelt = new List<Rigidbody>();

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            objectsOnBelt.Add(rb);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            objectsOnBelt.Remove(rb);
        }
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rb in objectsOnBelt)
        {
            Vector3 movement = transform.TransformDirection(direction) * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }
}