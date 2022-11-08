using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{
    public GameObject lastHit;
    public GameObject HitParticle;
    RaycastHit whatHit;
    public Vector3 collision = Vector3.zero;
    public Vector3 target = new Vector3(0, 0, 10);
   
    public GameObject Sword, Urumi, Shield;

    public static float mouseXMove;
    public static float mouseXMove2;

    [SerializeField]
    public float mouseYMove;
    [SerializeField]
    private float mouseXStart;
    [SerializeField]
    private float mouseXStart2;
    [SerializeField]
    private float mouseXEnd;

    public GameObject cam;
    public GameObject cam2;
    private float xRotation;

    public bool CanAttack = true;
    public static bool ShouldAttack = false; //this is so that it only attacks when it had made a strike path first.
    public float AttackCooldown = 0.1f;
    public AudioClip SwordAttackSound;
    public AudioClip WhipAttackSound;
    public static bool isAttacking = false;
    public static bool fromRight = false;
    public static bool fromLeft = false;
    public static bool fromCentre = false;

    public static bool enemyHit = false;

    public bool canStab = false;
    public bool canStab2 = false;


    public GameObject targetPoint;
    private TrailRenderer tr;
    private bool SwordActive = true;
    private bool UrumiActive = false; 
    
    private bool UrumiHit = false;

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
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordAttackL()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromLeft = true;
        fromRight = false;
        fromCentre = false;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackL");
        AudioSource ac = GetComponent<AudioSource>();
       ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }


    public void SwordAttackS()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = true;
         CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackS");
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
     }*/
    // Update is called once per frame
    void Update()
    {

        //Debug.DrawRay(this.transform.position, this.transform.forward * 5, Color.green);
        int mask = 1 << LayerMask.NameToLayer("Default");
        //mask |= 1 << LayerMask.NameToLayer("Enemy"); //this is for adding additional layers
        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;
        if (SwordActive)
        {
            if (Physics.Raycast(ray, out whatHit, maxDistance: 3, mask)) //mask is used so that the raycast does not detect the sword/weapon
            {
                //lastHit = hit.transform.gameObject;
                collision = whatHit.point;
            }
        }
        else if (UrumiActive) // a different raycast is used for the urumi, with a larger max distance to detect attacks from a further distance as the urumi sword is longer than the standard sword.
        {
            if (Physics.Raycast(ray, out whatHit, maxDistance: 10, mask)) //mask is used so that the raycast does not detect the sword/weapon
            {
                //lastHit = hit.transform.gameObject;
                collision = whatHit.point;
            }

        }


        



            eulerAngY = cam.transform.localEulerAngles.y;

        //Vector3 mousePos = Input.mousePosition;

        //To Change Weapon:

        if (Input.GetKey(KeyCode.E))
        {
            if(SwordActive)
            {
                
                UrumiActive = true;
                SwordActive = false;
            }

            else if (UrumiActive)
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

        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {

                mouseXStart = CamController.yRotation;
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
            
            Time.timeScale = 1f;
            if (CanAttack)
            {
                mouseXEnd = CamController.yRotation;
                // mouseYEnd = mousePos.y;
            }
                mouseXMove = (mouseXEnd - mouseXStart);
            
           
            tr.emitting = false;

            // mouseYMove = mouseYEnd - mouseYStart;


            if (Mathf.Abs(mouseXMove) > 0.2f)
            {
                if (mouseXMove < 0)
                {
                    if (ShouldAttack) //this was changed from the tutorial, as the tutorial did not use strike paths and used CanAttack here, but for this game resulted in attacks without strike paths.
                    {
                        if (SwordActive)
                            SwordAttackR();
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
                            SwordAttackL();
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


            else if (Mathf.Abs(mouseXMove) < 0.2f)
                
                
                    {

                     if (ShouldAttack)
                      {
                        if (canStab)
                       {
                        if (SwordActive)
                        {
                            SwordAttackS();
                            canStab = false;
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
                    whatHit.collider.gameObject.GetComponent<Animator>().SetTrigger("Hit");
                    HitParticle.SetActive(true);
                    if (fromRight)
                    {
                        
                        Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x - 0.6f,
                            transform.position.y + 0.2f, whatHit.collider.gameObject.transform.position.z + 0.6f), whatHit.collider.gameObject.transform.rotation);
                        if (SwordActive)
                        EnemyController.EnemyHealth -= 1;
                        else if (UrumiActive)
                            EnemyController.EnemyHealth -= 2;
                        print("enemy health" + EnemyController.EnemyHealth);
                    }
                    else if (fromLeft)
                    {
                        
                        Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x + 0.9f,
                            transform.position.y + 0.2f, whatHit.collider.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
                        if (SwordActive)
                            EnemyController.EnemyHealth -= 1;
                        else if (UrumiActive)
                            EnemyController.EnemyHealth -= 2;
                        print("enemy health" + EnemyController.EnemyHealth);

                    }

                    else if (fromCentre)
                    {

                        Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x + 0.3f,
                            transform.position.y + 0.4f, whatHit.collider.gameObject.transform.position.z + 0.5f), Quaternion.Euler(0, -45, 0));
                        if (SwordActive)
                            EnemyController.EnemyHealth -= 2;
                        else if (UrumiActive)
                            EnemyController.EnemyHealth -= 4;
                        print("enemy health" + EnemyController.EnemyHealth);

                    }
                }
            }
            enemyHit = false;

        }
        //for right mouse button - camera not moving

        if (Input.GetMouseButtonDown(1))
        {
            if (CanAttack)
            {
                mouseXStart2 = CamController.yRotation2;

                canStab2 = true;
            }
        }

        
         if (Input.GetMouseButton(1))
        {
            CamController.sensX = 0;
            CamController.sensY = 0;

            if (CanAttack)
            {
                mouseXStart = CamController.yRotation2;
            }
            
            
            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation2, -90f, 90f);
            
            cam2.transform.rotation = Quaternion.Euler(CamController.xRotation2, CamController.yRotation2, 0);
            orientation.rotation = Quaternion.Euler(0, CamController.yRotation2, 0);
            // mouseYStart = mousePos.y;
            if (CanAttack)
            {
                tr.emitting = true;
                ShouldAttack = true;
            }
            

        }

        else 
        {
            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
            CamController.yRotation2 = CamController.yRotation;
            //CamController.yRotation2 = Mathf.Clamp(CamController.yRotation, -90f, 90f);
            cam2.transform.rotation = cam.transform.rotation;
        }
        



         if (Input.GetMouseButtonUp(1) && !Input.GetMouseButtonDown(1))
        {
            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
            CamController.yRotation2 = CamController.yRotation;
            //CamController.yRotation2 = Mathf.Clamp(CamController.yRotation, -90f, 90f);
            cam2.transform.rotation = cam.transform.rotation;
            //orientation.rotation = Quaternion.Euler(0, CamController.yRotation, 0);

            CamController.sensX = 1000;
            CamController.sensY = 1000;
            if (CanAttack)
            {
                mouseXEnd = CamController.yRotation2;
                // mouseYEnd = mousePos.y;
            }
            mouseXMove = (mouseXStart - mouseXEnd); //the reverse of the dynamic attack is used in the static attack here
            mouseXMove2 = (mouseXStart2 - mouseXEnd); // this is to check the single value from the mousebuttonDown for determining if it is a stab or not.
            tr.emitting = false;

            // mouseYMove = mouseYEnd - mouseYStart;

            

            if (Mathf.Abs(mouseXMove2) > 0.2f)
            {

                if (mouseXMove < 0)
                {
                    if (ShouldAttack)
                    {
                        canStab2 = false;
                        SwordAttackR();
                    }
                }

                else if (mouseXMove > 0)
                {
                    if (ShouldAttack)
                    {
                        canStab2 = false;
                        SwordAttackL();
                    }
                }
            }

            else if (Mathf.Abs(mouseXMove2) < 0.2f)
            {
                {

                    if (ShouldAttack)
                    {
                        if (canStab2)
                        {
                            
                            canStab2 = false;

                            SwordAttackS();


                        }
                    }
                }
            }

       
        }





    }


    IEnumerator ResetAttackCooldown()
    {
        ShouldAttack = false;
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        UrumiHit = false;
        
       
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.1f);
        isAttacking = false;
        
    }


}

