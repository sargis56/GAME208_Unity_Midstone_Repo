using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 100;
    public float speed = 25;
    private Rigidbody rb;
    private Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Screen postion of the player
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        //Screen postion of the mouse
        mousePos = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Get the angle between the mouse and player
        float twoPointAngle = Mathf.Atan2(mousePos.y - screenPos.y, mousePos.x - screenPos.x) * Mathf.Rad2Deg;
        //Horizontal movement direction
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Vertical movement direction
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);

        //For rotating the player
        transform.rotation = Quaternion.Euler(new Vector3(-90.0f, -twoPointAngle, -90));
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
