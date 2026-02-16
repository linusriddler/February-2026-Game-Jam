using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
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
        float turn = Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
        float move = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(0f, 0f, move);
        transform.Rotate(0, turn, 0f);
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