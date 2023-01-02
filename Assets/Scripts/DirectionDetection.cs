using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{

    public GameObject lastHit;
    public GameObject HitParticle;
    public GameObject correctTick;
    public GameObject incorrectCross;
    public GameObject cam;
    public GameObject cam2; 
    public GameObject targetPoint;
    public GameObject Sword, Urumi;
    public static GameObject EnemyID; //public static so that it can be referenced by DamageTiming script (which contains animation event functions that deal damage to the enemy), so that damage is dealth to only the enemy that is being attacked
  
    public AudioClip SwordAttackSound;
    public AudioClip WhipAttackSound;
    public AudioClip SwordClashSound;

    private TrailRenderer tr;

    public Transform orientation;

    RaycastHit whatHit;
    Vector3 collision = Vector3.zero;
    Vector3 target = new Vector3(0, 0, 10);

    
    [SerializeField]
    private  float mouseXMove;
    [SerializeField]
    private float mouseYMove;
    [SerializeField]
    private float mouseXStart;
    [SerializeField]
    private float mouseYStart;
    [SerializeField]
    private float mouseXEnd;
    [SerializeField]
    private float mouseYEnd;

    private float xRotation;
    public float AttackCooldown = 0.1f;

    private bool preventAttack = false;     
    private bool CanAttack = true;
    private bool SwordActive = true;
    private bool UrumiActive = false; 
    private bool UrumiHit = false;
    private bool attackNow = false;
    private bool isAttacking = false;

    public static bool ShouldAttack = false; //this is so that it only attacks when it had made a strike path first.
    public static bool enemyRightHit = false;
    public static bool enemyLeftHit = false;
    public static bool enemyCenterHit = false;
    public static bool enemyUpHit = false;
    public static bool enemyDownHit = false;

    public static int correctAttacks = 0;
   

    void SwordAttackAudio()
    {
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
    }
    
    void SwordClashAudio()
    {
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
    }

    void Start()
    {      
        tr = targetPoint.GetComponent<TrailRenderer>();
        tr.emitting = false;
    }
   
    //IEnumerators for showing visual UI feedback in tutorial, ie displaying tick or cross in center of screen for one seconds eery time a correct or incorrect attack is done
    IEnumerator ShowTick()
    {
        correctAttacks += 1;
        correctTick.SetActive(true);
        yield return new WaitForSeconds(1);
        correctTick.SetActive(false);
       
    }

    IEnumerator ShowCross()
    {
        incorrectCross.SetActive(true);
        yield return new WaitForSeconds(1);
        incorrectCross.SetActive(false);
    }

    //What follows are functions for each direction of attack, depending on whether the attack hits or doesn't hit a shield.

    void SetAttackingBools()
    {
        ShouldAttack = false;
        
        isAttacking = true;
        CanAttack = false;
    }

    public void SwordAttackR()   //attack from right
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>(); // plays the attack animation, implemented following the tutorial www.youtube.com/watch?v=aNZw588BQBo&t=870s from 9:00-12:00
        anim.SetTrigger("AttackR");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown()); //an attack cooldown is used to prevent attacking too fast. It was done following the tutorial : www.youtube.com/watch?v=aNZw588BQBo&t=870s from 9:00-12:00
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowTick());
        }
        else if(UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }
    public void SwordClashR()    //blocked attack from right
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashR");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowTick());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }

    public void SwordAttackL()  //attack from left
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackL");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight) 
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowTick());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }



    }


    public void SwordClashL()  //blocked attack from left
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashL");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowTick());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }

    public void SwordAttackS()   //stab attack
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackS");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowTick());
        }

    }

    public void SwordClashS()  //blocked stab
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashS");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowTick());
        }

    }

    public void SwordAttackO()  //attack from over
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackO");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }

    }

    public void SwordClashO()  //blocked attack from over
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashO");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }

    public void SwordAttackU()   //attack from under
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackU");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }

    public void SwordClashU()  //blocked attack from under
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashU");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }


    public void SwordAttackFromBottomRight()  
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackFromBottomRight");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowTick());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }

    public void SwordClashUR() //blocked attack from bottom right
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashUR");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());
       
    }

    public void SwordAttackFromTopRight()
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackFromTopRight");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowTick());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }

    public void SwordClashOR() //blocked attack from bottom right
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashOR");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());

    }

    public void SwordAttackFromBottomLeft()
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackFromBottomLeft");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowTick());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }

    public void SwordClashUL()  //blocked attack from bottom left
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashUL");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());

    }

    public void SwordAttackFromTopLeft()
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackFromTopLeft");
        SwordAttackAudio();
        StartCoroutine(ResetAttackCooldown());
        if (UIButtonManager.tuteRight)
        {
            StartCoroutine(ShowCross());
        }
        else if (UIButtonManager.tuteLeft)
        {
            StartCoroutine(ShowTick());
        }
        else if (UIButtonManager.tuteCentre)
        {
            StartCoroutine(ShowCross());
        }
    }

    public void SwordClashOL() //blocked attack from top left
    {
        SetAttackingBools();
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashOL");
        SwordClashAudio();
        StartCoroutine(ResetAttackCooldown());

    }
    public void UrumiAttackR() //attack from right
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiAttackU() //attack from under
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackU");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashU() //blocked attack from under
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashU");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiAttackO() //attack from over
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackO");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashO() //blocked attack from over
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashO");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiAttackFromTopLeft()
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackFromTopLeft");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashOL() //blocked attack from top left
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashOL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiAttackFromTopRight()
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackFromTopRight");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashOR() //blocked attack from top right
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashOR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiAttackFromBottomLeft()
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackFromBottomLeft");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashUL() //blocked attack from bottom left
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashUL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }
    public void UrumiAttackFromBottomRight()
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackFromBottomRight");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashUR() //blocked atttack from bottom right
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashUR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }
    public void UrumiHitR() //attack from right that hits an object - enemy or other. This is not currently implemented, as it was found to be unecessary and the animation used for it was not realistic enough
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("HitR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashR() //blocked attack from right
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }



    public void UrumiAttackL() //blocked atack from left
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiHitL() //attack from left that hits an object - enemy or other. This is not currently implemented, as it was found to be unecessary and the animation used for it was not realistic enough
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("HitL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashL()  //blocked attack from left
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiAttackS() // urumi stab attack
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackS");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());

    }

    public void UrumiClashS() //blocked urumi stab attack
    {
        SetAttackingBools();
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashS");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }
   
    /* private void OnDrawGizmos() //to visualise the raycast, and whether it is detecting an enemy
      {

          if (whatHit.collider.gameObject.CompareTag("Enemy"))
          {
              Gizmos.color = Color.red;
          }
          else
          { Gizmos.color = Color.green; }

         Gizmos.DrawWireSphere(collision, radius: 0.5f);
          Gizmos.DrawLine(transform.position, collision);
      } */
  
    void Update()
    {

        
            int mask = 1 << LayerMask.NameToLayer("Default"); //sets the mask for the raycasting to not detext the sword which is in front of the camera, to detect other objects. This was done following the tutorial available at www.youtube.com/watch?v=WpQOBsxFciE&t=312s , specifically at the timestamp: 5:16 - 5:40

        var ray = new Ray(origin: cam2.transform.position, direction: cam2.transform.forward); //the ray of the raycast is set to originate from cam2, which is the camera that moves with the strike trail, when the main camera is static, meaning cam2 is the camera faces in the direction of the target, not precisely the same as the direction the player is looking at.
            RaycastHit hit;
        if (SwordActive) //the active weapon is checked before raycasting as each weapon has a different attack range.
        {
          
            {
                Physics.Raycast(ray, out whatHit, maxDistance: 1.5f, mask); //mask is used so that the raycast does not detect the sword/weapon. 
             
            }
        }
        else if (UrumiActive) // a different raycast is used for the urumi, with a larger max distance to detect attacks from a further distance as the urumi sword is longer than the standard sword.
        {
          
            {
                Physics.Raycast(ray, out whatHit, maxDistance: 10, mask); //mask is used so that the raycast does not detect the sword/weapon. The maxDistance for the Urumi is greater than that of the Sword. 
            
            }

        }


        
        if (!PlayerMovement.inRange && SwordActive) //reset the enemy ID to null and stop any attacks from being blocked when the player is using the sword and leaves the vicinity of the enemy:
        {
            EnemyID = null;
            enemyRightHit = false;
            enemyLeftHit = false;
            enemyUpHit = false;
            enemyDownHit = false;

        }


        

       

        //To Change Weapon:

        if (Input.GetKeyDown(KeyCode.E) && PlayerMovement.UrumiPicked)
        {

            if (SwordActive)
            {

                UrumiActive = true;
                SwordActive = false;
            }

            else if (UrumiActive)
            {
                if (Urumi.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("IdleWhip")) //only switch from Urumi to Swprd when Urumi is in Idle state, because otherwise it's transform and armature in Idle may get defined by the point it was switched from. 
                {
                    SwordActive = true;
                    UrumiActive = false;
                }
            }

           

            if (SwordActive)
            {
                Urumi.SetActive(false);
                Sword.SetActive(true);

            }

            else if (UrumiActive)
            {
                Sword.SetActive(false);
                Urumi.SetActive(true);
                
            }

        }

        

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) //either mouse button can be used to attack. The moment the button is pressed is used to save the start position for gesture recognition
        {
            preventAttack = false;         // preventAttack is used to prevent attacks occuring after an attack in which the mouse button hasn't come up from occuring when it comes up. When the mouse button comes down, it is time to allow a new attack, hence it is set to false here.

            //save the start point for gestaure recognition of an attack's direction:
            mouseXStart = CamController.yRotation;
            mouseYStart = CamController.xRotation;


            //set the starting point of the trail to the centre of the screen:  
            cam2.transform.rotation = cam.transform.rotation;
            
            if (CanAttack) //checks that no other attack is currently being performed 
            {
  
                ShouldAttack = true; //it should only attack if the trail has been emitted.
             
               
                StartCoroutine(AttackTimer()); //attack timer is used to trigger an attack if the player holds the mouse button down beyond a certain time from the moment this line is called
            }
        }


        if ((Input.GetMouseButton(1) || Input.GetMouseButton(0)) && !preventAttack) //code within this if statement is called for the duration in which either mouse buttom is down
        {

            //Prevent the main camera from moving with the mouse movement while mouse button is pressed, by setting the camera's movement sensitivity to zero:
            CamController.sensX = 0; 
            CamController.sensY = 0;


            //MathF.Clamp is used to keep the rotation value within -90 and 90, to prevent the payer from looking up or down more than 90 degrees from the baseline
            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation2, -90f, 90f);

            //set the rotation of the second camera while the mouse button is down
            cam2.transform.rotation = Quaternion.Euler(CamController.xRotation2, CamController.yRotation2, 0);
            orientation.rotation = Quaternion.Euler(0, CamController.yRotation2, 0);

            if (CanAttack) //is true if no attack is currently being executed - ie its animation is playing
            {
                tr.emitting = true;  //the trail is only emitted if an attack is not currently being executed
                ShouldAttack = true;  //attack is to be carried out as the mouse button is down and no attack is currently being executed

                if (whatHit.collider != null)
                {
                   /* if (UrumiActive)
                    {
                        UrumiHit = true;  //UrumiHit is used to check if the urumi hit anything and if so plays an appropriate animation. However, it is not currently used; urumi attack and urumi clash (on getting defended) ainmation made UrumiHit unecessary.
                    } */
                    if (whatHit.collider.gameObject.CompareTag("Enemy")) 
                    {
                      
                        EnemyID = whatHit.collider.gameObject; 


                        if(EnemyID.name.Contains("right") && EnemyID.name.Contains("left")) //checks if the enemy has a shield on both left and right sides as seen by the player. 
                        {
                            //these booleans are used to determine whether the attack is defended
                            enemyRightHit = true;
                            enemyLeftHit = true;
                            enemyCenterHit = false;
                            enemyDownHit = false;
                            enemyUpHit = false;
                        }

                        if(EnemyID.name.Contains("right") && EnemyID.name.Contains("center")) 
                        {
                            enemyRightHit = true;
                            enemyLeftHit = false;
                            enemyCenterHit = true;
                            enemyDownHit = false;
                            enemyUpHit = false;
                        }

                        if(EnemyID.name.Contains("left") && EnemyID.name.Contains("center"))
                        {
                            enemyRightHit = false;
                            enemyLeftHit = true;
                            enemyCenterHit = true;
                            enemyDownHit = false;
                            enemyUpHit = false;
                        }

                        if(EnemyID.name.Contains("up") && EnemyID.name.Contains("center"))
                        {
                            enemyUpHit = true;
                            enemyCenterHit = true;
                            enemyLeftHit = false;
                            enemyRightHit = false;
                            enemyDownHit = false;
                        }
                        if (EnemyID.name.Contains("down") && EnemyID.name.Contains("center"))
                        {
                            enemyUpHit = false;
                            enemyDownHit = true;
                            enemyCenterHit = true;
                            enemyRightHit = false;
                            enemyLeftHit = false;
                        }

                        else if (EnemyID.name.Contains("right"))
                        {
                            
                            enemyRightHit = true;
                          
                        }
                         else if (EnemyID.name.Contains("left"))
                        {
                           
                            enemyLeftHit = true;
                           

                        }
                        else if (EnemyID.name.Contains("center"))
                        {
                            
                            enemyCenterHit = true;
                          

                        }

                         else if (EnemyID.name.Contains("down"))
                        {
                            enemyDownHit = true;
                          
                        }

                         else if (EnemyID.name.Contains("up"))
                        {
                            enemyUpHit = true;
                         


                        }

                    }
                   
                }
               
            }

        }


        if (attackNow || ((Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0)) && !attackNow && !preventAttack)) //attack now is true when enough time has passed with a mouse button being down, ie an attack has timed out and is triggered automatically. Alternative, it may be triggered sooner upon the mouse button coming up.
        {

            //the end point of the strike path is saved:
            mouseXEnd = CamController.yRotation2;
            mouseYEnd = CamController.xRotation2;

            //the difference between the end and strt points are calculated:
            mouseXMove = (mouseXEnd - mouseXStart);
            mouseYMove = (mouseYEnd - mouseYStart);

            //the trail emittance is deactivated:
            StartCoroutine(DeactivateTrail());

            //the main camera is restored to moving with the moouse movement by reseting its sensitivity
            CamController.sensX = 1000;
            CamController.sensY = 1000;


            //What follows are the different conditions for each direction of attack depending on the mouseXMove and mouseYMove values, ie depending on the gesture:

            if (Mathf.Abs(mouseXMove) >= 1f || Mathf.Abs(mouseYMove) >= 1f) // checks if the attack is not a stab
            {
                if(Mathf.Abs(mouseXMove) > 8f && Mathf.Abs(mouseYMove) > 8f) // checks if the attack is diagonal - ie there is significant movement in both x and y axes.
                {
                    if (mouseXMove > 0 && mouseYMove > 0) //  means the attack is coming from the top-left
                    {
                        if (SwordActive)
                        {
                            if (!enemyUpHit) //checks that the enemy doesn't have a shield above
                            {
                                SwordAttackFromTopLeft();
                               
                            }
                            else if (enemyUpHit)
                            {
                                SwordClashOL(); //if the enemy has a shield above the clash animation (and audio) is triggered
                            }
                        }
                        else if (UrumiActive)
                        {
                            if (!enemyUpHit)
                            {
                                UrumiAttackFromTopLeft();
                               
                            }
                            else if (enemyUpHit)
                            {
                                UrumiClashOL();
                            }
                        }
                    }
                    else if (mouseXMove > 0 && mouseYMove < 0) //means the diagonal attack is coming from the bottom-left
                    {
                        if (SwordActive)
                        {
                            if (!enemyDownHit)
                            {
                                SwordAttackFromBottomLeft();
                              
                            }
                            else if (enemyDownHit)
                            {
                                SwordClashUL();
                            }
                        }
                        else if (UrumiActive)
                        {
                            if (!enemyDownHit)
                            {
                                UrumiAttackFromBottomLeft();
                   
                            }
                            else if (enemyDownHit)
                            {
                                UrumiClashUL();
                            }
                        }
                    }

                    else if (mouseXMove < 0 && mouseYMove > 0) //diagonal attacks from top-right
                    {
                        if (SwordActive)
                        {
                            if (!enemyUpHit)
                            {
                                SwordAttackFromTopRight();
                              
                            }
                            else if (enemyUpHit)
                            {
                                SwordClashOR();
                            }
                        }

                        else if (UrumiActive)
                        {
                            if (!enemyUpHit)
                            {
                                UrumiAttackFromTopRight();
                               
                            }
                            else if (enemyUpHit)
                            {
                                UrumiClashOR();
                            }
                        }
                    }

                    else if (mouseXMove < 0 && mouseYMove < 0) //diagonal attacks from bottom-right
                    {if (SwordActive)
                        {
                            if (!enemyDownHit)
                            {
                                SwordAttackFromBottomRight();
                             
                            }
                            else if (enemyDownHit)
                            {
                                SwordClashUR();
                            }
                        }

                    else if (UrumiActive)
                        {
                            if (!enemyDownHit)
                            {
                                UrumiAttackFromBottomRight();
                               
                            }
                            else if (enemyDownHit)
                            {
                                UrumiClashUR();
                            }
                        }
                    }

                }



                else if (Mathf.Abs(mouseXMove) > Mathf.Abs(mouseYMove)) // else means it is not diagonal; it thus checks whether the attack is coming from the right.
                    {
                    if (mouseXMove < 0) //attacks from right
                    {
                        if (ShouldAttack)
                        {
                          

                            if (SwordActive)
                            {

                                if (!enemyRightHit)
                                {
                                    SwordAttackR();
                                    
                                   
                                }

                                else if (enemyRightHit)
                                {
                                    SwordClashR();
                                  
                                    enemyRightHit = false;
                                }
                            }





                            else if (UrumiActive)
                            {
                                if (!enemyRightHit)
                                {
                                   
                                    UrumiAttackR();
                                    
                                }
                                else if (enemyRightHit)
                                {
                                    UrumiClashR();
                                   
                                    enemyRightHit = false;
                                }
                            }


                        }
                    }

                    else if (mouseXMove > 0) //attacks from the left
                    {
                        if (ShouldAttack)
                        {
                           
                            if (SwordActive)
                            {
                                if (!enemyLeftHit)
                                {
                                   
                                    SwordAttackL();
                                    

                                }
                                else if (enemyLeftHit)
                                {
                                   
                                    SwordClashL();
                                   
                                    enemyLeftHit = false;
                                }


                            }
                            else if (UrumiActive)
                            {
                                if (!enemyLeftHit)
                                {
                                    UrumiAttackL();
                                    

                                }
                                else if (enemyLeftHit)
                                {
                                    UrumiClashL();
                                    
                                    enemyLeftHit = false;
                                }
                            }
                        }
                    }
                }

                else if (Mathf.Abs(mouseXMove) <= Mathf.Abs(mouseYMove))  //detects uppercut
                {

                    if (mouseYMove < 0)
                    {
                        if (ShouldAttack) //this was changed from the tutorial, as the tutorial did not use strike paths and used CanAttack here, but for this game resulted in attacks without strike paths.
                        {
                            if (SwordActive)
                            {
                                if (enemyDownHit)
                                {
                                   
                                    SwordClashU();
                                }
                                else if (!enemyDownHit)
                                {
                                  
                                    SwordAttackU();
                                    
                                }


                            }


                            else if (UrumiActive)
                            {
                                // if (!UrumiHit)
                                if (enemyDownHit)
                                    UrumiClashU();
                                else if (!enemyDownHit)
                                {
                                    UrumiAttackU();
                                    
                                }
                             //   else if (UrumiHit)  //this can be used to play a different animation when the urumi hits something without being blocked - like hitting the enemy. It is not currently used because the regular attack animation is beter and sufficient.
                                  //  UrumiHitR();
                            }
                        }
                    }

                    else if (mouseYMove > 0) //attacks from aove - lowercut
                    {
                        if (ShouldAttack)
                        {
                            if (SwordActive)
                            {
                                if (enemyUpHit)
                                {

                                    SwordClashO();
                                }
                                else if (!enemyUpHit) 
                                {

                                    SwordAttackO();
                                    
                                }


                            }

                            else if (UrumiActive)
                            {
                                if (enemyUpHit)
                                    UrumiClashO();
                                else if (!enemyUpHit)
                                {
                                    UrumiAttackO();
                                    
                                }
                            }
                        }
                    }





                }
            } 

        else if (Mathf.Abs(mouseXMove) < 1f && Mathf.Abs(mouseYMove) <1f) //if movement on both axes is insignificant then the attack is a stab
        {
            {
                if (ShouldAttack)
                {

                    if (SwordActive)
                    {
                        if (!enemyCenterHit)
                        {
                            SwordAttackS();
                           
                            
                        }
                        else if (enemyCenterHit)
                        {
                            SwordClashS();
                            
                          
                            enemyCenterHit = false;
                        }

                    }
                    else if (UrumiActive)
                    {
                        if (!enemyCenterHit)
                        {
                            UrumiAttackS();
                           
                            
                        }
                        else if (enemyCenterHit)
                        {
                            UrumiClashS();
                            
                            
                        }
                    }
  
                }
            }
        }

            //confirm that a second attack is not triggered automatically:
            attackNow = false;
            ShouldAttack = false; 
        }

    }


    IEnumerator ResetAttackCooldown() //called at the end of each attack function, to preven another attack from being triggered till the current attack has finished. Controls the rate of possible attacks. 
    {

        ShouldAttack = false; //prevents extra attacks from occuring before the trail path can be rendered
       
        yield return new WaitForSeconds(AttackCooldown); //the cooldown time is set in the inspector
        CanAttack = true; // allows a new attack to be initiated; this variable, and setting it via a coroutine with the above WaitForSeconds was done. following the tutorial: www.youtube.com/watch?v=aNZw588BQBo&t=870s from 9:00-12:00 
        UrumiHit = false; //not currently used, but resets the urumi hit variable that can be used to differentiate the urumi animation that hits any object from that which doesn't 
        isAttacking = false; //resets, informing that the attack is complete, allowing for a new attack to be initiated.
    }

 

  

    IEnumerator DeactivateTrail() //deactivates the strike path trail, so that it is not diaplyed unless the mouse button is down (the following is called as a corouting under the 'mouth button up''condition)
    {
        
       tr.emitting = false;
        yield return new WaitForSeconds(0.2f); //this is to ensure the trail emittance is stopped before returning the trail to the centre, to prevent the trail being seen to return, to match single slashes with the trail.
        CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f); //prevent the camera from moving above or below 90 degrees, as that would make it be upside-down.
        CamController.yRotation2 = CamController.yRotation;
        cam2.transform.rotation = cam.transform.rotation;
    }

    IEnumerator AttackTimer() // this is to trigger attacks without the player having to release the mouse button - the player can release the mouse button to attack slightly faster though
    {
        yield return new WaitForSeconds(0.3f);
        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
        {
            attackNow = true; //boolean used as alternative to mouse button up to trigger attacks
            preventAttack = true; //prevent additional attacks from occuring simultaneously
        }

    }

}

