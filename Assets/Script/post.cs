using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PostType
{
    box1,
    box2,
    box3,
}


public class post : MonoBehaviour
{

    public PostType type; //自作した列挙型を扱う変数　自分のタイプを決める
    bool posted; //配達済みかどうか

    public int getPoint = 50; //ポイント
    public TextMeshProUGUI pointText;

    public POINTUI pointUI;


    private void OnTriggerEnter(Collider other)
    {
        if (!posted)
        {
            switch (type)
            {
                case PostType.box1:
                    if (other.gameObject.CompareTag("Box1"))
                        //宅配官僚の処理
                        PostComp();    
                    break;
                case PostType.box2:
                    if (other.gameObject.CompareTag("Box2"))
                        //宅配官僚の処理
                        PostComp();
                    break;
                case PostType.box3:
                    if (other.gameObject.CompareTag("Box3"))
                        //宅配官僚の処理
                        PostComp();
                    break;
            }
        }
            
        

    }

    void PostComp()
    {
        posted = true;

        Vector3 showPos = transform.position + Vector3.up * 1.5f;
        pointText.text = "+" + getPoint.ToString() + "PT";
        
        pointUI.Show(showPos);
        gamController.stagePoints += getPoint;
 

        Destroy(transform.parent.gameObject, 1.0f);
    }

}
