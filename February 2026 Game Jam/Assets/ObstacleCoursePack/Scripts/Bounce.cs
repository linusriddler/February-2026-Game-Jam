using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force = 15f;
    public float upwardBoost = 5f;
    public float stunTime = 0.5f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
    }
}