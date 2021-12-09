using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Weapon") && (playerControllerScript.attacking == true))
        {
            playerControllerScript.UIScript.toggleWin();
            Destroy(this.gameObject);
        }
    }

}
