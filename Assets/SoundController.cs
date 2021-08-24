using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource soundToPlay;
    public AudioClip Paper;
    public AudioClip Thud;
    public AudioClip Crash;
    public AudioClip Surprise;
    public AudioClip Band;
    public AudioClip Piano;
    public AudioClip Exhaust;
    public AudioClip Shatter;
    void Start() {
        soundToPlay.volume = 0.5f;
        soundToPlay.loop = false;
    }

    // Update is called once per frame
    public void playSound(string sound) {
        soundToPlay.loop = false;
        if (sound.Contains("Paper")) {
            soundToPlay.clip = Paper;
        }
        else if (sound.Contains("Thud")) {
            soundToPlay.clip = Thud;
        }
        else if (sound.Contains("Crash")) {
            soundToPlay.clip = Crash;
        }
        else if (sound.Contains("Surprise")) {
            soundToPlay.clip = Surprise;
        } 
        else if (sound.Contains("Band")) {
            soundToPlay.loop = true;
            soundToPlay.clip = Band;
        }
        else if (sound.Contains("Piano")) {
            soundToPlay.loop = true;
            soundToPlay.clip = Piano;
        }
        else if (sound.Contains("Exhaust")) {
            soundToPlay.clip = Exhaust;
        }
        else if (sound.Contains("Shatter")) {
            soundToPlay.clip = Shatter;
        }
        soundToPlay.Play();
    }
}
