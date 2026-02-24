using System.Collections;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
    public float fallTime = 0.5f;

    private Renderer rend;
    private Collider col;
    private bool isFalling = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(Fall(fallTime));
        }
    }

    IEnumerator Fall(float time)
    {
        isFalling = true;

        yield return new WaitForSeconds(time);

        rend.enabled = false;
        col.enabled = false;

        yield return new WaitForSeconds(2);

        rend.enabled = true;
        col.enabled = true;

        isFalling = false;
    }
}