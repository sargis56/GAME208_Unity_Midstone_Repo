using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 100;
    public float speed = 25;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.MovePosition(transform.position + movement * Time.deltaTime * speed);
    }

    void FixedUpdate()
    {

    }
    public void addHealth(float health_)
    {
        health = health + health_;
        if (health > 100)
        {
            health = 100;
        }
    }
    public void movePlayer(Vector3 pos_)
    {
        transform.position = pos_;
    }
}
