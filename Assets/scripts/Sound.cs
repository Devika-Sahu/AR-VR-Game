using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    private AudioSource audioSource;
    public void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad (gameObject);
        }
        else{
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }   
}
