using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject player;
    public BoxCollider bombRadius;
    public TextMeshPro bombTimer;
    public bool bombActive;
    //Collider[] allOverlappingColliders;
    float timeLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        //bombRadius.SetActive(false);
        //Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        //Physics.IgnoreLayerCollision(10, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if (bombActive == true)
        {
            timeLeft -= Time.deltaTime;
        }
        bombTimer.text = Mathf.Round(timeLeft).ToString();
        if (timeLeft < 0)
        {
            BlowUp();
        }
    }

    void BlowUp()
    {
        Instantiate(bombRadius, transform.position, transform.rotation = Quaternion.Euler(0, 0, 0));
        player.GetComponent<PlayerController>().attacking = true;
        if (timeLeft < -0.1)
        {
            Destroy(this.gameObject);
            player.GetComponent<PlayerController>().attacking = false;
        }
         //bombRadius.gameObject.SetActive(true);
    }
}
