using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailManager : MonoBehaviour
{
   // this script can be used to set the attack trail to change color depending on if it crosses an enemy. 
   //It is not currently being used, as it was found to not be necesary as there is already visual and audio feedback on whether the player hits the enemy, because it seemed to overcomplicate the user experience, and to not draw the players attention away from the enemies onto the UI.
  


    
    void Update()
    { 
        if (DirectionDetection.enemyRightHit  || DirectionDetection.enemyLeftHit || DirectionDetection.enemyCenterHit || DirectionDetection.enemyDownHit || DirectionDetection.enemyUpHit) // this is to change the color of the trail depending on if the player is about to hit an enemy with it / if the trail crosses an enemy.
       
        { SetSingleColor(this.GetComponent<TrailRenderer>(), Color.magenta); } //color when hitting enemy. How to change the colour of the trail with code was found by following the tutorial: https://youtu.be/TeSmW6lDzhs
        else
            SetSingleColor(this.GetComponent<TrailRenderer>(), Color.blue); //color when not hitting enemy
        
    }

    void SetSingleColor(TrailRenderer trailRendererToChange, Color newColor)
    {
        trailRendererToChange.startColor = newColor; // this was done following the tutorial: https://youtu.be/TeSmW6lDzhs
        trailRendererToChange.endColor = Color.black; //a different color is used here to create  a gradient from the start to the end of the trail. The tutorial cited above provided the basis for this line, which was modified to bea  different colour to produce a gradient. 
    }
    

    

}
   
