using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour {
    
    private Rigidbody rb;
    private bool died;
    private CameraFoll camera;
    private IEnumerator coroutine;

    void Start() {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main.GetComponent<CameraFoll>();
    }

    void Update()
    {
        if (!died) {
            if(rb.velocity.sqrMagnitude > 60) {
                died = true;
                camera.CamFollow = false;
                coroutine = WaitAndPrint(0.5f);
                StartCoroutine(coroutine);
                GameplayController.instance.FinalizeDed();
            }
            GameplayController.instance.TimerUp();
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(3);
            print("ChangingScene");
        }
    }

    void OnTriggerEnter(Collider target) {
        // if(target.tag == "Coin") {
        //     target.gameObject.SetActive(false);
        //     GameplayController.instance.IncrementScore();
        //     SoundManager.instance.CoinSound();
        // }
        if(target.tag == "Spike") {
            camera.CamFollow = false;
            gameObject.SetActive(false);
            SceneManager.LoadScene(3);
            GameplayController.instance.FinalizeDed();
        }
    }

    void OnCollisionEnter(Collision target) {
        if(target.gameObject.tag == "EndPlatform") {
            SceneManager.LoadScene(4);
            GameplayController.instance.Finalize();
        }
    }
}
