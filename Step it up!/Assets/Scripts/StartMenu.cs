using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    private Animator animator;
    public GameObject model;
    public float minTime = 3;
    public float maxTime = 1;

    private float time;
    private float changeAnim;
    private int pilihan;
    private IEnumerator coroutine;

    private float det, min, jam;

    [SerializeField]
    private Text scoreText;

    void Start() {
        det = PlayerPrefs.GetFloat("finaldetik");
        min = PlayerPrefs.GetFloat("finalmenit");
        scoreText.text = "Best Time : " + min.ToString("f0") + ":" + det.ToString("f0");

        animator = model.GetComponent<Animator>();
        SetRandomTime();
    }
    
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SetRandomTime() {
        changeAnim = Random.Range(minTime, maxTime);
    }

    public void StartingTheGame() {
        SoundManager.instance.ButtonSound();
        coroutine = WaitAndPrint(0.5f);
        StartCoroutine(coroutine);
        SceneManager.LoadScene(1);
    }

    public void ResetTime() {
        PlayerPrefs.SetFloat("finaldetik", 0);
        PlayerPrefs.SetFloat("finalmenit", 0);
        det = PlayerPrefs.GetFloat("finaldetik");
        min = PlayerPrefs.GetFloat("finalmenit");
        scoreText.text = "Best Time : " + min.ToString("f0") + ":" + det.ToString("f0");
    }

    public void QuitGame() {
        SoundManager.instance.ButtonSound();
        coroutine = WaitAndPrint(0.5f);
        StartCoroutine(coroutine);
        Application.Quit();
    }

    void FixedUpdate() {
        time += Time.deltaTime;

        if(time >= changeAnim) {
            ChangeAnimation();
            SetRandomTime();
        }
    }

    void ChangeAnimation() {
        time = 0;
        pilihan = Random.Range(0,2);

        if (pilihan == 0) {
            animator.SetBool("runs", true);
            animator.SetBool("idle", false);
        } else if (pilihan == 1) {
            animator.SetBool("runs", false);
            animator.SetBool("idle", true);
        } else {
            animator.SetBool("runs", false);
            animator.SetBool("idle", false);
        }
    }
}
