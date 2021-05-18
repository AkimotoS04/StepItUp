using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private IEnumerator coroutine;
    private int stat;
    private float det, min, jam, detD, minD, jamD;

    [SerializeField]
    private Text scoreText;

    void Awake() {
        stat = PlayerPrefs.GetInt("win");
        detD = PlayerPrefs.GetFloat("detikD");
        minD = PlayerPrefs.GetFloat("menitD");

        det = PlayerPrefs.GetFloat("detik");
        min = PlayerPrefs.GetFloat("menit");

        if(stat == 1) {
            scoreText.text = "Time : " + minD.ToString("f0") + ":" + detD.ToString("f0");
        } else if (stat == 0) {
            scoreText.text = "New Time : " + ":" + min.ToString("f0") + ":" + det.ToString("f0");
            if (PlayerPrefs.GetFloat("finalmenit") <= min || PlayerPrefs.GetFloat("finalmenit") == 0) {
                if (PlayerPrefs.GetFloat("finaldetik") <= det || PlayerPrefs.GetFloat("finaldetik") == 0) {
                    PlayerPrefs.SetFloat("finalmenit", min);
                    PlayerPrefs.SetFloat("finaldetik", det);
                }
            }
        }
    }

    public void StartGame() {
        SoundManager.instance.ButtonSound();
        coroutine = WaitAndPrint(0.5f);
        StartCoroutine(coroutine);
        SceneManager.LoadScene(2);
    }
    
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void Menu() {
        SceneManager.LoadScene(0);
        SoundManager.instance.ButtonSound();
        coroutine = WaitAndPrint(0.5f);
        StartCoroutine(coroutine);
    }
}
