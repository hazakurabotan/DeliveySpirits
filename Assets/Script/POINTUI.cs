using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POINTUI : MonoBehaviour
{

    Camera cam;
    public RectTransform uiTransform; //大将のレクとトランスフォーむ

    public Vector3 wordTarget; //ワールド座標

    public float displayTime = 1.0f;
    public float floatUPSpeed = 0.5f;

    float timer; //時間計測用
    bool isShowing; //表示されてるか

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
            //Y方向にちょっとずすじょうしょう
            wordTarget += Vector3.up * floatUPSpeed * Time.deltaTime;

            //ワールド座標からスクリーンUI座標に変換
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
    wordTarget = worldPosition;//showメソッドの発動について
        timer = displayTime;//何びょうだすかのあたい
        isShowing = true;//表情のはじまり
        uiTransform.gameObject.SetActive(true);//大将UIを表示

    }
}
