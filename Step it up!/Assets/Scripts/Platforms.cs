using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platforms : MonoBehaviour
{
    [SerializeField]
    private GameObject startPlatform, endPlatform, platformPrefab1, platformPrefab2;

    private float blockWidth = 2f, blockHeight = 1f;

    [SerializeField]
    private int amountToSpawn = 25;
    private int beginAmount = 0;

    private Vector3 lastPos;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();

    [SerializeField]
    private GameObject playerPerfab;

    void Awake() {
        InstantiateLevel();
        PlayerPrefs.SetInt("skorlvl", 0);
    }

    void InstantiateLevel() {
        for (int i = beginAmount; i < amountToSpawn; i++) {
            GameObject newPlatform;

            if(i == 0) {
                newPlatform = Instantiate(startPlatform);
            } else if (i == amountToSpawn - 1) { //last loop iteration
                newPlatform = Instantiate(endPlatform);
                newPlatform.tag = "EndPlatform";
            } else {
                newPlatform = Instantiate(platformPrefab1);
            }
            
            newPlatform.transform.parent = transform;

            spawnedPlatforms.Add(newPlatform);

            if(i == 0) {
                lastPos = newPlatform.transform.position;
                //instantiate player
                Vector3 temp = lastPos;
                temp.y += 0.1f;
                Instantiate(playerPerfab, temp, Quaternion.identity);
                continue;
            }

            int left = Random.Range(0,2);

            if(left == 0) {
                newPlatform.transform.position = new Vector3(lastPos.x - blockWidth, lastPos.y + blockHeight, lastPos.z);
            } else {
                newPlatform.transform.position = new Vector3(lastPos.x, lastPos.y + blockHeight, lastPos.z + blockWidth);
            }

            lastPos = newPlatform.transform.position;

            //fancy ass animation
            if (i < 25) {
                float endPos = newPlatform.transform.position.y;
                newPlatform.transform.position = new Vector3(newPlatform.transform.position.x, newPlatform.transform.position.y - blockHeight * 3f, newPlatform.transform.position.z);

                newPlatform.transform.DOLocalMoveY(endPos, 0.3f).SetDelay(i * 0.1f);
            }
        }
    }
}
