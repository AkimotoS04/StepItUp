using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    //private int score;
    [SerializeField]
    private Text scoreText;

    private float seconds = 0.0f;
    private float minutes = 0.0f;
    private float hours = 0.0f;
    
    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void TimerUp() {
        seconds += Time.deltaTime;
        if(seconds > 60){
            minutes += 1;
            seconds = 0;
        }
        if(minutes > 60){
            hours += 1;
            minutes = 0;
        }
        scoreText.text = minutes.ToString("f0") + ":" + seconds.ToString("f0");
    }

    // public void IncrementScore() {
    //     score++;
    //     //scoreText.text = "$ " + score;
    // }

    public void Finalize() {
        PlayerPrefs.SetFloat("detik", seconds);
        PlayerPrefs.SetFloat("menit", minutes);
        PlayerPrefs.SetFloat("jam", hours);
        PlayerPrefs.SetInt("win", 0);
    }

    public void FinalizeDed() {
        PlayerPrefs.SetFloat("detikD", seconds);
        PlayerPrefs.SetFloat("menitD", minutes);
        PlayerPrefs.SetFloat("jamD", hours);
        PlayerPrefs.SetInt("win", 1);
    }
}