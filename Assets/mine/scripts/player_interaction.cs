using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_interaction : MonoBehaviour {

    public float distanceToSee;
    public Text intText;
    public GameObject myLight;
    RaycastHit whatIHit;
    string whatIHit_name;

    public bool reachingSomethingJuicy = false;
    public gameMaster masters;

	// Use this for initialization
	void Start () {

        myLight = GameObject.Find("myLight");
        masters = GameObject.Find("GameMaster").GetComponent<gameMaster>();
        intText = GameObject.Find("Int_text").GetComponent<Text>();
		
	}

    void toggleLight()
    {
        myLight.GetComponent<Light>().enabled = !myLight.GetComponent<Light>().enabled;
    }
	
	// Update is called once per frame
	void Update () {

        if(masters.gamePaused == false)
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

            if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
            {
                //Debug.Log("touched " + whatIHit.collider.gameObject.name);
                if (whatIHit.collider.gameObject.GetComponent<interactable>() != null)
                {
                    intText.text = whatIHit.collider.gameObject.GetComponent<interactable>().messageToShow;
                    reachingSomethingJuicy = true;
                }
                else
                {
                    intText.text = "";
                    reachingSomethingJuicy = false;
                }
            }
            else
            {
                intText.text = "";
                reachingSomethingJuicy = false;
            }


            if (reachingSomethingJuicy == true)
            {
                //Debug.Log("touch " + whatIHit.collider.gameObject.name);
                if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
                {
                    whatIHit.collider.gameObject.GetComponent<interactable>().touch();
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                toggleLight();
            }
        }
    }
}
