using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    public AudioClip[] audioClipList;
    public Dictionary<string, AudioClip> audioList = new Dictionary<string, AudioClip>();
    private AudioSource _src;
    

    private void Awake()
    {
        _src = this.gameObject.GetComponent<AudioSource>();
        for (int i = 0; i < audioClipList.Length; i++) 
        {
            audioList.Add(audioClipList[i].name, audioClipList[i]);
        }
       
    }

    public void PlayAudioOneshot(AudioClip audio) 
    {
        _src.PlayOneShot(audio, 1);
    }


}
