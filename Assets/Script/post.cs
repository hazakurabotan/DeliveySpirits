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

    public PostType type; //���삵���񋓌^�������ϐ��@�����̃^�C�v�����߂�
    bool posted; //�z�B�ς݂��ǂ���

    public int getPoint = 50; //�|�C���g
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
                        //��z�����̏���
                        PostComp();    
                    break;
                case PostType.box2:
                    if (other.gameObject.CompareTag("Box2"))
                        //��z�����̏���
                        PostComp();
                    break;
                case PostType.box3:
                    if (other.gameObject.CompareTag("Box3"))
                        //��z�����̏���
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
