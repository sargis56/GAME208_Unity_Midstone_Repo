using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollisionScript : MonoBehaviour
{
    BoxCollider boxCollision;
    public Vector3 doorDirection;
    public Vector3 cameraDirection;
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
            Vector3 newPosPlayer = playerScript.transform.position;
            newPosPlayer = newPosPlayer + doorDirection;
            Vector3 newPosCamera = playerCamera.transform.position;
            newPosCamera = newPosCamera + cameraDirection;
            playerCamera.transform.position = newPosCamera;
            playerScript.movePlayer(newPosPlayer);
        }
    }
}
