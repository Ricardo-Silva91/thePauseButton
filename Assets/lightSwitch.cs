using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour {


    public interactable interactableScript;
    public bool lightsOn = false;
    public Light myLight;
    public Color lightColor;
    public AudioClip switchSound;
    public bge_player soundPlayer;

    // Use this for initialization
    void Start () {

        interactableScript = this.GetComponent<interactable>();
        interactableScript.messageToShow = "turn light on.";
        myLight = this.transform.parent.transform.Find("Spotlight").GetComponent<Light>();
        myLight.color = lightColor;

        soundPlayer = GameObject.Find("Player").GetComponent<bge_player>();

    }

    public void toggleLight()
    {
        if (lightsOn == false)
        {
            interactableScript.messageToShow = "turn light off.";
        }
        else
        {
            interactableScript.messageToShow = "turn light on.";
        }
        myLight.enabled = !myLight.enabled;
        lightsOn = !lightsOn;
        if (soundPlayer != null)
        {
            soundPlayer.playSound(switchSound);
        }
    }

    // Update is called once per frame
    void Update () {
        if (interactableScript.touched == true)
        {
            toggleLight();
            interactableScript.touched = false;
        }
    }
}
