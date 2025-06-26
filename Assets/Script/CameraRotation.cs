using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public float mouseSensitivity = 3.0f;

    //上下の角度
    public float minVerticalAngle = -60.0f;
    public float maxVerticalAngle = 60.0f;

    //さゆうのかくど
    public float minHorizontalAngle = -90.0f;
    public float maxHorizontalAngle = 90.0f;

    //プレイ中のCameraの角度
    float verticalRotation = 0;
    float horizontalRotation = 0;

    //プレイ開始のCameraの左右の角度
    float initialY = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //画面中心にカーソルをロック
        Cursor.visible = false; //カーソルを非表示

        Vector3 angles = transform.eulerAngles; //プレイ開始のかめらのかくど
        initialY = angles.y; //あらためてY軸の基準のかめらの値による
        horizontalRotation = 0f; //明確に初期の角度は0
        verticalRotation = angles.x; //Cameraの初期の角度上下をいれておく
    }


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //その時のまうすにうっごきに応じた数値の積み重ね
        horizontalRotation += mouseX;
        //最大。最小に絞り込みされる
        horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalAngle, maxHorizontalAngle);


        verticalRotation -= mouseY;
        verticalRotation -= Mathf.Clamp(verticalRotation,minVerticalAngle, maxVerticalAngle);

        float yRotation = initialY + horizontalRotation;

        //Cameraの角度を決定する
        transform.rotation = Quaternion.Euler(verticalRotation,yRotation,0);
    }
}
