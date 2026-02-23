using UnityEngine;
using UnityEngine.UIElements;

public class Player2Movement : MonoBehaviour
{
    public Animator anim2;
    public float jumpStrength2 = 5f;
    public Rigidbody rb2;
    private float horizontalInput2;
    private float verticalInput2;
    private bool isGrounded2 = false;
    public int playerHealth2 = 10;
    public float moveSpeed2 = 5f;
    public float rotationSpeed2 = 150f;
    public AudioSource walkAudio2;
    public AudioClip jumpClip2;

    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        anim2 = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded2)
        {
            Jump2();
        }
    }

    private void FixedUpdate()
    {
        Movement2();
    }

    void Jump2()
    {
        rb2.AddForce(Vector3.up * jumpStrength2, ForceMode.Impulse);

        if (jumpClip2 != null)
        {
            walkAudio2.PlayOneShot(jumpClip2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded2 = true;
        }

        if (collision.gameObject.CompareTag("Danger"))
        {
            anim2.SetBool("isFalling", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded2 = false;
        }

        if (collision.gameObject.CompareTag("Danger"))
        {
            anim2.SetBool("isFalling", false);
        }
    }

    private void Movement2()
    {
        float turn2 = 0f;
        float move2 = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            turn2 = -rotationSpeed2 * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
            turn2 = rotationSpeed2 * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
            move2 = moveSpeed2 * Time.deltaTime;

        if (Input.GetKey(KeyCode.DownArrow))
            move2 = -moveSpeed2 * Time.deltaTime;

        transform.Translate(0f, 0f, move2);
        transform.Rotate(0, turn2, 0f);

        bool walking2 = Mathf.Abs(move2) > 0.01f;
        anim2.SetBool("isWalking", walking2);

        // 🔊 Footstep sound
        if (walking2 && isGrounded2)
        {
            if (!walkAudio2.isPlaying)
                walkAudio2.Play();
        }
        else
        {
            if (walkAudio2.isPlaying)
                walkAudio2.Stop();
        }

        Debug.Log("Walking = " + walking2);
    }

    public void TakeDamage(int amount2)
    {
        playerHealth2 -= amount2;
        Debug.Log("Player hit! Health: " + playerHealth2);

        if (playerHealth2 <= 0)
        {
            Debug.Log("Player Died");
        }
    }
}