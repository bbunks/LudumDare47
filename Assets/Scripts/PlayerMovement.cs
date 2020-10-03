using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;   

    public float acceleration = 0.1f, speed = 6f, turnSmooth = 0.05f;
    private float turnSmoothVelocity, timeSinceLastUse = 0;
    private Vector3 playerVelocity;


    // Start is called before the first frame update
    void Start()
    {
        
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

        Vector3 moveDir = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized * speed * direction.magnitude;
        playerVelocity = new Vector3(Mathf.Lerp(playerVelocity.x, moveDir.x, acceleration), playerVelocity.y, Mathf.Lerp(playerVelocity.z, moveDir.z, acceleration));

        if (controller.isGrounded)
        {
            playerVelocity.y = -1f;
        }
        else
        {
            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
