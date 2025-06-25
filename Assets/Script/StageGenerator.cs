using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 50; //�����������������Ղ��͂�������ɂ������Ă�������

    int currentChipIndex; //���݂̂ǂ̂����Ղ݂Ă邩

    Transform player; //Player

    public GameObject[] stageChips; //��������I�u�W�F�N�g�̂����̂�

    public int startChipIndex = 0;�@//�����Ղ̔ԍ�
    public int perInstantiate = 5;�@//��Ԃ�ɂ����Ă�������
   
    
    //���ݐ��ق����I�u�W�F�N�g�̂����悤
    public List<GameObject> generatedStageList = new List<GameObject>();

    void Start()
    {
        //�g�����X�t�H�[�ނ̂ق���
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        currentChipIndex = startChipIndex - 1;
        UpdateStage(perInstantiate);
    }

    void Update()
    {
 
        int charaPositionIndex = (int)(player.position.z / StageChipSize);

        //���̃X�e�[�W�ɂ͂�������stage�̂������񂵂�����������܂�
        if (charaPositionIndex + perInstantiate > currentChipIndex)
        {
            UpdateStage(charaPositionIndex + perInstantiate);
        }
    }

    void UpdateStage(int toChipIndex)�@//�w���index�܂ł̐|�ā[���������Ղ������������ĊǗ�
    {
        if (toChipIndex < currentChipIndex) return;

        //�w��̃X�e�[�W�����Ղ̂�������
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i); //���������|�ā[�������Ղ��Ǘ����邷�ƒǉ� 
            generatedStageList.Add(stageObject);
        }
        //�X�e�[��̂ӂ邢���ā[����������
        while (generatedStageList.Count > perInstantiate + 2)
        {
            DestroyOldestStage();
        }

        currentChipIndex = toChipIndex;
    }

    GameObject GenerateStage(int chipIndex) //�w��̃C���f�b�N�X�����ɃX�e�[�W�I�u�W�F�N�g�̃����_������
    {
        int nextStageChip = Random.Range(0, stageChips.Length); 

        GameObject stageObject = Instantiate(
            stageChips[nextStageChip],
            new Vector3(0, 0, chipIndex * StageChipSize),
            Quaternion.identity
        );

        return stageObject;
    }

    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
