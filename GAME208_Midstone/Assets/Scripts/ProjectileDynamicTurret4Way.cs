using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDynamicTurret4Way : MonoBehaviour
{
    public Rigidbody projectile;
    //public GameObject player;
    public GameObject mainEnemy;
    public float xAxis;
    public float zAxis;
    // Start is called before the first frame update
    void Start()
    {
        projectile.useGravity = false;
        //Vector3 normalizedDirection = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
        //normalizedDirection = normalizedDirection.normalized;
        projectile.velocity = new Vector3(xAxis, 0, zAxis);
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
        if (collision.gameObject.tag != "Underworld")
        {
            transform.position = mainEnemy.transform.position;
            projectile.velocity = new Vector3(xAxis, 0, zAxis);
        }
    }
}
