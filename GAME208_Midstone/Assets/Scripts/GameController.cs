using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Material overMat;
    public Material underMat;
    public bool overWorld = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Transformable");
        GameObject[] overGameObjects = GameObject.FindGameObjectsWithTag("Overworld");
        GameObject[] underGameObjects = GameObject.FindGameObjectsWithTag("Underworld");

        //May be needed
        //int gameObjectCount = gameObjects.Length;

        if (Input.GetKeyDown("space"))
        {
            if (overWorld == true)
            {
                overWorld = false;
            }
            else
            {
                overWorld = true;
            }

            //For objects that can appear in both worlds
            foreach (var objs in gameObjects)
            {
                if (overWorld == true)
                {
                    objs.GetComponent<MeshRenderer>().material = overMat;
                }

                if (overWorld == false)
                {
                    objs.GetComponent<MeshRenderer>().material = underMat;
                }
                
            }

        }
    }
}
