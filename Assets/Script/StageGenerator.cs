using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 50; //せいせいしたちっぷをはいちするにあたっておおきさ

    int currentChipIndex; //現在のどのちっぷみてるか

    Transform player; //Player

    public GameObject[] stageChips; //生成するオブジェクトのかくのう

    public int startChipIndex = 0;　//ちっぷの番号
    public int perInstantiate = 5;　//よぶんにつきっておくかず
   
    
    //現在制裁したオブジェクトのかんりよう
    public List<GameObject> generatedStageList = new List<GameObject>();

    void Start()
    {
        //トランスフォーむのほそく
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        currentChipIndex = startChipIndex - 1;
        UpdateStage(perInstantiate);
    }

    void Update()
    {
 
        int charaPositionIndex = (int)(player.position.z / StageChipSize);

        //次のステージにはいっあらstageのこうしんしょりをおこうんまう
        if (charaPositionIndex + perInstantiate > currentChipIndex)
        {
            UpdateStage(charaPositionIndex + perInstantiate);
        }
    }

    void UpdateStage(int toChipIndex)　//指定のindexまでの酢てーずｓちっぷすうぃ生成して管理
    {
        if (toChipIndex < currentChipIndex) return;

        //指定のステージちっぷのさくせい
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i); //生成した酢てーずちっぷを管理しるすと追加 
            generatedStageList.Add(stageObject);
        }
        //ステー上のふるいすてーじさくじょ
        while (generatedStageList.Count > perInstantiate + 2)
        {
            DestroyOldestStage();
        }

        currentChipIndex = toChipIndex;
    }

    GameObject GenerateStage(int chipIndex) //指定のインデックスいちにステージオブジェクトのランダム製紙
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
