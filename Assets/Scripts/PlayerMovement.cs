using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
     public float moveSpeed;
     public float groundDrag;

     [Header("Jump")]

     public float jumpForce;
     public float jumpCooldown;
     public float airMultiplier;
     bool readyToJump = true;

     [Header("Keybinds")]
     public KeyCode jumpKey = KeyCode.Space;


     [Header("Ground Check")]
     public float playerHeight;
     public LayerMask whatIsGround;
    public LayerMask multiButton;
     bool grounded;
    bool grounded2;

    //  [Header("Stats")]
    //  public float cash = 0;
    //  public float multi = 1;


     public Transform orientation;

     float horizontalInput;
     float verticalInput;

     Vector3 moveDirection;

     Rigidbody rb;
    
    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


     
     void Update()
     {
         grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * (0.5f + 0.2f), whatIsGround);
         grounded2 = Physics.Raycast(transform.position, Vector3.down, playerHeight * (0.5f + 0.2f), multiButton);
        MyInput();
         SpeedControl();
         
         if(grounded)
         {
            rb.drag = groundDrag;
         }
         else 
         {
            rb.drag = 2;
         }
        if (grounded == false && grounded2 == true)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 2;
        }
         
         
     }
     void FixedUpdate(){
        MovePlayer();
     }
     private void MyInput(){
         
         horizontalInput = Input.GetAxisRaw("Horizontal");
         verticalInput = Input.GetAxisRaw("Vertical");
         
         if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
         }
         else if(Input.GetKey(jumpKey) &&readyToJump && grounded2)
        {
            readyToJump=false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
     }

     private void MovePlayer()
        {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

         if(grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
         
         else if(!grounded&&grounded2) rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded)
                 rb.AddForce(moveDirection.normalized * moveSpeed * 10f* airMultiplier, ForceMode.Force); 
         
         

     }
     private void SpeedControl()
     {
         Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

         if(flatVel.magnitude>moveSpeed)
         {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
         }
     }
     private void Jump(){
      rb.velocity = new Vector3(rb.velocity.x, 0f,rb.velocity.z);
      rb.AddForce(transform.up*jumpForce, ForceMode.Impulse);
     }
     private void ResetJump()
     {
         readyToJump = true;
     }
    //  public void StatGain()
    //  {
    //     if(multi>0)
    //     {
    //         cash += 1*multi;
    //         print(cash);
    //     }
    //  }
}
