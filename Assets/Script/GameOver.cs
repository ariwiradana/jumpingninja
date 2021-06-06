using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text gameOverScore;
    [SerializeField]private AudioClip gameOverClip, btnSoundClip;
    [SerializeField]private float gameOverVol, btnSoundVol;

    private AudioSource gameOver, btnSound;
    private float gameScore;

    void Start()
    {
        gameScore  = PlayerPrefs.GetFloat("gameScore");
        gameOverScore.text = gameScore.ToString();

        gameOver = AddAudio(false, false, gameOverVol);
        gameOver.clip = gameOverClip;
        gameOver.Play();

        btnSound = AddAudio(false, false, btnSoundVol);
        btnSound.clip = btnSoundClip;

    }

    public void backToMenu(){
        btnSound.Play();
        SceneManager.LoadScene(0);
    }

    public AudioSource AddAudio(bool loop, bool playAwake, float vol) {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

}
