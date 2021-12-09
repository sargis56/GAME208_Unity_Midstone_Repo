using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxhealth = 10;
    public int currentHealth;

    public HealthBar healthBar;
    public float speed = 25;

    private Rigidbody rb;
    private Vector2 mousePos;
    public bool attacking;

    public BoxCollider damageBox;

    public ButtonScript UIScript;
    public Animator animator;

    public AudioClip hitSound;
    public AudioClip swingSound1;
    public AudioClip swingSound2;
    public AudioClip teleportSound;
    AudioSource aSource;

    public GameObject mouseCursor;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
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

        Vector3 pos = Input.mousePosition;
        pos.z = 200;
        pos = Camera.main.ScreenToWorldPoint(pos);
        mouseCursor.transform.position = pos;

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
            playSound(teleportSound);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack1");
            playSound(swingSound1);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("Attack2");
            playSound(swingSound2);
        }

        if ((this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1")) || (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2")))
        {
            attacking = true;
        }
        else
        {
            attacking = false;
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

    void OnCollisionEnter(Collision collision)
    {

        //if (_collision.gameObject.tag == "Enemy") //collision with enemymicrobot
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            animator.SetTrigger("impact");
            playSound(hitSound);
            TakeDamage(3);
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

    void playSound(AudioClip clip)
    {
        aSource.clip = clip;
        aSource.Play();
    }
}
