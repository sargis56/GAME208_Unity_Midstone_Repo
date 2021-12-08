using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{

    public float lookRadius = 100f;

    public PlayerController playerControllerScript;

    Transform target;
    NavMeshAgent agent;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(-90, 1, 1);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }

        Vector3 lookPostion = agent.destination - transform.position;
        lookPostion.y = 0;
        if (lookPostion.x != 0 || lookPostion.y != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(lookPostion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20) * Quaternion.Euler(-90, 1, 1);
            try
            {
                animator.SetInteger("run", 1);
            }
            catch
            {
                //Debug.LogError("Oh noses!");
            }
            
        }
    }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, lookRadius);
        }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("check");
        if ((collision.gameObject.tag == "Weapon") && (playerControllerScript.attacking == true))
        {
            Destroy(this.gameObject);
        }
    }
}
