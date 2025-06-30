using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] boxPrefabs;
    Transform player; //プイヤーの位置

    public static int boxNum;　//配列の何番目のボックスじゃ
    public float shootSpeed = 100f; //投げた力
    public float upSpeed = 30f; //投げた時の上向きの力

    Camera cam;　//Camera情報取得

    bool startShoot; //シュート可能かどうか

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShootEnabled", 0.5f);
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Camera情報
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
        //Playerが消滅していなければ
        if (player != null)
        {

            //配列のまかからしていされた番号のＢＯＸを生成
            GameObject box = Instantiate(boxPrefabs[boxNum],player.position,Quaternion.identity);

            //生成したBoxのRigidbodyを取得
            Rigidbody rbody = box.GetComponent<Rigidbody>();


            //生成したBoxのaddホォースの力でシュート
            //かめら角度をこうりょしたシュート
            //飛び出す元の位置はPlayerの位置
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
