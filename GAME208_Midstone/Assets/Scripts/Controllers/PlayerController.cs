using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxhealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    public float speed = 25;

    private Rigidbody rb;
    private Vector2 mousePos;

    public BoxCollider damageBox;

    public ButtonScript UIScript;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        currentHealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
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
        transform.rotation = Quaternion.Euler(new Vector3(-90.0f, -twoPointAngle, 90));

        if ( (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.S)) )
        {
            animator.SetInteger("run", 1);
        }

        if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
        {
            animator.SetInteger("run", 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("strafeL", 1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetInteger("strafeL", 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetInteger("strafeR", 1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetInteger("strafeR", 0);
        }

        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Jump");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack1");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("Attack2");
        }
    }

    void FixedUpdate()
    {

    }
    public void addHealth(int health_)
    {
        currentHealth = currentHealth + health_;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void increaseSpeed(int speedIncrease_)
    {
        speed = speed + speedIncrease_;
    }

    void OnTriggerEnter(Collider _collision)
    {

        //if (_collision.gameObject.tag == "Enemy") //collision with enemymicrobot
        if (_collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            TakeDamage(10);

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            UIScript.toggleDeath();
        }
    }

    public void movePlayer(Vector3 pos_)
    {
        transform.position = pos_;
    }

    //void OnCollisionEnter(Collision collision)
    //{
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Debug.Log(Input.mousePosition);
        //}
        //if (collision.gameObject.tag == "Player")
        //{
        //    PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
        //    playerScript.addHealth(potionHealth);

        //    Destroy(gameObject);
        //}
    //}
}
