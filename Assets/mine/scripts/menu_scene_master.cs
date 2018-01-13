using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_scene_master : MonoBehaviour {

    public void GoToGame()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        //Debug.Log(nextScene + " " + SceneManager.sceneCount);
        
        SceneManager.LoadScene(nextScene);
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
