using UnityEngine;
public class PlayerMovement : MonoBehaviour {

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundedCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;
    private Vector3 velocity;
    public int jumpNumber;
    private CharacterController controller;
    public Transform cam;
    private float speed = 6f;
    private float turnSmoothVelocity;

    void Start() {
        controller = GetComponent<CharacterController>();
    }
    void Update() {
        isGrounded = Physics.CheckSphere(transform.position, groundedCheckDistance, groundMask);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (isGrounded) {
            if (direction.magnitude > 0) {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
                Vector3 moveDir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                controller.Move(moveDir * speed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumpNumber++;
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
