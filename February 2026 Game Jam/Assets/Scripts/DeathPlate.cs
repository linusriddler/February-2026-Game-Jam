using UnityEngine;
using System.Collections;

public class DeathPlate : MonoBehaviour
{
    public Transform respawnPoint; // Assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            other.transform.position = respawnPoint.position;
        }
    }
}
