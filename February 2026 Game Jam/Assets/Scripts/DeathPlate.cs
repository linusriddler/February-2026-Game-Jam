using UnityEngine;

public class DeathPlate : MonoBehaviour
{
    public Transform[] respawnPoints; // Set multiple in Inspector

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

            Transform closestPoint = GetClosestSpawnPoint(other.transform.position);

            if (closestPoint != null)
            {
                other.transform.position = closestPoint.position;
            }
        }
    }

    Transform GetClosestSpawnPoint(Vector3 playerPosition)
    {
        Transform closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform point in respawnPoints)
        {
            float distance = Vector3.Distance(playerPosition, point.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = point;
            }
        }

        return closest;
    }
}
