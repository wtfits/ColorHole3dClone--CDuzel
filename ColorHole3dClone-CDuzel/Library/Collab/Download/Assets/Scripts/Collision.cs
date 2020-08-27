using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool stage1complete;

    void OnTriggerEnter(Collider other) {

        if (!Game.isGameover) {        
            string tag = other.tag;

            if (tag.Equals("GoodO")) {

                if(other.transform.parent.name == "Objects") { 
                    Level.Instance.objectsInScene1--;
                    UIManager.Instance.UpdateLevelProgress();
                    Magnet.Instance.RemoveFromMagnetField(other.attachedRigidbody);
                    Destroy(other.gameObject);
                        if (Level.Instance.objectsInScene1 == 0) {
                        stage1complete = true;
                    }

                }   else if (other.transform.parent.name == "Objects2"){

                    Level.Instance.objectsInScene2--;
                    UIManager.Instance.UpdateLevelProgress();
                    Magnet.Instance.RemoveFromMagnetField(other.attachedRigidbody);
                    Destroy(other.gameObject);
                }
                
                if(Level.Instance.objectsInScene1 == 0 && Level.Instance.objectsInScene2 == 0) {
                    Level.Instance.PlayWinFx();
                    StartCoroutine(ExampleCoroutine());
                    
                }
            }

            if (tag.Equals ("BadO")) {
                //Restart
                Game.isGameover = true;
                Level.Instance.RestartLevel();
            }
            IEnumerator ExampleCoroutine() {

                yield return new WaitForSeconds(3);
                Level.Instance.LoadNextLevel();
            }
        }
    }

}

    
