using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public GameObject gfx;
    public Animator animator;
    public PlayerCollision collision;

    public float acceleration = 0.1f, speed = 6f, turnSmooth = 0.05f, jumpHeight = 1.0f, sprintIncrease = 1.5f;
    public int jumpCount = 2;
    private float turnSmoothVelocity, timeSinceLastUse = 0, sprintMultiplier = 1f;
    private int currentJumpCount = 0;

    private bool canRoll = true;
    private Vector3 playerVelocity;


    // Start is called before the first frame update
    void Start()
    {
        animator = gfx.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            timeSinceLastUse = 0f;
        }
        else
        {
            timeSinceLastUse += Time.deltaTime;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        
        if (direction.magnitude > 0.05)
        {
            if (timeSinceLastUse > 2)
            {
                //Look towards where the player is moving
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmooth);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            else
            {
                //Look towards where the camera is looking
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, cam.eulerAngles.y, ref turnSmoothVelocity, turnSmooth);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
        }

        if (Input.GetButton("Sprint"))
        {
            sprintMultiplier = sprintIncrease;
            animator.SetBool("Sprint", true);

            canRoll = false;
        }
        else
        {
            sprintMultiplier = 1f;
            animator.SetBool("Sprint", false);

            canRoll = true;
        }


        Vector3 moveDir = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized * speed * sprintMultiplier * direction.magnitude;
        animator.SetFloat("Mag", moveDir.magnitude);

        playerVelocity = new Vector3(Mathf.Lerp(playerVelocity.x, moveDir.x, acceleration), playerVelocity.y, Mathf.Lerp(playerVelocity.z, moveDir.z, acceleration));

        if (controller.isGrounded)
        {
            playerVelocity.y = -1f;
            resetJumpCount();
            animator.SetBool("isGrounded", true);
        }
        else
        {
            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
            animator.SetBool("isGrounded", false);
        }

        if (Input.GetButtonDown("Jump") && currentJumpCount < jumpCount)
        {
            canRoll = false;
            rollEnded();
            currentJumpCount += 1;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y);
            animator.SetTrigger("Jump");
        }

        if(canRoll && controller.isGrounded) {
            if (Input.GetButton("Roll")) {
                collision.topCollider.transform.localPosition = new Vector3(0, 0.25f, 0);
                controller.height = 1;
                controller.center = new Vector3(0, -0.5f, 0);
            } else {
                rollEnded();
            }
        }

        animator.SetFloat("yVel", playerVelocity.y);
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void resetJumpCount()
    {
        currentJumpCount = 0;
    }

    public void rollEnded() {
        collision.topCollider.transform.localPosition = new Vector3(0, 0.9f, 0);
        controller.height = 2;
        controller.center = new Vector3(0, 0, 0);
    }
}
