using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDynamic : MonoBehaviour
{
    public Rigidbody projectile;
    public GameObject player;
    public GameObject mainEnemy;
    // Start is called before the first frame update
    void Start()
    {
        projectile.useGravity = false;
        Vector3 normalizedDirection = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
        normalizedDirection = normalizedDirection.normalized;
        projectile.velocity = normalizedDirection * 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.TakeDamage(3);
        }
        transform.position = mainEnemy.transform.position;
        Vector3 normalizedDirection = new Vector3(player.transform.position.x - transform.position.x, 1, player.transform.position.z - transform.position.z);
        normalizedDirection = normalizedDirection.normalized;
        projectile.velocity = normalizedDirection * 100;
    }
}
