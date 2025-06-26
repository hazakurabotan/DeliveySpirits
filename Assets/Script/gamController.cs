using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum GameState
{
    timeover,
    playing,
    gameover,
    end

}



public class gamController : MonoBehaviour
{
    public static GameState gameSate;
    public static int stagePoints;

    // Start is called before the first frame update
    void Start()
    {
        gameSate = GameState.playing;
        stagePoints = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
