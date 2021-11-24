using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDynamic : MonoBehaviour
{
    public Rigidbody projectile;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        projectile.useGravity = false;
        projectile.velocity = new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
