using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static int PlayerHealth = 100;
    public static bool inRange = false;
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    public GameObject DeathScreen;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;
    public AudioClip DeathSound;
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public GameObject SkeletonZone1;
    public GameObject SkeletonZone2;
    public GameObject SkeletonZone3;
    public GameObject SkeletonZone4;
    public GameObject SkeletonZone5;
    public GameObject SkeletonZone6;
    public GameObject SkeletonZone7;
    public GameObject SkeletonWave2a;
    public GameObject SkeletonWave2b;
    public GameObject SkeletonWave3a;
    public GameObject SkeletonWave3b;
    public GameObject SkeletonWave3c;
    public GameObject SkeletonWave4a;
    public GameObject SkeletonWave4b;
    public GameObject SkeletonWave4c;
    public GameObject SkeletonWave4d;
    private bool chase1;
    private bool chase2;
    private bool chase3;
    private bool chase4;
    private bool chase5;
    private bool chase6;
    private bool chase7;
    private bool chase;
    Vector3 moveDirection;
    private GameObject chaseEnemyID;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void MyInput()
    {
     
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
       
        

        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
            readyToJump = false;
            
        }

    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; //to always walk in the direction the player is looking when walking forward

        //on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); //impulse because only applying force once
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (DirectionDetection.ShouldAttack)
        {
            moveSpeed = 0f;
            print("speed 0 cause should attack");
        }
        else
        {
            moveSpeed = 7f;
        }
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
            
        }
        else
            rb.drag = 0;


        if (PlayerHealth <= 0)
        {
            DeathScreen.SetActive(true);
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(DeathSound);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerHealth = 10;
        }


        if (chase1)
        {
            SkeletonZone1.GetComponent<EnemyController>().ChasePlayer();
        }

         if (chase2)
        {
            SkeletonZone2.GetComponent<EnemyController>().ChasePlayer();
        }

         if (chase)
        {
            chaseEnemyID.GetComponent<EnemyController>().ChasePlayer();
        }
         if(chase3)
        {
            SkeletonZone3.GetComponent<EnemyController>().ChasePlayer();
        }
        if (chase4)
        {
            SkeletonZone4.GetComponent<EnemyController>().ChasePlayer();
        }
        if (chase5)
        {
            SkeletonZone5.GetComponent<EnemyController>().ChasePlayer();
        }
        if (chase6)
        {
            SkeletonZone6.GetComponent<EnemyController>().ChasePlayer();
        }
        if (chase7)
        {
            SkeletonZone7.GetComponent<EnemyController>().ChasePlayer();
        }

        if(!SkeletonZone7.activeSelf)
        {
            SkeletonWave2a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave2b.GetComponent<EnemyController>().ChasePlayer();
        }
        if(!SkeletonWave2a.activeSelf && !SkeletonWave2b.activeSelf)
        {
            SkeletonWave3a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave3b.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave3c.GetComponent<EnemyController>().ChasePlayer();
        }
        if(!SkeletonWave3a.activeSelf && !SkeletonWave3b.activeSelf && !SkeletonWave3c.activeSelf)
        {
            SkeletonWave4a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4b.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4c.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4d.GetComponent<EnemyController>().ChasePlayer();
        }

    }
    private void FixedUpdate()
    {
        MovePlayer(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            inRange = true;
            print("enemy attack");
            other.GetComponent<Animator>().SetBool("Attack", true);
            chase = true;
            chaseEnemyID = other.gameObject;
           other.GetComponent<EnemyController>().ChasePlayer(); //function name

        }

        if (other.CompareTag("ChaseZone1"))
        {
            chase1 = true;
        }

         if (other.CompareTag("ChaseZone2"))
        {
            chase2 = true;
        }
         if(other.CompareTag("ChaseZone3"))
        {
            chase3 = true;
        }
        if (other.CompareTag("ChaseZone4"))
        {
            chase4= true;
        }
        if (other.CompareTag("ChaseZone5"))
        {
            chase5 = true;
        }
        if (other.CompareTag("ChaseZone6"))
        {
            chase6 = true;
        }
        if (other.CompareTag("ChaseZone7"))
        {
            chase7 = true;
        }

    }

 

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            inRange = false;
            DirectionDetection.EnemyID = null;
            DirectionDetection.enemyCenterHit = false;
            DirectionDetection.enemyLeftHit = false;
            DirectionDetection.enemyRightHit = false;
            DirectionDetection.enemyDownHit = false;
            DirectionDetection.enemyUpHit = false;
  
            print("enemy stop attack");
            other.GetComponent<Animator>().SetBool("Attack" , false);
        }
    }
}
