using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{

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
    public float AttackCooldown = 1.0f;
    public AudioClip SwordAttackSound;
    public bool isAttacking = false;
    public bool fromRight = false;
    public bool fromLeft = false;
    public bool fromCentre = false;
    public bool canStab = false;
  

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
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
        fromCentre = false;
       // CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordAttackL()
    {
        canStab = false;
        isAttacking = true;
        fromLeft = true;
        fromRight = false;
        fromCentre = false;
       // CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }


    public void SwordAttackS()
    {
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = true;
        // CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackS");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
        canStab = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Abs(mouseXMove) == 0f)
        {
            print("mouseMove Abs = 0");
        }

            eulerAngY = cam.transform.localEulerAngles.y;

        //Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            
             mouseXStart = CamController.yRotation; 
            // mouseYStart = mousePos.y;
            
            tr.emitting = true;
            canStab = true;


        }

        if (Input.GetMouseButtonUp(0))
        {

            mouseXEnd = CamController.yRotation;
            // mouseYEnd = mousePos.y;

            mouseXMove = (mouseXEnd - mouseXStart);
            print(mouseXMove);
            tr.emitting = false;

            // mouseYMove = mouseYEnd - mouseYStart;


            if (Mathf.Abs(mouseXMove) > 0.2f)
            {
                if (mouseXMove < 0)
                {
                    if (CanAttack)
                    {
                        SwordAttackR();
                    }
                }

                else if (mouseXMove > 0)
                {
                    if (CanAttack)
                    {
                        SwordAttackL();
                    }
                }
            }


            else if (Mathf.Abs(mouseXMove) < 0.2f)
                
                
                    {

                        if (CanAttack)
                        {
                            if (canStab)
                            {
                                SwordAttackS();
                                canStab = false;
                            }
                        }
                    }
                
        }
        //for right mouse button - camera not moving

      /*  if (Input.GetMouseButtonDown(1))
        {
            mouseXStart2 = CamController.yRotation2;
            canStab = true;
        }
      */

            if (Input.GetMouseButton(1))
        {
            CamController.sensX = 0;
            CamController.sensY = 0;
            mouseXStart = CamController.yRotation2;

            
            
            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation2, -90f, 90f);
            
            cam2.transform.rotation = Quaternion.Euler(CamController.xRotation2, CamController.yRotation2, 0);
            orientation.rotation = Quaternion.Euler(0, CamController.yRotation2, 0);
            // mouseYStart = mousePos.y;
            tr.emitting = true;

        }

       

        else
        {
            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
            CamController.yRotation2 = CamController.yRotation;
            //CamController.yRotation2 = Mathf.Clamp(CamController.yRotation, -90f, 90f);
            cam2.transform.rotation = cam.transform.rotation;
        }

        if (Input.GetMouseButtonUp(1))
        {
            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
            CamController.yRotation2 = CamController.yRotation;
            //CamController.yRotation2 = Mathf.Clamp(CamController.yRotation, -90f, 90f);
            cam2.transform.rotation = cam.transform.rotation;
            //orientation.rotation = Quaternion.Euler(0, CamController.yRotation, 0);

            CamController.sensX = 1000;
            CamController.sensY = 1000;

            mouseXEnd = CamController.yRotation2;
            // mouseYEnd = mousePos.y;

            mouseXMove = (mouseXStart - mouseXEnd); //the reverse of the dynamic attack is used in the static attack here
          //  mouseXMove2 = (mouseXStart2 - mouseXEnd); // this is to check the single value from the mousebuttonDown for determining if it is a stab or not.
            tr.emitting = false;

            // mouseYMove = mouseYEnd - mouseYStart;

            print("xrotation is" + CamController.xRotation + "xrotation2 is" + CamController.xRotation2);
            print("yrotation is" + CamController.yRotation + "yrotation2 is" + CamController.yRotation2);

        //    if (Mathf.Abs(mouseXMove2) > 0.2f)
         //   {

                if (mouseXMove < 0)
                {
                    if (CanAttack)
                    {
                        SwordAttackR();
                    }
                }

                else if (mouseXMove > 0)
                {
                    if (CanAttack)
                    {
                        SwordAttackL();
                    }
                }
            }
      //  }
        /*
        else if (Mathf.Abs(mouseXMove2) < 0.2f)
        {
            {

                if (CanAttack)
                {
                    if (canStab)
                    {
                        SwordAttackS();
                        canStab = false;
                    }
                }
            }
        }

        */

    }


    IEnumerator ResetAttackCooldown()
    {

        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
        print("resetattackcooldown");
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
        print("resetattackbool");
    }


}

