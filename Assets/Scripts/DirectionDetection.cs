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

    public bool canStab = false;
    public bool canStab2 = false;

    public static bool ShouldAttack = false; //this is so that it only attacks when it had made a strike path first.
    public static bool fromRight = false;
    public static bool fromLeft = false;
    public static bool fromCentre = false;
    public static bool fromOver = false;
    public static bool fromUnder = false;
    public static bool fromBottomRight = false;
    public static bool fromBottomLeft = false;
    public static bool fromTopRight = false;
    public static bool fromTopLeft = false;
    public static bool enemyRightHit = false;
    public static bool enemyLeftHit = false;
    public static bool enemyCenterHit = false;
    public static bool enemyUpHit = false;
    public static bool enemyDownHit = false;

    public static int correctAttacks = 0;
   


    [SerializeField]
     float eulerAngY;
  

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

    public void SwordClashUR()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = false;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = true;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashUR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
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

    public void SwordClashOR()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = false;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = true;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashOR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
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

    public void SwordClashUL()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = false;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = true;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashUL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
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

    public void SwordClashOL()
    {
        ShouldAttack = false;
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        fromOver = false;
        fromUnder = false;
        CanAttack = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = true;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("ClashOL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
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

    public void UrumiAttackU()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = true;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackU");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashU()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = true;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashU");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiAttackO()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = true;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackO");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashO()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = true;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
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
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = true;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackFromTopLeft");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashOL()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = true;
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
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = true;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackFromTopRight");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashOR()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = false;
        fromTopRight = true;
        fromTopLeft = false;
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
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = true;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackFromBottomLeft");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashUL()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = false;
        fromBottomLeft = true;
        fromTopRight = false;
        fromTopLeft = false;
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
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = true;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("AttackFromBottomRight");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    public void UrumiClashUR()
    {
        canStab = false;
        canStab2 = false;
        isAttacking = true;
        fromRight = false;
        fromLeft = false;
        fromCentre = false;
        CanAttack = false;
        fromOver = false;
        fromUnder = false;
        fromBottomRight = true;
        fromBottomLeft = false;
        fromTopRight = false;
        fromTopLeft = false;
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashUR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
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

    public void UrumiClashR()
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
        anim.SetTrigger("ClashR");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
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

    public void UrumiClashL()
    {
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
        Animator anim = Urumi.GetComponent<Animator>();
        anim.SetTrigger("ClashL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(WhipAttackSound);
        AudioSource ac2 = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordClashSound);
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

    public void UrumiClashS()
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            print(EnemyID.name);
        }
        
            int mask = 1 << LayerMask.NameToLayer("Default");
        //mask |= 1 << LayerMask.NameToLayer("Enemy"); //this is for adding additional layers
        var ray = new Ray(origin: cam2.transform.position, direction: cam2.transform.forward);
            RaycastHit hit;
        if (SwordActive)
        {
          
            {
                if (Physics.Raycast(ray, out whatHit, maxDistance: 1.5f, mask)) //mask is used so that the raycast does not detect the sword/weapon
                {
                   
                    collision = whatHit.point;
                }
            }
        }
        else if (UrumiActive) // a different raycast is used for the urumi, with a larger max distance to detect attacks from a further distance as the urumi sword is longer than the standard sword.
        {
          
            {
                if (Physics.Raycast(ray, out whatHit, maxDistance: 10, mask)) //mask is used so that the raycast does not detect the sword/weapon
                {
                    
                    collision = whatHit.point;
                }
            }

        }


        
        if (!PlayerMovement.inRange && SwordActive)
        {
            EnemyID = null;
            enemyRightHit = false;
            enemyLeftHit = false;
            enemyUpHit = false;
            enemyDownHit = false;

        }


            eulerAngY = cam.transform.localEulerAngles.y;

       

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

        

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            preventAttack = false;
            mouseXStart = CamController.yRotation;
            mouseYStart = CamController.xRotation;

            CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
            CamController.yRotation2 = CamController.yRotation;
            //CamController.yRotation2 = Mathf.Clamp(CamController.yRotation, -90f, 90f);
            cam2.transform.rotation = cam.transform.rotation;

            if (CanAttack)
            {
               



                
                ShouldAttack = true; //it should only attack if the trail has been emitted.
                canStab = true;

                canStab2 = true;

                StartCoroutine(AttackTimer());

               
            }
        }


        if ((Input.GetMouseButton(1) || Input.GetMouseButton(0)) && !preventAttack)
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
                   /* if (UrumiActive)
                    {
                        UrumiHit = true;
                    } */
                    if (whatHit.collider.gameObject.CompareTag("Enemy")) 
                    {
                      
                        EnemyID = whatHit.collider.gameObject;


                        if(EnemyID.name.Contains("right") && EnemyID.name.Contains("left"))
                        {
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

        
           
        



     




        if (attackNow || ((Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0)) && !attackNow && !preventAttack))
        {

            mouseXEnd = CamController.yRotation2;
            mouseYEnd = CamController.xRotation2;


            mouseXMove = (mouseXEnd - mouseXStart);
            mouseYMove = (mouseYEnd - mouseYStart);

            StartCoroutine(DeactivateTrail());

            CamController.sensX = 1000;
            CamController.sensY = 1000;


            if (Mathf.Abs(mouseXMove) >= 1f || Mathf.Abs(mouseYMove) >= 1f) // checks if the attack is not a stab
            {
                if(Mathf.Abs(mouseXMove) > 8f && Mathf.Abs(mouseYMove) > 8f) // checks if the attack is diagonal
                {
                    if (mouseXMove > 0 && mouseYMove > 0) //  means the attack is coming from topleft
                    {
                        if (SwordActive)
                        {
                            if (!enemyUpHit)
                            {
                                SwordAttackFromTopLeft();
                               
                            }
                            else if (enemyUpHit)
                            {
                                SwordClashOL();
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
                    else if (mouseXMove > 0 && mouseYMove < 0) 
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

                    else if (mouseXMove < 0 && mouseYMove > 0) 
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

                    else if (mouseXMove < 0 && mouseYMove < 0)
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

        else if (Mathf.Abs(mouseXMove) < 1f && Mathf.Abs(mouseYMove) <1f)
        {
            {

                if (ShouldAttack)
                {
                   


                    if (SwordActive)
                    {
                        if (!enemyCenterHit)
                        {
                            SwordAttackS();
                           
                            canStab = false;
                        }
                        else if (enemyCenterHit)
                        {
                            SwordClashS();
                            canStab = false;
                          
                            enemyCenterHit = false;
                        }

                    }
                    else if (UrumiActive)
                    {
                        if (!enemyCenterHit)
                        {
                            UrumiAttackS();
                           
                            canStab = false;
                        }
                        else if (enemyCenterHit)
                        {
                            UrumiClashS();
                            
                            canStab = false;
                        }
                    }
  
                }
            }
        }
  
            attackNow = false;
            ShouldAttack = false;
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
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
        
    }

  IEnumerator ResetCam2()
    {
        yield return new WaitForSeconds(0.2f);
        CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
        CamController.yRotation2 = CamController.yRotation;
       
        cam2.transform.rotation = cam.transform.rotation;
       
    }

    IEnumerator DeactivateTrail()
    {
        
       tr.emitting = false;
        yield return new WaitForSeconds(0.2f); //this is to ensure the trail emittance is stopped before returning the trail to the centre, to prevent the trail being seen to return, to match single slashes with the trail.
        CamController.xRotation2 = Mathf.Clamp(CamController.xRotation, -90f, 90f);
        CamController.yRotation2 = CamController.yRotation;
        cam2.transform.rotation = cam.transform.rotation;
    }

    IEnumerator AttackTimer() // this is to trigger attacks without the player having to release the mouse button - the player can release the mouse button to attack slightly faster though
    {
        yield return new WaitForSeconds(0.3f);
        if (Input.GetMouseButton(1) || Input.GetMouseButton(0))
        {
            attackNow = true;
            preventAttack = true;
        }

    }

}

