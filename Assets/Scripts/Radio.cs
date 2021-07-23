using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour{

    [SerializeField] private List<AudioClip> songs = new List<AudioClip>();
    private AudioSource audioSource;
    private int randomIndex;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    void Start(){
        PlaySong();
    }

    void Update(){
        SongEnd();
    }

    private void SongEnd(){
        if (!audioSource.isPlaying){
            PlaySong();
        }
    }

    private void PlaySong(){
        randomIndex = Random.Range(0, songs.Count);
        audioSource.clip = songs[randomIndex];
        audioSource.Play();
    }

}
