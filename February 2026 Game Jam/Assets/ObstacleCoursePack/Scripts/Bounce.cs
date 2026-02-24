using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force = 15f;
    public float upwardBoost = 5f;
    public float stunTime = 0.5f;

    
        private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb == null)
            return;

        Vector3 bounceDir = (collision.transform.position - transform.position).normalized;

        bounceDir += Vector3.up * 0.4f;
        bounceDir.Normalize();

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(bounceDir * 20f, ForceMode.Impulse);
    }
}
