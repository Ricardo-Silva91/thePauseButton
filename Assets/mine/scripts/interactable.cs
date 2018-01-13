using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour {

    public bool workFlag = true;
    public string messageToShow = "toggle";
    public bool touched = false;

	// Use this for initialization
	void Start () {
		
	}

    public void touch()
    {
        touched = !touched;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
