using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionScript : MonoBehaviour
{
    BoxCollider boxCollision;
    public Vector3 inputedPos;

    public GameController gameControllerScript;
    public Camera playerCamera;

    void Start()
    {
        boxCollision = GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            Vector3 newPos = playerScript.transform.position;
            newPos.z = newPos.z + 100;
            Vector3 newPosCamera = playerCamera.transform.position;
            newPosCamera.z = newPosCamera.z + 250;
            playerCamera.transform.position = newPosCamera;
            playerScript.movePlayer(newPos);
        }
    }
}
