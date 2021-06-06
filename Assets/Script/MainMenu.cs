using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;
    [SerializeField]private AudioClip menuSoundClip, btnSoundClip;
    [SerializeField]private float menuSoundVol, btnSoundVol;

    private AudioSource menuSound, btnSound;
    private float highScore;

    void Start(){
        highScore = PlayerPrefs.GetFloat("highScore");
        highScoreText.text = highScore.ToString();

        menuSound = AddAudio(false, false, menuSoundVol);
        menuSound.clip = menuSoundClip;
        menuSound.Play();

        btnSound = AddAudio(false, false, btnSoundVol);
        btnSound.clip = btnSoundClip;
    }


    public void PlayGame(){ 
        btnSound.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        btnSound.Play();
        Debug.Log("Keluar");
        Application.Quit();
        menuSound.Pause();
    }

    public AudioSource AddAudio(bool loop, bool playAwake, float vol) {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

}
