using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Danger : MonoBehaviour
{
    public float dangerSpeed = 10.0f();


    // Start is called before the first frame update
    void Start()
    {
        //10�b��ɏ���
        Destroy(gameObject,10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //�������Q�[���X�e�[�^�X��timeover�Ȃ�
        //�R���C�_�[���I�t
        //������

        if(GameController.gameSata = GameState.timeover)

        {
           GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject);

        }

        //�����̍��W��O����(transform.forward)�ɑ΂��āAdangerSpeed�̌W���������Ȃ���ω����Ă���
        transform.position += transform.forward * dangerSpeed * Time.deltaTime ;
    }
}
