using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource coinSound, buttonSound, jumpSound;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void CoinSound() {
        coinSound.Play();
    }

    public void ButtonSound() {
        buttonSound.Play();
    }
    
    public void JumpSound(){
        jumpSound.Play();
    }
}
