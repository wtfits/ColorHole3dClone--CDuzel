using System.Collections;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public bool stage1complete;
    float shakeTime = .5f;
    float shakeMagnitude = .25f;


    void OnTriggerEnter(Collider other) {

        if (!Game.isGameover && !stage1complete) {        
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
                    StartCoroutine(LoadNextLevel());                   
                }
            }

            if (tag.Equals ("BadO")) {

                StartCoroutine(Fail());

            }
            IEnumerator LoadNextLevel() {

                yield return new WaitForSeconds(3);
                
                Level.Instance.LoadNextLevel();
            }

            IEnumerator Fail() {
                //Camera shake

                while (shakeTime > 0) {
                    Camera.main.transform.localPosition = Random.onUnitSphere * shakeMagnitude;
                    shakeTime -= Time.deltaTime;
                    yield return null;
                }

                Level.Instance.RestartLevel();
            }
        }
    }

}

    
