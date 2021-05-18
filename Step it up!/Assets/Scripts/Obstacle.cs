using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour {
    
    [SerializeField]
    private Transform spike;

    [SerializeField]
    public GameObject coin;

    private bool fallDown;

    void Start() {
        ActivatePlatform();
    }

    void ActivateSpike() {
        spike.gameObject.SetActive(true);
        spike.DOLocalMoveY(0.1f, 1.3f).
            SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(3f, 5f));
    }

    // void AddCoin() {
    //     GameObject c = Instantiate(coin);
    //     c.transform.position = transform.position;
    //     c.transform.SetParent(transform);
    //     c.transform.localScale = new Vector3(0.3f, 0.3f, 0.15f);
    //     c.transform.DOLocalMoveY(1f, 1.3f);
    // }

    void ActivatePlatform() {
        int chance = Random.Range(0,100);

        if(chance > 75) {
            int type = Random.Range(0,3);
            if (type == 0) {
                ActivateSpike();
            } else if (type == 1) {
                fallDown = true;
            } else if (type == 2) {
                fallDown = true;
            } else {
                ActivateSpike();
            }
        }
    }

    void InvokeFalling() {
        gameObject.AddComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision target) {
        if (target.gameObject.tag == "Player"){
            if(fallDown) {
                fallDown = false;
                Invoke("InvokeFalling", 2f);
            }
        }
    }
}
