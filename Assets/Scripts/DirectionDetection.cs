using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionDetection : MonoBehaviour
{

    public GameObject Sword, Urumi, Shield;

    public static float mouseXMove;
    [SerializeField]
    public float mouseYMove;
    [SerializeField]
    private float mouseXStart;
    [SerializeField]
    private float mouseXEnd;

    public GameObject cam;
    private float xRotation;

    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public AudioClip SwordAttackSound;
    public bool isAttacking = false;
    public bool fromRight = false;
    public bool fromLeft = false;

    public GameObject targetPoint;
    private TrailRenderer tr;

    [SerializeField]
    float eulerAngY;
  
    // Start is called before the first frame update
    void Start()
    {
        tr = targetPoint.GetComponent<TrailRenderer>();
    }
    public void SwordAttackR()
    {
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
       // CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordAttackL()
    {
        isAttacking = true;
        fromLeft = true;
        fromRight = false;
       // CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }
    // Update is called once per frame
    void Update()
    {

      
        eulerAngY = cam.transform.localEulerAngles.y;

        //Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            
             mouseXStart = CamController.yRotation; //this works, after trying many variables here
            // mouseYStart = mousePos.y;
            print("startX is" + mouseXStart);
            tr.emitting = true;

        }

        if (Input.GetMouseButtonUp(0))
        {
             mouseXEnd = CamController.yRotation;
           // mouseYEnd = mousePos.y;
            
            mouseXMove = (mouseXEnd - mouseXStart);

            tr.emitting = false;

            // mouseYMove = mouseYEnd - mouseYStart;
            

           
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

