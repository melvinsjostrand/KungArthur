//Script skriven av Hibba
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour {
    private Rigidbody rb;
    public Transform transform;
    public Camera camera;
    public CapsuleCollider col;

    public float speed = 4f;
    public float sprintSpeed = 9f;

    public float jumpHeight = 2;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    private float vertical;
    private float horizontal;

    private float cayoteTime = 0.2f;
    private float cayoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private void Awake() {
        camera.fieldOfView = 80;   
    }

    void Start() {
        rb = GetComponent<Rigidbody>(); 
    }  

    void Update() 
    {                               // Jump
        if (rb.velocity.y <= 0 && rb.velocity.y >= -0.001)
        {
            cayoteTimeCounter = cayoteTime;
        }
        else
        {
            cayoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
                                             
        if (jumpBufferCounter > 0f && cayoteTimeCounter > 0f) 
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

            jumpBufferCounter = 0f;
        }

        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            cayoteTimeCounter = 0f;
        }
    }

   void FixedUpdate() {
        float verticalPlayerInput = Input.GetAxisRaw(axisName: "Vertical");             // Hämtar vertical input.
        float horizontalPlayerInput = Input.GetAxisRaw(axisName: "Horizontal");         // Hämtar horizontal input.

        Vector3 forward = transform.InverseTransformVector (vector: Camera.main.transform.forward);
        Vector3 right = transform.InverseTransformVector (vector: Camera.main.transform.right);

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        float speed = this.speed;
        Vector3 forwardRelativeVerticalInput = verticalPlayerInput * forward * Time.fixedDeltaTime;         // Fixar movement för vertical movement.
        Vector3 rightRelativeHorizontalInput = horizontalPlayerInput * right * Time.fixedDeltaTime;         // Fixar movement för horizontal movement.

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        if(Input.GetKey(key: KeyCode.LeftShift)) { // Sprinting.
            speed = sprintSpeed;
            camera.fieldOfView = 90;  

        } else {
            camera.fieldOfView = 80;  
        }
        if(Input.GetKey(KeyCode.C)){ //crouching
            col.height = Mathf.Max(0.6f, col.height - Time.deltaTime*10f);
        }
        else{
            col.height = Mathf.Min(1.8f, col.height + Time.deltaTime*10f);
        }
        //if(velChange < 0.1)

        transform.Translate(translation: cameraRelativeMovement * speed, relativeTo: Space.World);
        //rb.AddForce();
    }
}