using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] boxPrefabs;
    Transform player; //�v�C���[�̈ʒu

    public static int boxNum;�@//�z��̉��Ԗڂ̃{�b�N�X����
    public float shootSpeed = 100f; //��������
    public float upSpeed = 30f; //���������̏�����̗�

    Camera cam;�@//Camera���擾

    bool startShoot; //�V���[�g�\���ǂ���

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShootEnabled", 0.5f);
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Camera���
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState != GameState.playing) 


        if (Input.GetMouseButtonDown(0))
        {
            if (startShoot) Shoot();
        }

        if (Input.GetMouseButtonUp(1))
        {
            boxNum++;
            if(boxPrefabs.Length == boxNum) boxNum = 0;
        }

    }

    void ShootEnabled()
    {
        startShoot = true;
    }

    void Shoot()
    {
        //Player�����ł��Ă��Ȃ����
        if (player != null)
        {

            //�z��̂܂����炵�Ă����ꂽ�ԍ��̂a�n�w�𐶐�
            GameObject box = Instantiate(boxPrefabs[boxNum],player.position,Quaternion.identity);

            //��������Box��Rigidbody���擾
            Rigidbody rbody = box.GetComponent<Rigidbody>();


            //��������Box��add�z�H�[�X�̗͂ŃV���[�g
            //���߂�p�x��������債���V���[�g
            //��яo�����̈ʒu��Player�̈ʒu
            rbody.AddForce
                (
                new Vector3(
                    cam.transform.forward.x * shootSpeed,
                    cam.transform.forward.y + upSpeed,
                    cam.transform.forward.z * shootSpeed
                    ),
                ForceMode.Impulse);
        }


    }

}
