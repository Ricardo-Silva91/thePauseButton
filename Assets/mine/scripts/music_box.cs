using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_box : MonoBehaviour {

    public GameObject recordPlayer;
    public GameObject song;
    public interactable interactableScript;
    public bool playing = false;


    // Use this for initialization
    void Start () {

        recordPlayer = this.transform.Find("record_player").gameObject;
        song = recordPlayer.transform.Find("song").gameObject;
        //song = this.transform.Find("song").gameObject;
        interactableScript = this.GetComponent<interactable>();
        interactableScript.messageToShow = "play song.";

    }
	
    public void playSong()
    {
        if(playing == false)
        {
            song.GetComponent<AudioSource>().Play();
            playing = true;
        }
    }

    public void toggleSong()
    {
        if (playing == false)
        {
            recordPlayer.GetComponent<RecordPlayer>().recordPlayerActive = true;
            song.GetComponent<AudioSource>().Play();
            interactableScript.messageToShow = "stop playing song.";
        }
        else
        {
            recordPlayer.GetComponent<RecordPlayer>().recordPlayerActive = false;
            song.GetComponent<AudioSource>().Stop();
            interactableScript.messageToShow = "play song.";
        }
        playing = !playing;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision");
        //toggleSong();
    }

    // Update is called once per frame
    void Update () {

        if(interactableScript.touched == true)
        {
            toggleSong();
            interactableScript.touched = false;
        }
		
	}
}
