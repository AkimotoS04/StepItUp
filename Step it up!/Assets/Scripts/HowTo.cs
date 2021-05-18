using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowTo : MonoBehaviour
{
    private IEnumerator coroutine;
    
    void Start()
    {
        
    }

    public void StartGame() {
        SoundManager.instance.ButtonSound();
        coroutine = WaitAndPrint(0.5f);
        StartCoroutine(coroutine);
        SceneManager.LoadScene(2);
    }

    public void MenuGame() {
        SoundManager.instance.ButtonSound();
        coroutine = WaitAndPrint(0.5f);
        StartCoroutine(coroutine);
        SceneManager.LoadScene(0);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
}
