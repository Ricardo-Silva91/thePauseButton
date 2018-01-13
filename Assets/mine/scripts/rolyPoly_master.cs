using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rolyPoly_master : MonoBehaviour
{

    public GameObject topCam;
    public GameObject myCam;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    public Vector3 currentPos;
    public Quaternion currentRotation;

    public Vector3 topPosition;
    public Quaternion topRotation;

    public int currentState;
    public float step;
    public float blastStep;
    public float rotationStep;

    public GameObject blastTarget;

    public gameMaster superMaster;

    // Use this for initialization
    void Start()
    {
        superMaster = this.GetComponent<gameMaster>();
        topCam = GameObject.Find("top_camera");
        myCam = GameObject.Find("Player");

        topPosition = topCam.transform.position;
        topRotation = new Quaternion(90f, 0, 0, 0);
        controller = myCam.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

        topCam.GetComponent<Camera>().enabled = false;
        myCam.transform.Find("FirstPersonCharacter").GetComponent<Camera>().enabled = true;

        currentState = 1;
        
    }

    void switchCam()
    {

        if (currentState != 89)
        {
            currentPos = myCam.transform.position;
            currentRotation = myCam.transform.rotation;
            controller.enabled = false;
            myCam.GetComponent<Detection>().enabled = false;
            topCam.GetComponent<Camera>().enabled = true;
            myCam.transform.Find("FirstPersonCharacter").GetComponent<Camera>().enabled = false;
            currentState = 88;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            currentState = 99;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (superMaster.gamePaused == false)
        {

            switch (currentState)
            {
                case 1:

                    topCam.transform.position = myCam.transform.position;//new Vector3(myCam.transform.position.x, topCam.transform.position.y, myCam.transform.position.z);
                    topCam.transform.rotation = myCam.transform.rotation;

                    topPosition = new Vector3(myCam.transform.position.x, topPosition.y, myCam.transform.position.z);
                    topRotation = new Quaternion(topRotation.x, myCam.transform.rotation.y, myCam.transform.rotation.z, myCam.transform.rotation.w);
                    Cursor.visible = false;

                    break;
                case 88: //going  to sky

                    if (topCam.transform.position != topPosition)
                    {
                        topCam.transform.position = Vector3.MoveTowards(topCam.transform.position, topPosition, step);
                    }

                    if (topCam.transform.eulerAngles.x != topRotation.x)//(! (Mathf.Abs(angle)< 1e-3f))//(topCam.transform.rotation != topRotation)
                    {
                        topCam.transform.Rotate(Vector3.right * rotationStep);
                    }

                    if (topCam.transform.position == topPosition && Mathf.Abs(topCam.transform.eulerAngles.x - 90) < 0.1)
                    {
                        currentState = 89;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                    break;
                case 89:
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit hit;
                        Ray ray = topCam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit, 1000.0f))
                        {
                            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

                            if (hit.transform.gameObject.tag == "entry")
                            {
                                blastTarget = hit.transform.gameObject;
                                currentState = 90;
                            }
                        }
                    }
                    break;
                case 90:
                    if (topCam.transform.position != currentPos)
                    {
                        topCam.transform.position = Vector3.MoveTowards(topCam.transform.position, currentPos, step);
                    }

                    if (Mathf.Abs(topCam.transform.eulerAngles.x) > 10)
                    {
                        topCam.transform.Rotate(-Vector3.right * rotationStep);
                    }

                    if (topCam.transform.position == currentPos && Mathf.Abs(topCam.transform.eulerAngles.x) < 10)
                    {
                        topCam.GetComponent<Camera>().enabled = false;
                        myCam.transform.Find("FirstPersonCharacter").GetComponent<Camera>().enabled = true;
                        currentState = 91;
                    }
                    break;
                case 91:
                    if (myCam.transform.position != blastTarget.transform.position)
                    {
                        myCam.transform.position = Vector3.MoveTowards(myCam.transform.position, blastTarget.transform.position, blastStep);
                    }

                    if (myCam.transform.position == blastTarget.transform.position)
                    {
                        controller.enabled = true;
                        myCam.GetComponent<Detection>().enabled = true;
                        currentState = 1;
                    }
                    break;
                case 99: //going  to ground
                    if (topCam.transform.position != currentPos)
                    {
                        topCam.transform.position = Vector3.MoveTowards(topCam.transform.position, currentPos, step);
                    }

                    if (Mathf.Abs(topCam.transform.eulerAngles.x) > 10)
                    {
                        topCam.transform.Rotate(-Vector3.right * rotationStep);
                    }

                    if (topCam.transform.position == currentPos && Mathf.Abs(topCam.transform.eulerAngles.x) < 10)
                    {
                        topCam.GetComponent<Camera>().enabled = false;
                        myCam.transform.Find("FirstPersonCharacter").GetComponent<Camera>().enabled = true;
                        controller.enabled = true;
                        myCam.GetComponent<Detection>().enabled = true;
                        currentState = 1;
                    }
                    break;
                default:
                    break;
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                switchCam();
            }
        }
        else
        {
            controller.enabled = false;
            Cursor.visible = true;
        }
    }
}
