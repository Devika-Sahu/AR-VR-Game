
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Bgmusic : MonoBehaviour
{
    private bool isPaused = false;
    public AudioSource backgroundMusic;
    public AudioClip pauseSound;
    public GameObject pauseIcon;

    public void Awake(){
        pauseIcon.SetActive(false);
        // backgroundMusic.enabled = false;

    }

    private void Start()
    {
        
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.enabled = true;
        pauseIcon.SetActive(false);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
            
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            
            Time.timeScale = 0f;
            pauseIcon.SetActive(true);


            
            if (backgroundMusic.isPlaying)
            {
                backgroundMusic.Pause();
            }

           
            if (pauseSound != null)
            {
                AudioSource.PlayClipAtPoint(pauseSound, Camera.main.transform.position);
            }
        }
        else
        {
            
            Time.timeScale = 1f;
            pauseIcon.SetActive(false);

            
            if (!backgroundMusic.isPlaying)
            {
                backgroundMusic.Play();
            }
        }
    }

    public void StopBackgroundMusic()
    {
      
        backgroundMusic.enabled = false;

       
        backgroundMusic.Stop();
    }
}

