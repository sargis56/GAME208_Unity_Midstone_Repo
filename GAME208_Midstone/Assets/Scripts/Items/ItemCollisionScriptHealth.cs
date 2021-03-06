using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionScriptHealth : MonoBehaviour
{
    BoxCollider boxCollision;
    public int potionHealth;

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
            playerScript.addHealth(potionHealth);

            Destroy(gameObject);
        }
    }
}
