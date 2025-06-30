using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerGenerator : MonoBehaviour
{

    const float Lanewwidth = 3.0f; //ƒŒ[ƒ“‚Ì•

    public GameObject dangerPrefab; //¶¬‚³‚ê‚éŠüŒ Ò

    public bool IsRandam;
    public float intervalTime = 10.0f;
    public float minIntervalTime = 10.0f;
    public float maxIntervalTime = 20.0f;

    float timer; //
    float posX;

    public GameObject DangerPanel;


    // Start is called before the first frame update
    void Start()
    {
        timer = intervalTime;
        if (IsRandam)
        {
            timer = Random.Range(minIntervalTime, maxIntervalTime + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState != GameState.playing) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DangerCreated();
            timer = intervalTime;
            if (!IsRandam)
            {
                timer = Random.Range(minIntervalTime, maxIntervalTime + 1);
            }

        }

        void DangerCreated()
        {
            int rand = Random.Range(-1, 2);
            posX = rand * Lanewwidth;

            Instantiate(dangerPrefab.new Vector3(posX, 1,z), dangerPrefab.transform.rotation);

            StartCoroutine(AlertText());
        }

        IEnumerator AlertText()
        {
            float duration = 3.0f;
            float blinkInterval = 0.05f;
            float blinkTime = 0f;

            while (blinkTime < duration)
            {
                DangerPanel.SetActive(!DangerPanel.activeSelf);
                yield return new WaitForSeconds(0.05f);
                blinkTime += blinkInterval;



            }

            DangerPanel.SetActive(false);
        } 

    }

}

