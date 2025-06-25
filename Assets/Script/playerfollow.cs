using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerfollow : MonoBehaviour
{
    Vector3 diff; //�^�[�Q�b�g�Ƃ̋����̂�
    GameObject player; //�^�[�Q�b�g�ƂȂ�player

    public float foloowSpeed; //Camera�̕⊮speed

    public Vector3 defaultPos = new Vector3(0, 5, -8);
    public Vector3 defaultRotate = new Vector3(12, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = defaultPos;
        transform.rotation = Quaternion.Euler(defaultRotate); // rotation��Quaternion�^

        player = GameObject.FindGameObjectWithTag("Player");

        //�v���C���[�Ƃ��߂�̂���肩���������
        diff = player.transform.position - transform.position;
    }




    // Update is called once per frame
    void LateUpdate() //Update��肠�Ƃɂ���������
    {
        if (player != null)
        {
            //���񂯂��ق���������Ă��߂�������Ă��ɂ��̂΂���ɂ�������
            transform.position = Vector3.Lerp(transform.position,player.transform.position-diff,foloowSpeed*Time.deltaTime); 
            //Lerp�i ���̈ʒu�A�S�[���Ƃ��܂����ʒu�A��肠���j
        }
        
    }
}
