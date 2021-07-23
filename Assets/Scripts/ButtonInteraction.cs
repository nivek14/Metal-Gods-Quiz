using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour{

    private AudioSource audioSource;

    private void Awake() {
        Init();
    }

    private void Init(){
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip){
        audioSource.PlayOneShot(audioClip);
    }

}
