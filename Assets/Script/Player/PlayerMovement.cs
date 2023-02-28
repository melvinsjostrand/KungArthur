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

    public float jumpHeight = 1;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    private float vertical;
    private float horizontal;

    private void Awake() {
        camera.fieldOfView = 80;   
    }

    void Start() {
        rb = GetComponent<Rigidbody>(); 
    }  

    void Update() {                                                     // Jump
        if(Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0) {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
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

        transform.Translate(translation: cameraRelativeMovement * speed, relativeTo: Space.World);
    }
}