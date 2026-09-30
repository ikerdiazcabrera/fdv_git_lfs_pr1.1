using UnityEngine;

public class MovementArrows : MonoBehaviour
{

    [SerializeField]
    float maxPlayerSpeed = 5.0f;
    float playerSpeed = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set RigidBody3D component to the variable rb
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Arrow keys Movement function in a 3D environment using the RigidBody3D component. This function is called every fixed frame-rate frame.
    void FixedUpdate()
    {
        // Get the RigidBody3D component of the player
        Rigidbody rb = GetComponent<Rigidbody>();

        // Get the input from the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 variable to store the movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Normalize the movement vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Calculate the player's speed based on the input and max speed
        playerSpeed = movement.magnitude * maxPlayerSpeed;

        // Move the player using the RigidBody3D component
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    // El personaje se cae, cancelar la rotación del personaje cuando se cae
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Cancelar la rotación del personaje cuando se cae
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }
    }
}
