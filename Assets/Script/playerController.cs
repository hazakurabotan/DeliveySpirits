using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    const int MinLane = -1;
    const int MaxLane = 1;
    const float LaneWidth = 3.0f;

    CharacterController controller;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;
    int targetLane = 0;

    public float gravity;
    public float speedZ;
    public float speedX;
    public float speedJump;
    public float accelerationZ;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) MoveToLeft();
        if (Input.GetKeyDown(KeyCode.D)) MoveToRight();
        if (Input.GetKeyDown(KeyCode.Space)) Jump();

        accelerationZ += Time.deltaTime;
        moveDirection.z = Mathf.Clamp(accelerationZ, 0, speedZ);

        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
        moveDirection.x = ratioX * speedX;

        transform.Rotate(0, Input.GetAxis("Horizontal") * 3, 0);

        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            moveDirection.y = speedJump;
            //animator.SetTrigger("Jump");
        }

        moveDirection.y -= gravity * Time.deltaTime;

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        // controller.Move(moveDirection * Time.deltaTime); ‘O‚ÉˆÚ“®‚·‚é‚È‚ç‚±‚ê‚Å‚à‚¢‚¢


        if (controller.isGrounded) moveDirection.y = 0;

        //animator.SetBool("run", moveDirection.z > 0.0f);
    }

    public void MoveToRight()
    {
        if (controller.isGrounded && targetLane < MaxLane) targetLane++;
    }

    public void MoveToLeft()
    {
        if (controller.isGrounded && targetLane > MinLane) targetLane--;
    }

    public void Jump()
    {
        if (controller.isGrounded)
            moveDirection.y = speedJump;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Danger"))
        {
            controller.Move(new Vector3(0,5,0));
            controller.transform.Rotate(Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45));

            GameController.gameState = GameState.gameover;
            Destroy(gameObject, 3.0f);
        }
    }
}
