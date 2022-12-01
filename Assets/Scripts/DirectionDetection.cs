using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{
    public GameObject lastHit;
    public GameObject HitParticle;
     RaycastHit whatHit;
     Vector3 collision = Vector3.zero;
     Vector3 target = new Vector3(0, 0, 10);

    public GameObject Sword, Urumi, Shield;
    [SerializeField]
    private  float mouseXMove;
   // public static float mouseXMove2;
  //  public static float mouseYMove2;

    [SerializeField]
    private float mouseYMove;
    [SerializeField]
    private float mouseXStart;
    [SerializeField]
    private float mouseYStart;
 /*   [SerializeField]
    private float mouseYStart2;
    [SerializeField]
    private float mouseXStart2;*/
    [SerializeField]
    private float mouseXEnd;
    [SerializeField]
    private float mouseYEnd;

    public GameObject cam;
    public GameObject cam2;
    private float xRotation;

    private bool CanAttack = true;
    public static bool ShouldAttack = false; //this is so that it only attacks when it had made a strike path first.
    public float AttackCooldown = 0.1f;
    public AudioClip SwordAttackSound;
    public AudioClip WhipAttackSound;
    public AudioClip SwordClashSound;
    private bool isAttacking = false;
    public static bool fromRight = false;
    public static bool fromLeft = false;
    public static bool fromCentre = false;
    public static bool fromOver = false;
    public static bool fromUnder = false;


    public static bool fromBottomRight = false;
    public static bool fromBottomLeft = false;
    public static bool fromTopRight = false;
    public static bool fromTopLeft = false;

    public static bool enemyHit = false;
    public static bool enemyHit2 = false;
    public static bool enemyRightHit = false;
    public static bool enemyLeftHit = false;
    public static bool enemyCenterHit = false;
    public static bool enemyUpHit = false;
    public static bool enemyDownHit = false;

    public bool canStab = false;
    public bool canStab2 = false;

    public static GameObject EnemyID;

    public GameObject targetPoint;
    private TrailRenderer tr;
    private bool SwordActive = true;
    private bool UrumiActive = false; 
    
    private bool UrumiHit = false;
    private bool attackNow = false;
    public Transform orientation;

    [SerializeField]
    float eulerAngY;
  
    // Start is called before the first frame update
    void Start()
    {
        
        tr = targetPoint.GetComponent<TrailRenderer>();
        tr.emitting = false;


        

    }
    public void SwordAttackR()
    {

        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
    fromBottomLeft = false;
    fromTopRight = false;
    fromTopLeft = false;
    Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordClashR()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordAttackL()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromLeft = true;
        fromRight = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackL");
        AudioSource ac = GetComponent<AudioSource>();
       ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordClashL()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = true;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordAttackS()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = true;
         CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackS");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
        
    }

    public void SwordClashS()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = true;
        fromOver = false;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashS");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());

    }

    public void SwordAttackO()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = true;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackO");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());

    }

    public void SwordClashO()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = true;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashO");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());

    }

    public void SwordAttackU()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = false;
        fromUnder = true;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackU");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());

    }

    public void SwordClashU()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = false;
        fromUnder = true;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashU");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());

    }


    public void SwordAttackFromBottomRight()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = true;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = true;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackFromBottomRight");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());

    }

    public void SwordAttackFromTopRight()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = true;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = true;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackFromTopRight");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordAttackFromBottomLeft()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = true;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = true;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackFromBottomLeft");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordAttackFromTopLeft()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = true;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = true;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackFromTopLeft");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }
    public void UrumiAttackR()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiHitR()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("HitR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }



    public void UrumiAttackL()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromLeft = true;
        fromRight = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiHitL()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("HitL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }


    public void UrumiAttackS()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = true;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackS");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());

    }

   /* private void OnDrawGizmos()
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("enemy hit" + enemyHit);
            print(EnemyID.name);
            print("enemy right hit" + enemyRightHit);
            print("from right" + fromRight);
        }

        if(fromUnder || fromOver)
        {
            print("from under or from over");
        }

        if(!PlayerMovement.inRange)
        {
            EnemyID = null;
        }

            //Debug.DrawRay(this.transform.position, this.transform.forward * 5, Color.green);
            int mask = 1 << LayerMask.NameToLayer("Default");
        //mask |= 1 << LayerMask.NameToLayer("Enemy"); //this is for adding additional layers
        var ray = new Ray(origin: cam2.transform.position, direction: cam2.transform.forward);
            RaycastHit hit;
        if (SwordActive)
        {
           // if (gameObject.CompareTag("RayCaster"))
            {
                if (Physics.Raycast(ray, out whatHit, maxDistance: 3, mask)) //mask is used so that the raycast does not detect the sword/weapon
                {
                    //lastHit = hit.transform.gameObject;
                    collision = whatHit.point;
                }
            }
        }
        else if (UrumiActive) // a different raycast is used for the urumi, with a larger max distance to detect attacks from a further distance as the urumi sword is longer than the standard sword.
        {
          //  if (gameObject.CompareTag("RayCaster"))
            {
                if (Physics.Raycast(ray, out whatHit, maxDistance: 10, mask)) //mask is used so that the raycast does not detect the sword/weapon
                {
                    //lastHit = hit.transform.gameObject;
                    collision = whatHit.point;
                }
            }

        }


        



            eulerAngY = cam.transform.localEulerAngles.y;

        //Vector3 mousePos = Input.mousePosition;

        //To Change Weapon:

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (SwordActive)
            {

                UrumiActive = true;
                SwordActive = false;
            }

            else if (UrumiActive)
            {

                SwordActive = true;
                UrumiActive = false;
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

        /*
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {

                mouseXStart = CamController.yRotation;
                mouseYStart = CamController.xRotation;
                ShouldAttack = true; //it should only attack if the trail has been emitted.
                canStab = true;
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            // mouseYStart = mousePos.y;
            if (CanAttack)
            {

                 
                Time.timeScale = 0.5f;
                tr.emitting = true;
                
                if (whatHit.collider != null)
                {
                    if (UrumiActive)
                    {
                        UrumiHit = true;
                    }
                    if (whatHit.collider.gameObject.CompareTag("Enemy")) //This is giving an error when the raycast doesn't hit anything. 
                    {
                        enemyHit = true;
                    }

                }
            }


        }

        if (Input.GetMouseButtonUp(0))
        {
            print("mouse button up");
            Time.timeScale = 1f;
            if (CanAttack)
            {
                mouseXEnd = CamController.yRotation;
                mouseYEnd = CamController.xRotation;
                // mouseYEnd = mousePos.y;
            }
                mouseXMove = (mouseXEnd - mouseXStart);
            mouseYMove = (mouseYEnd - mouseYStart);
            
           
           
            tr.emitting = false;

            // mouseYMove = mouseYEnd - mouseYStart;
            if (Mathf.Abs(mouseYMove) < Mathf.Abs(mouseXMove))
            {



                if (Mathf.Abs(mouseXMove) >= 0.2f)
                {
                    if (mouseXMove < 0)
                    {
                        if (ShouldAttack) //this was changed from the tutorial, as the tutorial did not use strike paths and used CanAttack here, but for this game resulted in attacks without strike paths.
                        {
                            if (SwordActive)
                            {

                                if (whatHit.collider == null || !whatHit.collider.gameObject.name.Contains("right"))
                                {
                                    
                                    SwordAttackR();
                                }

                                else if (whatHit.collider.gameObject.name.Contains("right"))
                                {
                                    SwordClashR();
                                }
                            }





                            else if (UrumiActive)
                            {
                                if (!UrumiHit)
                                    UrumiAttackR();
                                else if (UrumiHit)
                                    UrumiHitR();
                            }
                        }
                    }

                    else if (mouseXMove > 0)
                    {
                        if (ShouldAttack)
                        {
                            if (SwordActive)
                            {
                                if (whatHit.collider == null || !whatHit.collider.gameObject.name.Contains("left"))
                                {
                                    SwordAttackL();
                                }
                                else if (whatHit.collider.gameObject.name.Contains("left"))
                                {
                                    SwordClashL();
                                }


                            }
                            else if (UrumiActive)
                            {
                                if (!UrumiHit)
                                    UrumiAttackL();
                                else if (UrumiHit)
                                    UrumiHitL();
                            }
                        }
                    }
                }
            }

            else if (Mathf.Abs(mouseYMove) > Mathf.Abs(mouseXMove))
            {
                if (mouseYMove < 0)
                {
                    if (ShouldAttack) //this was changed from the tutorial, as the tutorial did not use strike paths and used CanAttack here, but for this game resulted in attacks without strike paths.
                    {
                        if (SwordActive)
                        {
                            if (whatHit.collider != null && (whatHit.collider.gameObject.name.Contains("down") || whatHit.collider.gameObject.name.Contains("center")))
                            {
                                
                                SwordClashU();
                            }
                            else if (whatHit.collider == null || !whatHit.collider.gameObject.name.Contains("down") || !whatHit.collider.gameObject.name.Contains("center")) //(whatHit.collider != null  || !whatHit.collider.gameObject.name.Contains("down") || !whatHit.collider.gameObject.name.Contains("center"))
                            {
                                
                                SwordAttackU();
                            }

                            
                        }





                        else if (UrumiActive)
                        {
                            if (!UrumiHit)
                                UrumiAttackR();
                            else if (UrumiHit)
                                UrumiHitR();
                        }
                    }
                }

                else if (mouseYMove > 0)
                {
                    if (ShouldAttack)
                    {
                        if (SwordActive)
                        {
                            if (whatHit.collider != null && (whatHit.collider.gameObject.name.Contains("up") || whatHit.collider.gameObject.name.Contains("center")))
                            {
                               
                                SwordClashO();
                            }
                            else if (whatHit.collider == null || !whatHit.collider.gameObject.name.Contains("up") || !whatHit.collider.gameObject.name.Contains("center")) //(whatHit.collider != null  || !whatHit.collider.gameObject.name.Contains("down") || !whatHit.collider.gameObject.name.Contains("center"))
                            {
                                
                                SwordAttackO();
                            }


                        }
                        
                        else if (UrumiActive)
                        {
                            if (!UrumiHit)
                                UrumiAttackL();
                            else if (UrumiHit)
                                UrumiHitL();
                        }
                    }
                }
            }
        

            else if (Mathf.Abs(mouseXMove) < 0.2f && Mathf.Abs(mouseYMove) < 0.2f)


            {

                if (ShouldAttack)
                {
                    if (canStab)
                    {
                        if (SwordActive)
                        {
                            if (whatHit.collider == null || !whatHit.collider.gameObject.name.Contains("center"))
                            {
                                SwordAttackS();
                                canStab = false;
                            }
                            else if (whatHit.collider.gameObject.name.Contains("center"))
                            {
                                SwordClashS();
                                canStab = false;
                            }
                        }
                        else if (UrumiActive)
                        {
                            UrumiAttackS();
                            canStab = false;
                        }
                    }
                }
            }


            if (enemyHit)
            {
               
                if (whatHit.collider.gameObject.CompareTag("Enemy"))
                {

                    
                    if (fromRight)
                    {
                       

                        if (!whatHit.collider.gameObject.name.Contains("right"))
                        {
                           
                            whatHit.collider.gameObject.GetComponent<Animator>().SetTrigger("Damage");
                            HitParticle.SetActive(true);
                            Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x - 0.6f,
                            transform.position.y + 0.2f, whatHit.collider.gameObject.transform.position.z + 0.6f), whatHit.collider.gameObject.transform.rotation);

                            if (SwordActive)
                                whatHit.collider.gameObject.GetComponent<EnemyController>().ReduceHealth(1); //reduces the enemy health in the isntance of the script on the game object hit 

                            else if (UrumiActive)
                                whatHit.collider.gameObject.GetComponent<EnemyController>().ReduceHealth(1);
                        }
                        
                    }
                    else if (fromLeft)
                    {
                        if (!whatHit.collider.gameObject.name.Contains("left"))
                        {
                            whatHit.collider.gameObject.GetComponent<Animator>().SetTrigger("Damage");
                            HitParticle.SetActive(true);
                            Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x + 0.9f,
                                transform.position.y + 0.2f, whatHit.collider.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));

                            if (SwordActive)
                                whatHit.collider.gameObject.GetComponent<EnemyController>().ReduceHealth(1);
                            else if (UrumiActive)
                                whatHit.collider.gameObject.GetComponent<EnemyController>().ReduceHealth(1);
                        }
                    }

                    else if (fromCentre && !whatHit.collider.gameObject.name.Contains("center"))
                    {

                        whatHit.collider.gameObject.GetComponent<Animator>().SetTrigger("Damage");
                        HitParticle.SetActive(true);
                        Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x + 0.3f,
                            transform.position.y + 0.4f, whatHit.collider.gameObject.transform.position.z + 0.5f), Quaternion.Euler(0, -45, 0));
                        if (SwordActive)
                            whatHit.collider.gameObject.GetComponent<EnemyController>().ReduceHealth(1);
                         else if (UrumiActive)
                            whatHit.collider.gameObject.GetComponent<EnemyController>().ReduceHealth(1);


                    }
                }
            }
            enemyHit = false;
            
            //this is to reset these variables 

        }
        */
        //for right mouse button - camera not moving

        if (Input.GetMouseButtonDown(1))
        {
            mouseXStart = CamController.yRotation;
            mouseYStart = CamController.xRotation;

            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
            CamController.yRotation2 = CamController.yRotation;
            //CamController.yRotation2 = Mathf.Clamp(CamController.yRotation, -90f, 90f);
            cam2.transform.rotation = cam.transform.rotation;

            if (CanAttack)
            {
               /* mouseXStart2 = CamController.yRotation2;
                mouseYStart2 = CamController.xRotation2;*/



                
                ShouldAttack = true; //it should only attack if the trail has been emitted.
                canStab = true;

                canStab2 = true;

                StartCoroutine(AttackTimer());

               
            }
        }


        if (Input.GetMouseButton(1))
        {
            CamController.sensX = 0;
            CamController.sensY = 0;

            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation2, -90f, 90f);

            cam2.transform.rotation = Quaternion.Euler(CamController.xRotation2, CamController.yRotation2, 0);
            orientation.rotation = Quaternion.Euler(0, CamController.yRotation2, 0);






            if (CanAttack)
            {
                tr.emitting = true;
                ShouldAttack = true;

                if (whatHit.collider != null)
                {
                    if (UrumiActive)
                    {
                        UrumiHit = true;
                    }
                    if (whatHit.collider.gameObject.CompareTag("Enemy")) //This is giving an error when the raycast doesn't hit anything. (not anymore?)
                    {
                        enemyHit = true;
                        enemyHit2 = true;
                        EnemyID = whatHit.collider.gameObject;


                        if (EnemyID.name.Contains("right"))
                        {
                            enemyRightHit = true;
                            enemyLeftHit = false;
                            enemyCenterHit = false;
                            enemyDownHit = false;
                            enemyUpHit = false;
                        }
                        else if (EnemyID.name.Contains("left"))
                        {
                            enemyLeftHit = true;
                            enemyCenterHit = false;
                            enemyDownHit = false;
                            enemyUpHit = false;
                            enemyRightHit = false;

                        }
                        else if (EnemyID.name.Contains("center"))
                        {
                            enemyCenterHit = true;
                            enemyLeftHit = false;
                            enemyRightHit = false;
                            enemyDownHit = false;
                            enemyUpHit = false;

                        }

                        else if (EnemyID.name.Contains("down"))
                        {
                            enemyDownHit = true;
                            enemyUpHit = false;
                            enemyLeftHit = false;
                            enemyRightHit = false;
                            enemyCenterHit = false;
                        }

                        else if (EnemyID.name.Contains("up"))
                        {
                            enemyUpHit = true;
                            enemyLeftHit = false;
                            enemyCenterHit = false;
                            enemyDownHit = false;
                            enemyRightHit = false;


                        }

                    }
                    else
                        enemyHit2 = false;



                }
                //mouseXStart = CamController.yRotation2;
            }

            //for the trail  to move






        }

        
           
        



     




        if (attackNow || Input.GetMouseButtonUp(1))
        {

            mouseXEnd = CamController.yRotation2;
            mouseYEnd = CamController.xRotation2;

            // mouseYEnd = mousePos.y;

            mouseXMove = (mouseXEnd - mouseXStart);
            mouseYMove = (mouseYEnd - mouseYStart);

            StartCoroutine(DeactivateTrail());








            CamController.sensX = 1000;
            CamController.sensY = 1000;
            /* if (CanAttack)
             {
                 mouseXEnd = CamController.yRotation2;
                 // mouseYEnd = mousePos.y;
             }
            
            mouseXMove = (mouseXEnd - mouseXStart);
            mouseYMove = (mouseYEnd - mouseYStart);
          //  mouseXMove2 = (mouseXStart2 - mouseXEnd); // this is to check the single value from the mousebuttonDown for determining if it is a stab or not.
           // mouseYMove2 = (mouseYStart2 - mouseYEnd);

            
            tr.emitting = false;
            */

            // mouseYMove = mouseYEnd - mouseYStart;



            if (Mathf.Abs(mouseXMove) >= 0.4f || Mathf.Abs(mouseYMove) >= 0.4f)
            {
                if(Mathf.Abs(mouseXMove) > 8f && Mathf.Abs(mouseYMove) > 8f)
                {
                    if (mouseXMove > 0 && mouseYMove > 0) // this means the attack is coming from topleft
                    {
                        SwordAttackFromTopLeft();
                        enemyHit = true;
                    }
                    else if (mouseXMove > 0 && mouseYMove < 0) 
                    {
                        SwordAttackFromBottomLeft();
                        enemyHit = true;
                    }

                    else if (mouseXMove < 0 && mouseYMove > 0) 
                    {
                        SwordAttackFromTopRight();
                        enemyHit = true;
                    }

                    else if (mouseXMove < 0 && mouseYMove < 0)
                    {
                        SwordAttackFromBottomRight();
                        enemyHit = true;
                    }

                }



                else if (Mathf.Abs(mouseXMove) > Mathf.Abs(mouseYMove))
                    {
                    if (mouseXMove < 0)
                    {
                        if (ShouldAttack)
                        {
                            canStab2 = false;



                            if (SwordActive)
                            {

                                if (!enemyRightHit)
                                {
                                    SwordAttackR();
                                    enemyHit = true;
                                    print("enemyRightHit" + enemyRightHit);
                                }

                                else if (enemyRightHit)
                                {
                                    SwordClashR();
                                    enemyHit = false;
                                    enemyRightHit = false;
                                }
                            }





                            else if (UrumiActive)
                            {
                                if (!enemyRightHit)
                                {
                                    enemyHit = true;
                                    UrumiAttackR();
                                    
                                }
                                else if (enemyRightHit)
                                {
                                    UrumiHitR();
                                    enemyHit = false;
                                    enemyRightHit = false;
                                }
                            }


                        }
                    }

                    else if (mouseXMove > 0)
                    {
                        if (ShouldAttack)
                        {
                            canStab2 = false;
                            if (SwordActive)
                            {
                                if (!enemyLeftHit)
                                {
                                    
                                    SwordAttackL();
                                    enemyHit = true;

                                }
                                else if (enemyLeftHit)
                                {
                                    SwordClashL();
                                    enemyHit = false;
                                    enemyLeftHit = false;
                                }


                            }
                            else if (UrumiActive)
                            {
                                if (!enemyLeftHit)
                                {
                                    UrumiAttackL();
                                    enemyHit = true;

                                }
                                else if (enemyLeftHit)
                                {
                                    UrumiHitL();
                                    enemyHit = false;
                                    enemyLeftHit = false;
                                }
                            }
                        }
                    }
                }

                else if (Mathf.Abs(mouseXMove) <= Mathf.Abs(mouseYMove))
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
                                else if (!enemyDownHit) //(whatHit.collider != null  || !whatHit.collider.gameObject.name.Contains("down") || !whatHit.collider.gameObject.name.Contains("center"))
                                {
                                  
                                    SwordAttackU();
                                    enemyHit = true;
                                }


                            }


                            else if (UrumiActive)
                            {
                               // if (!UrumiHit)
                                //    UrumiAttackR(); needs for urui uppercut animation
                             //   else if (UrumiHit)
                                  //  UrumiHitR();
                            }
                        }
                    }

                    else if (mouseYMove > 0)
                    {
                        if (ShouldAttack)
                        {
                            if (SwordActive)
                            {
                                if (enemyUpHit)
                                {

                                    SwordClashO();
                                }
                                else if (!enemyUpHit) //(whatHit.collider != null  || !whatHit.collider.gameObject.name.Contains("down") || !whatHit.collider.gameObject.name.Contains("center"))
                                {

                                    SwordAttackO();
                                    enemyHit = true;
                                }


                            }

                            else if (UrumiActive)
                            {
                               // if (!UrumiHit)
                                //    UrumiAttackL(); needs urumi undercut animation
                               // else if (UrumiHit)
                               //     UrumiHitL();
                            }
                        }
                    }





                }
            } 

        else if (Mathf.Abs(mouseXMove) < 0.4f && Mathf.Abs(mouseYMove) <0.4f)
        {
            {

                if (ShouldAttack)
                {
                    //  if (canStab2)
                    //{

                    // canStab2 = false;


                    if (SwordActive)
                    {
                        if (!enemyCenterHit)
                        {
                            SwordAttackS();
                            enemyHit = true;
                            canStab = false;
                        }
                        else if (enemyCenterHit)
                        {
                            SwordClashS();
                            canStab = false;
                            enemyHit = false;
                            enemyCenterHit = false;
                        }

                    }
                    else if (UrumiActive)
                    {
                        if (!enemyCenterHit)
                        {
                            UrumiAttackS();
                            enemyHit = true;
                            canStab = false;
                        }
                        else if (enemyCenterHit)
                        {
                            UrumiAttackS();
                            enemyHit = false;
                            canStab = false;
                        }
                    }


                    //}
                }
            }
        }


            /*  if (enemyHit)
              {
                  /*  if (enemyRightHit || enemyCenterHit || enemyLeftHit)
                    {
                        enemyHit = false;
                    }*/

            // else //if (whatHit.collider.gameObject.CompareTag("Enemy"))
            // {

            /*

                     if (fromRight)
                     {

                         if (!enemyRightHit)
                         {

                             EnemyID.GetComponent<Animator>().SetTrigger("Damage");

                             // StartCoroutine(EnemyHurtRight());
                             HitParticle.SetActive(true);

                             Instantiate(HitParticle, new Vector3(EnemyID.gameObject.transform.position.x - 0.6f,
                             transform.position.y + 0.2f, EnemyID.gameObject.transform.position.z + 0.6f), EnemyID.gameObject.transform.rotation);



                             if (SwordActive)
                             {
                                 EnemyID.GetComponent<EnemyController>().ReduceHealth(1); //reduces the enemy health in the isntance of the script on the game object hit 
                                 print("YES5");
                             }
                             else if (UrumiActive)
                                 EnemyID.GetComponent<EnemyController>().ReduceHealth(1);

                         }

                     }

                     else if (fromOver && !enemyUpHit)
                     {
                         print("FROM OVER YES");
                         EnemyID.GetComponent<Animator>().SetTrigger("Damage");
                         HitParticle.SetActive(true);
                         Instantiate(HitParticle, new Vector3(EnemyID.gameObject.transform.position.x + 0.9f,
                              transform.position.y + 0.2f, EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));

                         if (SwordActive)
                             EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
                         else if (UrumiActive)
                             EnemyID.GetComponent<EnemyController>().ReduceHealth(1);



                     }

                     else if (fromLeft)
                     {
                         print("FROM LEFT YES");
                         if (!enemyLeftHit)
                         {
                             EnemyID.GetComponent<Animator>().SetTrigger("Damage");
                             HitParticle.SetActive(true);
                             Instantiate(HitParticle, new Vector3(EnemyID.gameObject.transform.position.x + 0.9f,
                                 transform.position.y + 0.2f, EnemyID.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));

                             if (SwordActive)
                                 EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
                             else if (UrumiActive)
                                 EnemyID.GetComponent<EnemyController>().ReduceHealth(1);


                         }

                     }

                     else if (fromCentre && !enemyCenterHit)
                     {

                         EnemyID.GetComponent<Animator>().SetTrigger("Damage");
                         HitParticle.SetActive(true);
                         Instantiate(HitParticle, new Vector3(EnemyID.gameObject.transform.position.x + 0.3f,
                             transform.position.y + 0.4f, EnemyID.gameObject.transform.position.z + 0.5f), Quaternion.Euler(0, -45, 0));
                         if (SwordActive)
                             EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
                         else if (UrumiActive)
                             EnemyID.GetComponent<EnemyController>().ReduceHealth(1);



                     }





                     else if (fromUnder && !enemyDownHit)
                     {

                         EnemyID.GetComponent<Animator>().SetTrigger("Damage");
                         HitParticle.SetActive(true);
                         Instantiate(HitParticle, new Vector3(EnemyID.gameObject.transform.position.x + 0.3f,
                             transform.position.y + 0.4f, EnemyID.gameObject.transform.position.z + 0.5f), Quaternion.Euler(0, -45, 0));
                         if (SwordActive)
                             EnemyID.GetComponent<EnemyController>().ReduceHealth(1);
                         else if (UrumiActive)
                             EnemyID.GetComponent<EnemyController>().ReduceHealth(1);



                     }

             } */
            // StartCoroutine(ResetCam2());
            //}
            /*  IEnumerator EnemyHurtRight()
              {
                  new WaitForSeconds(1);
              }*/
            attackNow = false;
            ShouldAttack = false;
        }






        
        


    }


    IEnumerator ResetAttackCooldown()
    {
        
        enemyHit = false;
        print("reset attack cooldown");
        ShouldAttack = false;
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        UrumiHit = false;
        
        print("attack RESET");
       
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.5f);
        isAttacking = false;
        
    }

  IEnumerator ResetCam2()
    {
        yield return new WaitForSeconds(1f);
        CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
        CamController.yRotation2 = CamController.yRotation;
        //CamController.yRotation2 = Mathf.Clamp(CamController.yRotation, -90f, 90f);
        cam2.transform.rotation = cam.transform.rotation;
        //orientation.rotation = Quaternion.Euler(0, CamController.yRotation, 0);
    }

    IEnumerator DeactivateTrail()
    {
        
       tr.emitting = false;
        yield return new WaitForSeconds(0.2f); //this is to ensure the trail emittance is stopped before returning the trail to the centre, to prevent the trail being seen to return, to match single slashes with the trail.
        CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
        CamController.yRotation2 = CamController.yRotation;
        //CamController.yRotation2 = Mathf.Clamp(CamController.yRotation, -90f, 90f);
        cam2.transform.rotation = cam.transform.rotation;
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.5f);
        if(Input.GetMouseButton(1))
        attackNow = true;
    }

}

