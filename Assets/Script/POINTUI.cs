using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POINTUI : MonoBehaviour
{

    Camera cam;
    public RectTransform uiTransform; //�叫�̃��N�ƃg�����X�t�H�[��

    public Vector3 wordTarget; //���[���h���W

    public float displayTime = 1.0f;
    public float floatUPSpeed = 0.5f;

    float timer; //���Ԍv���p
    bool isShowing; //�\������Ă邩

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            //Y�����ɂ�����Ƃ������傤���傤
            wordTarget += Vector3.up * floatUPSpeed * Time.deltaTime;

            //���[���h���W����X�N���[��UI���W�ɕϊ�
            Vector3 screenPos = cam.WorldToScreenPoint(wordTarget);
            uiTransform.position = screenPos;

            timer = Time.deltaTime;
            if(timer <= 0)
            {
                uiTransform.gameObject.SetActive(false);
                isShowing = false;
            }
                }
    }

    public void Show(Vector3 worldPosition)
    { 
    wordTarget = worldPosition;//show���\�b�h�̔����ɂ���
        timer = displayTime;//���т傤�������̂�����
        isShowing = true;//�\��̂͂��܂�
        uiTransform.gameObject.SetActive(true);//�叫UI��\��

    }
}
