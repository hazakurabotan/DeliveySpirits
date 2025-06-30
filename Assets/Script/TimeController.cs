using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public float startTime = 30.0f; //カウントダウンの基準
    public float displayTime;　//UIと連動する予定の残時間
    float pastTime; // 経過時間
    bool isTimeOver; //カウントが0になったかどうか　※0なら止める

    // Start is called before the first frame update
    void Start()
    {
        //まずは基準時間をセット
        displayTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        //タイムオーバーなら何もしない※ゲームクリア状態にある
        if (isTimeOver) return;

        //経過時間の産出
        pastTime += Time.deltaTime;

        //残り時間の産出
      displayTime = startTime - pastTime;

        //もしも残り時間が0になったときに何をするのか？
        if (displayTime <= 0)
        {
            displayTime = 0;
            isTimeOver = true;
        }
        
    }
}
