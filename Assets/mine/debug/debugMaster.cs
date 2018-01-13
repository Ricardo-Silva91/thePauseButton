using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugMaster : MonoBehaviour {

    public AudioClip[] tracks;
    public GameObject[] record_players;
    public List<int> usedTracks;
    public GameObject player;
    public GameObject pause_menu;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerScript;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("player");
        pause_menu = GameObject.Find("Pause_menu");
        playerScript = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        pause_menu.SetActive(false);
        tracks= Resources.LoadAll<AudioClip>("sounds");

        record_players = GameObject.FindGameObjectsWithTag("record_player");

        foreach(GameObject record in record_players)
        {
            int trackToPlay = Random.Range(0, tracks.Length - 1);
            while (usedTracks.Contains(trackToPlay) == true) { trackToPlay = Random.Range(0, tracks.Length - 1); }

            usedTracks.Add(trackToPlay);

            record.GetComponent<AudioSource>().clip = tracks[trackToPlay];
        }


    }

    void ToggleMenu()
    {
        playerScript.enabled = !playerScript.enabled;
        pause_menu.SetActive(!pause_menu.active);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
		
	}
}
