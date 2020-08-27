using UnityEngine;

public class StageTransition : MonoBehaviour
{
    public float smoothing = 1000f;
    public Transform target1;
    public Transform target2;
    public Collision collision;
    public HoleMovement2 holeMovement;
    public Transform camHolder;

    void Start() {

        camHolder = Camera.main.transform.parent;
        holeMovement = gameObject.GetComponent<HoleMovement2>();
    }
    void Update() {
        if (collision.stage1complete) {

            StageTrans(target2);
        }
    }

    void StageTrans(Transform target) {
        Game.isGameover = true;
        if (Mathf.Abs(transform.position.x) > 0.1f) {

            transform.position = new Vector3(Mathf.Lerp(transform.position.x, 0, smoothing * Time.deltaTime), transform.position.y, transform.position.z);

        } else {

            if (Vector3.Distance(transform.position, target.position) > 0.1f) {

                transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
                camHolder.position = new Vector3(camHolder.position.x, camHolder.position.y, Mathf.Lerp(camHolder.position.z, -43, smoothing * Time.deltaTime));
            } else {

                collision.stage1complete = false;

                holeMovement.moveLimitVerTop = -82.87f;
                holeMovement.moveLimitVerBot = -47.76f;

            }
        }
    }
}