using UnityEngine;

public class HoleMovement2 : MonoBehaviour
{
    [SerializeField] Transform holeLocation;

    float moveSpeed;
    public float moveLimitHorizontal = 8.66f;
    public float moveLimitVerTop = -11.13f;
    public float moveLimitVerBot = 24.2f;

    Vector3 mouseClick, targetPos;
    float x, y;

    void Update() {

        //Using Mouse

#if UNITY_EDITOR

        moveSpeed = 35;


        Game.isMoving = Input.GetMouseButton(0);
        if (!Game.isGameover && Game.isMoving) {

            MoveHole();

        }
        if (Game.isGameover && Game.isMoving) {

            Game.isGameover = false;
            ///bişey bişey

        }
#else
        //Mobile Move

        moveSpeed = 5;

        Game.isMoving = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;

        if (!Game.isGameover && Game.isMoving) {

            MoveHole();

        }
        if (Game.isGameover && Game.isMoving) {

            Game.isGameover = false;
            ///bişey bişey

        }
#endif

    }

    void MoveHole() {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        mouseClick = Vector3.Lerp(
            holeLocation.position,
            holeLocation.position + new Vector3(-x, 0f, -y),
            moveSpeed * Time.deltaTime
        );

        targetPos = new Vector3(
        Mathf.Clamp(mouseClick.x, -moveLimitHorizontal, moveLimitHorizontal),
        mouseClick.y,
        Mathf.Clamp(mouseClick.z,  moveLimitVerTop, moveLimitVerBot)
        );

        holeLocation.position = targetPos;

    }

}