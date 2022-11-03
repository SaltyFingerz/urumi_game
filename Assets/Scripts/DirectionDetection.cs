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
    public LayerMask layer;
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
    public static bool isAttacking = false;
    public static bool fromRight = false;
    public static bool fromLeft = false;
    public static bool fromCentre = false;

    public static bool enemyHit = false;

    public bool canStab = false;
    public bool canStab2 = false;


    public GameObject targetPoint;
    private TrailRenderer tr;

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

    private void OnDrawGizmos()
    {

        if (whatHit.collider.gameObject.CompareTag("Enemy"))
        {
            Gizmos.color = Color.red;
        }
        else
        { Gizmos.color = Color.green; }

       Gizmos.DrawWireSphere(collision, radius: 0.5f);
        Gizmos.DrawLine(transform.position, collision);
    }
    // Update is called once per frame
    void Update()
    {

        //Debug.DrawRay(this.transform.position, this.transform.forward * 5, Color.green);


        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out whatHit, maxDistance: 5))
        {
            //lastHit = hit.transform.gameObject;
            collision = whatHit.point;
        }


        



            eulerAngY = cam.transform.localEulerAngles.y;

        //Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            
            
            // mouseYStart = mousePos.y;
            if (CanAttack)
            {
                if (whatHit.collider.gameObject.CompareTag("Enemy"))
                {
                    enemyHit = true;
                }
                    mouseXStart = CamController.yRotation;
                Time.timeScale = 0.5f;
                tr.emitting = true;
                ShouldAttack = true; //it should only attack if the trail has been emitted.
                canStab = true;
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
                        SwordAttackR();
                    }
                }

                else if (mouseXMove > 0)
                {
                    if (ShouldAttack)
                    {
                        SwordAttackL();
                    }
                }
            }


            else if (Mathf.Abs(mouseXMove) < 0.2f)
                
                
                    {

                        if (ShouldAttack)
                        {
                            if (canStab)
                            {
                        
                                SwordAttackS();
                                canStab = false;
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
                        print("hurt from right");
                        Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x - 0.6f,
                            transform.position.y + 0.2f, whatHit.collider.gameObject.transform.position.z + 0.6f), whatHit.collider.gameObject.transform.rotation);
                       // EnemyController.EnemyHealth = -1;

                    }
                    else if (fromLeft)
                    {
                        print("hurt from left");
                        Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x + 0.9f,
                            transform.position.y + 0.2f, whatHit.collider.gameObject.transform.position.z - 0.2f), Quaternion.Euler(0, 0, 0));
                     //   EnemyController.EnemyHealth = -1;


                    }

                    else if (fromCentre)
                    {

                        Instantiate(HitParticle, new Vector3(whatHit.collider.gameObject.transform.position.x + 0.3f,
                            transform.position.y + 0.4f, whatHit.collider.gameObject.transform.position.z + 0.5f), Quaternion.Euler(0, -45, 0));
                     //   EnemyController.EnemyHealth = -3;


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
        
       
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.1f);
        isAttacking = false;
        
    }


}

