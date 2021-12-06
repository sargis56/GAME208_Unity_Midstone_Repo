using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionScriptSpeedItem : MonoBehaviour
{
    BoxCollider boxCollision;
    public int speedIncrease;

    public GameController gameControllerScript;

    void Start()
    {
        boxCollision = GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.increaseSpeed(speedIncrease);

            Destroy(gameObject);
        }
    }
}
