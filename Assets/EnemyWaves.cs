using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{

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
    private GameObject chaseEnemyID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.chase1)
        {
            SkeletonZone1.GetComponent<EnemyController>().ChasePlayer();
        }

        if (PlayerMovement.chase2)
        {
            SkeletonZone2.GetComponent<EnemyController>().ChasePlayer();
        }

        if (PlayerMovement.chase3)
        {
            SkeletonZone3.GetComponent<EnemyController>().ChasePlayer();
        }
        if (PlayerMovement.chase4)
        {
            SkeletonZone4.GetComponent<EnemyController>().ChasePlayer();
        }
        if (PlayerMovement.chase5)
        {
            SkeletonZone5.GetComponent<EnemyController>().ChasePlayer();
        }
        if (PlayerMovement.chase6)
        {
            SkeletonZone6.GetComponent<EnemyController>().ChasePlayer();
        }
        if (PlayerMovement.chase7)
        {
            SkeletonZone7.GetComponent<EnemyController>().ChasePlayer();
        }

        if (!SkeletonZone7.activeSelf)
        {
            SkeletonWave2a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave2b.GetComponent<EnemyController>().ChasePlayer();
        }
        if (!SkeletonWave2a.activeSelf && !SkeletonWave2b.activeSelf)
        {
            SkeletonWave3a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave3b.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave3c.GetComponent<EnemyController>().ChasePlayer();
        }
        if (!SkeletonWave3a.activeSelf && !SkeletonWave3b.activeSelf && !SkeletonWave3c.activeSelf)
        {
            SkeletonWave4a.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4b.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4c.GetComponent<EnemyController>().ChasePlayer();
            SkeletonWave4d.GetComponent<EnemyController>().ChasePlayer();
        }
    }
}
