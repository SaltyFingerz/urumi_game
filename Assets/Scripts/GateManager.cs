using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public GameObject Skeleton1;
    public GameObject Skeleton2;
    public GameObject Skeleton3;
    public GameObject Skeleton4;
    public GameObject Skeleton5;
    public GameObject Skeleton6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(CompareTag("firstGate") && (!Skeleton1.activeSelf && !Skeleton2.activeSelf))
        {
            gameObject.SetActive(false);
        }

        if (CompareTag("secondGate") && (!Skeleton1.activeSelf))
        {
            gameObject.SetActive(false);
        }

        if(CompareTag("thirdGate") && (!Skeleton1.activeSelf && !Skeleton2.activeSelf && !Skeleton3.activeSelf && !Skeleton4.activeSelf && !Skeleton5.activeSelf && !Skeleton6.activeSelf))
        {
            gameObject.SetActive(false);
        }
    }
}
