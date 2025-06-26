using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public float mouseSensitivity = 3.0f;

    //�㉺�̊p�x
    public float minVerticalAngle = -60.0f;
    public float maxVerticalAngle = 60.0f;

    //���䂤�̂�����
    public float minHorizontalAngle = -90.0f;
    public float maxHorizontalAngle = 90.0f;

    //�v���C����Camera�̊p�x
    float verticalRotation = 0;
    float horizontalRotation = 0;

    //�v���C�J�n��Camera�̍��E�̊p�x
    float initialY = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //��ʒ��S�ɃJ�[�\�������b�N
        Cursor.visible = false; //�J�[�\�����\��

        Vector3 angles = transform.eulerAngles; //�v���C�J�n�̂��߂�̂�����
        initialY = angles.y; //���炽�߂�Y���̊�̂��߂�̒l�ɂ��
        horizontalRotation = 0f; //���m�ɏ����̊p�x��0
        verticalRotation = angles.x; //Camera�̏����̊p�x�㉺������Ă���
    }


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //���̎��̂܂����ɂ��������ɉ��������l�̐ςݏd��
        horizontalRotation += mouseX;
        //�ő�B�ŏ��ɍi�荞�݂����
        horizontalRotation = Mathf.Clamp(horizontalRotation, minHorizontalAngle, maxHorizontalAngle);


        verticalRotation -= mouseY;
        verticalRotation -= Mathf.Clamp(verticalRotation,minVerticalAngle, maxVerticalAngle);

        float yRotation = initialY + horizontalRotation;

        //Camera�̊p�x�����肷��
        transform.rotation = Quaternion.Euler(verticalRotation,yRotation,0);
    }
}
