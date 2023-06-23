using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SEManager : Singleton<SEManager>
{
    AudioSource _audioSource;


    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public List<AudioClip> SE = new List<AudioClip>(6);

    public void PieceSet(){
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[0]);
    } 

    public void Click(){
        _audioSource.volume = .4f;
        _audioSource.PlayOneShot(SE[1]);
    } 

    public void Fire(){
        _audioSource.volume = 1f;
        _audioSource.PlayOneShot(SE[2]);
    } 
}