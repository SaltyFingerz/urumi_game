using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (DirectionDetection.enemyRightHit  || DirectionDetection.enemyLeftHit || DirectionDetection.enemyCenterHit || DirectionDetection.enemyDownHit || DirectionDetection.enemyUpHit)
       
        { SetSingleColor(this.GetComponent<TrailRenderer>(), Color.magenta); }
        else
            SetSingleColor(this.GetComponent<TrailRenderer>(), Color.green);
    }

    void SetSingleColor(TrailRenderer trailRendererToChange, Color newColor)
    {
        trailRendererToChange.startColor = newColor;
        trailRendererToChange.endColor = newColor;
    }
}
