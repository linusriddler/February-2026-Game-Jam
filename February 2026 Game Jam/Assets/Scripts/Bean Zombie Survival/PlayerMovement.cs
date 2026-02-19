using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float jumpStrength = 5f;
    public Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private bool isGrounded = false;
    public int playerHealth = 10;
    public float moveSpeed = 5f;
    public float rotationSpeed = 150f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
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
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Danger"))
        {
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void Movement()
    {
        float turn = 0f;
        float move = 0f;

        // Movement
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
        anim.SetBool("isWalking", walking);
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