using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Material overMatGround;
    public Material underMatGround;
    public Material overMatWall;
    public Material underMatWall;

    public bool overWorld = true;

    //public GameObject[] gameObjects;
    //public GameObject[] overGameObjects;
    //public GameObject[] underGameObjects;

    public List<GameObject> gameObjects = new List<GameObject>();
    public List<GameObject> overGameObjects = new List<GameObject>();
    public List<GameObject> underGameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //gameObjects = GameObject.FindGameObjectsWithTag("Transformable");
        //overGameObjects = GameObject.FindGameObjectsWithTag("Overworld");
        //underGameObjects = GameObject.FindGameObjectsWithTag("Underworld");

        foreach (GameObject objects in GameObject.FindGameObjectsWithTag("Transformable"))
        {
            gameObjects.Add(objects);
        }
        foreach (GameObject objects in GameObject.FindGameObjectsWithTag("Overworld"))
        {
            overGameObjects.Add(objects);
        }
        foreach (GameObject objects in GameObject.FindGameObjectsWithTag("Underworld"))
        {
            underGameObjects.Add(objects);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //May be needed
        //int gameObjectCount = gameObjects.Length;

        //For objects that can appear in both worlds
        foreach (GameObject objs in gameObjects)
        //foreach (var objs in gameObjects)
        {
            if (overWorld == true)
            {
                if (objs.gameObject.layer == LayerMask.NameToLayer("Wall"))
                {
                    objs.GetComponent<MeshRenderer>().material = overMatWall;
                }
                if (objs.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    objs.GetComponent<MeshRenderer>().material = overMatGround;
                }

            }

            if (overWorld == false)
            {
                if (objs.gameObject.layer == LayerMask.NameToLayer("Wall"))
                {
                    objs.GetComponent<MeshRenderer>().material = underMatWall;
                }
                if (objs.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    objs.GetComponent<MeshRenderer>().material = underMatGround;
                }
            }

        }

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
        }

    }

    void FixedUpdate()
    {
        foreach (GameObject overObjs in overGameObjects)
        {
            lock (overGameObjects)
            try
            {
                overObjs.SetActive(true);
                if (overWorld == false)
                {
                    overObjs.SetActive(false);
                }
            }
            catch (MissingReferenceException)
            {
                //Debug.LogError("Oh noses!");
                overGameObjects.Remove(overObjs);
                break;
            }
        }

        foreach (GameObject underObjs in underGameObjects)
        {
            try
            {
                underObjs.SetActive(true);
                if (overWorld == true)
                {
                    underObjs.SetActive(false);
                }
            }
            catch (MissingReferenceException)
            {
                //Debug.LogError("Oh noses!");
                underGameObjects.Remove(underObjs);
                break;
            }
        }
    }
}
