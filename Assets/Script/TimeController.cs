using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public float startTime = 30.0f; //�J�E���g�_�E���̊
    public float displayTime;�@//UI�ƘA������\��̎c����
    float pastTime; // �o�ߎ���
    bool isTimeOver; //�J�E���g��0�ɂȂ������ǂ����@��0�Ȃ�~�߂�

    // Start is called before the first frame update
    void Start()
    {
        //�܂��͊���Ԃ��Z�b�g
        displayTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        //�^�C���I�[�o�[�Ȃ牽�����Ȃ����Q�[���N���A��Ԃɂ���
        if (isTimeOver) return;

        //�o�ߎ��Ԃ̎Y�o
        pastTime += Time.deltaTime;

        //�c�莞�Ԃ̎Y�o
      displayTime = startTime - pastTime;

        //�������c�莞�Ԃ�0�ɂȂ����Ƃ��ɉ�������̂��H
        if (displayTime <= 0)
        {
            displayTime = 0;
            isTimeOver = true;
        }
        
    }
}
