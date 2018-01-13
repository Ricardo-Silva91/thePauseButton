using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class god_world_maker : MonoBehaviour {

    public int numberOfStars;
    public GameObject star_template;
    public GameObject stars;
    public float minimumDistance;

    public int matrixNum;
    public bool[,] world;
    public bool world_done;

    void populateWorld()
    {
        world = new bool[matrixNum, matrixNum];
        world[matrixNum / 2, matrixNum / 2] = true;

        for (int i = 0; i < numberOfStars; i++)
        {
            int pos_x = Random.Range(0, matrixNum - 1);
            int pos_y = Random.Range(0, matrixNum - 1);
            while (world[pos_x, pos_y] == true)
            {
                pos_x = Random.Range(0, matrixNum - 1);
                pos_y = Random.Range(0, matrixNum - 1);
            }
            //Debug.Log("good");
            world[pos_x, pos_y] = true;
            Vector3 pos = new Vector3((pos_x - (matrixNum / 2)) * minimumDistance, 0, (pos_y - (matrixNum / 2)) * minimumDistance);
            //Debug.Log((pos_x - (matrixNum / 2)) * minimumDistance);
            GameObject.Instantiate(star_template, pos, new Quaternion(0, 0,0,0),stars.transform);
        }
    }

	// Use this for initialization
	void Start () {

        world_done = false;
        stars = GameObject.Find("Stars");
        populateWorld();
        world_done = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
