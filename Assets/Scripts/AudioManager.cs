using UnityEngine;


public class AudioManager : MonoBehaviour{
    public static AudioManager instance;
    [Header("Audio Sources")]
    public AudioSource sfxSource; 
    public AudioSource ambientSource; 

    [Header ("Audio Clips")]
    public AudioClip ambientClip;
    public AudioClip shootClip;
    public AudioClip breakClip;
    public AudioClip footStepsClip; 

    public void Awake(){
        if(instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
        
    }

    void Start(){
        playAmbientSound();
    }

    public void playAmbientSound(){
        if(ambientClip != null && ambientSource != null){
            ambientSource.clip = ambientClip;
            ambientSource.loop = true;
            ambientSource.Play();
        }
    }

    public void playSound(AudioClip clip){
        if(clip != null){
            sfxSource.PlayOneShot(clip);
        }
    }

}