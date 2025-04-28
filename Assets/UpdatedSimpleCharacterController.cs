using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class UpdatedSimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of horizontal movement
    public float jumpForce = 8f; // Force of jump
    public float gravity = -20f; // Gravity strength
    public int maxJumpCount = 2; // Maximum number of allowed jumps
    public float maxFallSpeed = -20f; // Maximum fall speed limit

    private CharacterController controller;
    private Vector3 velocity;
    private Transform characterTransform;
    private int currentJumpCount;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        characterTransform = transform;
        currentJumpCount = 0;
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
    }

    private void MoveCharacter()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(moveInput, 0f, 0f) * moveSpeed;
        controller.Move(move * Time.deltaTime);

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (controller.isGrounded)
            {
                Jump();
                currentJumpCount = 1;
            }
            else if (currentJumpCount < maxJumpCount)
            {
                Jump();
                currentJumpCount++;
            }
        }
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to stick to ground
            currentJumpCount = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            velocity.y = Mathf.Max(velocity.y, maxFallSpeed); // Limit the fall speed
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        Vector3 currentPosition = characterTransform.position;
        currentPosition.z = 0f;
        characterTransform.position = currentPosition;
    }
}
