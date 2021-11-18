using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    BoxCollider boxCollision;
    public float potionHealth;

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
