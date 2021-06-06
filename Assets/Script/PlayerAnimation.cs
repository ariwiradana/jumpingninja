using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]private Text scoreText, nyawaText;
    [SerializeField]private Transform spawnPoint;
    [SerializeField]private GameObject karakter;
    [SerializeField]private AudioClip koinSoundClip, shurikenSoundClip, jumpSoundClip, backsoundClip, jatuhSoundClip, nyawaSoundClip;
    [SerializeField]private float score, nyawa, koinSoundVol, shurikenSoundVol, jumpSoundVol, backsoundVol, jatuhSoundVol, nyawaSoundVol;

    private AudioSource koinSound, shurikenSound, jumpSound, backsound, jatuhSound, nyawaSound;

    void Start()
    {
        Time.timeScale = 1;

        backsound = AddAudio(true, true, backsoundVol);
        backsound.clip = backsoundClip;
        backsound.Play();

        nyawaSound = AddAudio(false, false, nyawaSoundVol);
        nyawaSound.clip = nyawaSoundClip;
        
        koinSound = AddAudio(false, false, koinSoundVol);
        koinSound.clip = koinSoundClip;

        jatuhSound = AddAudio(false, false, jatuhSoundVol);
        jatuhSound.clip = jatuhSoundClip;

        shurikenSound = AddAudio(false, false, shurikenSoundVol);
        shurikenSound.clip = shurikenSoundClip;

        jumpSound = AddAudio(false, false, jumpSoundVol);
        jumpSound.clip = jumpSoundClip;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            jumpSound.Play();
        }
    }

    public AudioSource AddAudio(bool loop, bool playAwake, float vol) {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Koin"){
            koinSound.Play();
            score += 1;
            scoreText.text = score.ToString();
            Destroy (collision.gameObject);
        } else if (collision.tag == "Shuriken"){
            shurikenSound.Play();
            Destroy (collision.gameObject);
            nyawa -= 1;
            nyawaText.text = "x" + nyawa.ToString();
            if (nyawa == 0){
                PlayerPrefs.SetFloat("gameScore", score);
                if (score > PlayerPrefs.GetFloat("highScore")){
                    PlayerPrefs.SetFloat("highScore", score);
                }
                backsound.Pause();
                Time.timeScale = 0;
                SceneManager.LoadScene(2);
            }
        } else if (collision.tag == "Kill"){
            nyawa -= 1;
            nyawaText.text = "x" + nyawa.ToString();
            karakter.transform.position = spawnPoint.position;
            jatuhSound.Play();
            if (nyawa == 0){
                PlayerPrefs.SetFloat("gameScore", score);
                if (score > PlayerPrefs.GetFloat("highScore")){
                    PlayerPrefs.SetFloat("highScore", score);
                }
                backsound.Pause();
                Time.timeScale = 0;
                SceneManager.LoadScene(2);
            }
        } else if (collision.tag == "Nyawa"){
            nyawaSound.Play();
            nyawa += 1;
            nyawaText.text = "x" + nyawa.ToString();
            Destroy (collision.gameObject);
        }
    }

    public void OnBecameInvisible() {
        nyawa -= 1;
        nyawaText.text = "x" + nyawa.ToString();
        if (nyawa == 0){
            PlayerPrefs.SetFloat("gameScore", score);
            if (score > PlayerPrefs.GetFloat("highScore")){
                PlayerPrefs.SetFloat("highScore", score);
            }
            backsound.Pause();
            Time.timeScale = 0;
            SceneManager.LoadScene(2);
        }
    }
}
