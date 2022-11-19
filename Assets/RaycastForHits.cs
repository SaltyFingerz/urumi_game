using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForHits : MonoBehaviour
{
    /*
    public static RaycastHit whatHit;
    public static Vector3 collision = Vector3.zero;
    public static Vector3 target = new Vector3(0, 0, 10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (whatHit.collider == null)
        {
            Gizmos.color = Color.black;
        }
        else if (whatHit.collider.gameObject.CompareTag("Enemy"))
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
        int mask = 1 << LayerMask.NameToLayer("Default");
        //mask |= 1 << LayerMask.NameToLayer("Enemy"); //this is for adding additional layers
        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;
        if (DirectionDetection.SwordActive)
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
        else if (DirectionDetection.UrumiActive) // a different raycast is used for the urumi, with a larger max distance to detect attacks from a further distance as the urumi sword is longer than the standard sword.
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
    }*/
}
