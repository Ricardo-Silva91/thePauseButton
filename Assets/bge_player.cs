using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bge_player : MonoBehaviour {

    private AudioSource m_AudioSource;

    // Use this for initialization
    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
    }
	
    public void playSound(AudioClip sound)
    {
        m_AudioSource.clip = sound;
        m_AudioSource.Play();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
