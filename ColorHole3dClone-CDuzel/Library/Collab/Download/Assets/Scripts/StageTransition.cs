using UnityEngine;
using System.Collections;

public class StageTransition : MonoBehaviour
{
    public float smoothing = 1000f;
    public Transform target1;
    public Transform target2;
    public Collision collision;
    public HoleMovement2 holeMovement;

    void Start() {

        holeMovement = gameObject.GetComponent<HoleMovement2>();
    }
    void Update() {
        if (collision.stage1complete) {
            StageTrans(target2);
        }
    }

    void StageTrans(Transform target) {
        Game.isGameover = true;
        if (Mathf.Abs(transform.position.x) > 0.01f) {

            transform.position = new Vector3(Mathf.Lerp(transform.position.x, 0, smoothing * Time.deltaTime), transform.position.y, transform.position.z);

        } else {
            if (Vector3.Distance(transform.position, target.position) > 0.05f) {
                transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Mathf.Lerp(Camera.main.transform.position.z, -43, smoothing * Time.deltaTime));

            } else {
                collision.stage1complete = false;

                //change moveLimits

                holeMovement.moveLimitsMinus.x = 9.29f;
                holeMovement.moveLimitsMinus.y = 84.54f;
                holeMovement.moveLimitsPlus.x = 8.94f;
                holeMovement.moveLimitsPlus.y = -51.43f;

            }

        }
    }

}