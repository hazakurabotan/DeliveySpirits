using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TimeController timeCnt;
    public TextMeshProUGUI timeText;


    // Start is called before the first frame update
    void Start()
    {
        timeCnt = GetComponent<TimeController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.gameSate == GameState.playing)
        {
            timeText.text = Mathf.Ceil(timeCnt.displayTime).ToString();
        }
    }
}
