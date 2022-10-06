using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject Sword, Urumi, Shield;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public AudioClip SwordAttackSound;
    public bool isAttacking = false;
    public bool fromRight = false;
    public bool fromLeft = false;
    // Start is called before the first frame update

    public void SwordAttackR()
    {
        isAttacking = true;
        fromRight = true;
        fromLeft = false;
        CanAttack = false;
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
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("AttackL");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetMouseButtonDown(1)) //0 stands for left click 1 for right
        if (Input.GetMouseButtonUp(0) && DirectionDetection.mouseXMove < 0 )
        {
            if (CanAttack)
            {
                SwordAttackR();
            }
        }

        if (Input.GetMouseButtonUp(0) && DirectionDetection.mouseXMove > 0 ) //0 stands for left click 1 for right
        {
            if (CanAttack)
            {
                SwordAttackL();
            }
        }
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;

    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
