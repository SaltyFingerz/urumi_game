using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This script controls the player movement, but also player health, player sounds and detecting when player moves into specific zones for triggering enemy chases.
    //for the generic vertical and horizontal player movement control, the tutorial available at: www.youtube.com/watch?v=f473C43s8nE was used.
    private GameObject chaseEnemyID; 
    public GameObject DeathScreen;
    public GameObject PauseMenu;   

    public Transform orientation;    

    public AudioClip DeathSound;
    public AudioClip Laughing;

//Sound Arrays used for random sounds from within each to be played

    [SerializeField] AudioClip[] HurtSounds;  // for implementing arrays of sounds and playing a sound from one randomly the tutorial available at : https://www.youtube.com/watch?v=OCRzBX3ON_c
    AudioSource hurtAudioSource;

    [SerializeField] AudioClip[] HurtSoundsLowHP;
    AudioSource veryHurtAudioSource;

    [SerializeField] AudioClip[] AreaCleared;
    AudioSource Pathetic;
    
    Rigidbody rb;

    public KeyCode jumpKey = KeyCode.Space;    
    Vector3 moveDirection;
    public LayerMask whatIsGround;

    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public float playerHeight;    

    float horizontalInput;
    float verticalInput;

    bool readyToJump = true;
    bool grounded;

    public static bool UrumiPicked;
    public static bool inRange = false;
    public static bool chase1;
    public static bool chase2;
    public static bool chase3;
    public static bool chase4;
    public static bool chase5;
    public static bool chase6;
    public static bool chase7;
    public static bool chase;

    public static int PlayerHealth = 50;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        hurtAudioSource = GetComponent<AudioSource>();
        veryHurtAudioSource = GetComponent<AudioSource>();
        Pathetic = GetComponent<AudioSource>();
    }

    private void MyInput() //function for getting horizontal and vertical input for player movement. Done following tutorial: www.youtube.com/watch?v=f473C43s8nE
    {
     
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
       
        

        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded) //done following tutorial: www.youtube.com/watch?v=f473C43s8nE
        {
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown); //invoke is used to allow for another jump after the jump cooldown time has passed.
            readyToJump = false;      //the player cannot jump again till the reset jump function is called
        }

    }

    private void MovePlayer() //done following tutorial: www.youtube.com/watch?v=f473C43s8nE
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; //to always walk in the direction the player is looking when walking forward. 

        //on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force); //the player can move in the air but with less speed, with an air multiplier of value less than 1. 

    }

    private void SpeedControl() //done following tutorial: www.youtube.com/watch?v=f473C43s8nE
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        //limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump() //done following tutorial: www.youtube.com/watch?v=f473C43s8nE
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); //impulse because only applying force once
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    void Update()
    {
        MyInput();
        SpeedControl();       
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (DirectionDetection.ShouldAttack)
        {
            moveSpeed = 0f; //this prevents the player from moving while giving input for an attack.
            
        }
        else
        {
            moveSpeed = 7f;
        }

        // handle drag
        if (grounded) //done following tutorial: www.youtube.com/watch?v=f473C43s8nE
        {
            rb.drag = groundDrag;
            
        }
        else
            rb.drag = 0;


        if (PlayerHealth <= 0) //Player Death
        {
            DeathScreen.SetActive(true); 
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(DeathSound);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; //cursor becomes visible to be able to interact with the Death Screen UI
            PlayerHealth = 50; //health reset so player isn't automatically dead on replaying level
        }


        if (chase)
        {
            if(chaseEnemyID.GetComponent<Animation>() != null) //to avoid trying to make scarecrow in tutorial chase player which causes an error message
            chaseEnemyID.GetComponent<EnemyController>().ChasePlayer(); //chase enemy ID is set below, by entering the trigger zone of an enemy, and refers to the gameobject of that enemy, allowing an ainstance of the enemycontroller script to be called from that enemy, and make only that enemy chase the player.
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //show & enable cursor movement
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0; //pauses time
            PauseMenu.SetActive(true); //activate pause menu
        }

    }

    public void Sounds() //function plays a random sound of the player getting hurt with above medium health points, from an array of sounds. Each sound is a voice with slightly different intonations
    {
        AudioClip clip = HurtSounds[UnityEngine.Random.Range(0, HurtSounds.Length)];
        hurtAudioSource.PlayOneShot(clip);
    }

    public void SoundsLowHP() // same as above but for below medium health points
    {
        AudioClip clip = HurtSoundsLowHP[UnityEngine.Random.Range(0, HurtSoundsLowHP.Length)];
        veryHurtAudioSource.PlayOneShot(clip);
    }

    public void PatheticSound() //random sound of the player character taunting her opponents by exclaiming "Pathetic!" called upon clearing the enemies of a room.
    {
        AudioClip clip = AreaCleared[UnityEngine.Random.Range(0, AreaCleared.Length)];
        Pathetic.PlayOneShot(clip);
    }

    public void VictoryLaugh() //Laugh of victory of the player chatacter played upon completing a level.
    {
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(Laughing);
    }

    private void FixedUpdate() //fixed update is used to move the player steadily across frames.
    {
        MovePlayer(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) //when the player enters the trigger collider attached to the skeletons, signifying that the player is in close vicinity to the enemy.
        {
            inRange = true;
            if(other.GetComponent<Animator>() != null)
            other.GetComponent<Animator>().SetBool("Attack", true); //triggers the eenmy to attack the player by initating the attack animation which contains an animation event that deals damage to the player
            chase = true; //makes the enemy chase the player via the if(Chase) condition in the update function above
            chaseEnemyID = other.gameObject; //the id of the enemy chasing the player is saved here to make this enemy specifically chase the player by refering to them with chaseEnemyID in the if(chase) condition in the update function above.
           if(other.GetComponent<Animator>() != null) //this is to avoid error of trying to make scarecrow chase player
                other.GetComponent<EnemyController>().ChasePlayer(); //function name
        }

        if (other.CompareTag("ChaseZone1")) //this and the following triggers are trigger boxes placed around the level to trigger different waves of enemies to chase the player as they explore the level.
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
        if (other.CompareTag("Urumi")) //this trigger volume is attached to the urumi sword pick up
        {
            UrumiPicked = true;
            other.gameObject.SetActive(false);
        }

    }

 

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) //upon exiting the vicinity of the enemy this is logged via the public static bool inRange, refered to by DirectionDetection script, for resetting booleans describing the enemy's defense, 
        {
            inRange = false;
            other.GetComponent<Animator>().SetBool("Attack" , false); // stops the enemy from attacking when the player is too far away
        }
    }
}
