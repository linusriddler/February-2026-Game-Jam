using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float jumpStrength = 5f;
    public Rigidbody rb;
    private bool isGrounded = false;
    public int playerHealth = 10;
    public float moveSpeed = 5f;
    public float rotationSpeed = 150f;
    public AudioSource walkAudio;
    public AudioSource JumpAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        
        JumpAudio.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
    }

    private void Movement()
    {
        float turn = 0f;
        float move = 0f;

        if (Input.GetKey(KeyCode.A))
            turn = -rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            turn = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
            move = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            move = -moveSpeed * Time.deltaTime;

        transform.Translate(0f, 0f, move);
        transform.Rotate(0, turn, 0f);

        // Walking animation
        bool walking = Mathf.Abs(move) > 0.01f;
        anim.SetBool("isWalking", walking && isGrounded);

        // 🔊 Walking sound
        if (walking && isGrounded)
        {
            if (!walkAudio.isPlaying)
                walkAudio.Play();
        }
        else
        {
            if (walkAudio.isPlaying)
                walkAudio.Stop();
        }
    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        Debug.Log("Player hit! Health: " + playerHealth);

        if (playerHealth <= 0)
        {
            Debug.Log("Player Died");
        }
    }
}