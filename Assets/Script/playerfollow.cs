using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerfollow : MonoBehaviour
{
    Vector3 diff; //ターゲットとの距離のさ
    GameObject player; //ターゲットとなるplayer

    public float foloowSpeed; //Cameraの補完speed

    public Vector3 defaultPos = new Vector3(0, 5, -8);
    public Vector3 defaultRotate = new Vector3(12, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = defaultPos;
        transform.rotation = Quaternion.Euler(defaultRotate); // rotationはQuaternion型

        player = GameObject.FindGameObjectWithTag("Player");

        //プレイヤーとかめらのきょりかんをきおく
        diff = player.transform.position - transform.position;
    }




    // Update is called once per frame
    void LateUpdate() //Updateよりあとにうごくもの
    {
        if (player != null)
        {
            //せんけいほかんをつかってかめらをもくてきにちのばしょにうごかす
            transform.position = Vector3.Lerp(transform.position,player.transform.position-diff,foloowSpeed*Time.deltaTime); 
            //Lerp（ 今の位置、ゴールとしました位置、わりあい）
        }
        
    }
}
