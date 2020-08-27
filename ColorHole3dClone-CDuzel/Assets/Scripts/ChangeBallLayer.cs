using UnityEngine;

public class ChangeBallLayer : MonoBehaviour {

    public int LayerOnEnter; // BallInHole
    public int LayerOnExit;  // BallOnTable
	
    //Changes the object layer on trigger. LayerOnEnter dont collide with ground so the object falls in. 

    //Used modified Standard Shader files to change rendering order of the table, objects and hole which i modelled in blender. This gives the transparent effect on the hole.
    void OnTriggerEnter(Collider other)
    {
        if (!Game.isGameover) { 
            if(other.gameObject.tag == "GoodO" || other.gameObject.tag == "BadO")
            {

                other.gameObject.layer = LayerOnEnter;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "GoodO" || other.gameObject.tag == "BadO")
        {
            other.gameObject.layer = LayerOnExit;
        }
    }
}