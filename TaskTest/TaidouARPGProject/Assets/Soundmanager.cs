using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soundmanager : MonoBehaviour {
    public static Soundmanager _instance;
    public AudioClip[] audioArray;
    public Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();
    public AudioSource audioSocure;
    public bool isQuiet;


    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
	
        foreach(AudioClip audio in audioArray)
        {
            audioDict.Add(audio.name, audio); 
        }
	}
	
    public void  PlayerSound(string audioName)
    {
        if (isQuiet) return;
        AudioClip ac;
        if(audioDict.TryGetValue(audioName,out ac))
        {

            AudioSource.PlayClipAtPoint(ac, Vector3.zero);
            this.audioSocure.PlayOneShot(ac);
        }
    }

    public void PlayerSound(string audioName, AudioSource audioSource)
    {
        if (isQuiet) return;

        AudioClip ac;
        if (audioDict.TryGetValue(audioName, out ac))
        {
          audioSocure.PlayOneShot(ac);
        }
    }
}
