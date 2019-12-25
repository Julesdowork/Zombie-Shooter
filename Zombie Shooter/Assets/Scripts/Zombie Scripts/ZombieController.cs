using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public GameObject damageCollider;
    public GameObject[] fxDead;
    public GameObject coinCollectable;

    public int health = 10;
    
    private ZombieMovement movement;
    private ZombieAnimation anim;

    private Transform target;

    private bool canAttack;
    private bool alive = true;
    private float timerAttack;
    private int fireDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<ZombieMovement>();
        anim = GetComponent<ZombieAnimation>();

        alive = true;

        target = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            CheckDistance();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_HEALTH_TAG) ||
            collision.CompareTag(TagManager.PLAYER_TAG) ||
            collision.CompareTag(TagManager.FENCE_TAG))
        {
            canAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_HEALTH_TAG) ||
            collision.CompareTag(TagManager.PLAYER_TAG) ||
            collision.CompareTag(TagManager.FENCE_TAG))
        {
            canAttack = false;
        }
    }

    private void CheckDistance()
    {
        if (target)
        {
            if (Vector3.Distance(target.position, transform.position) > 1.5f)
            {
                movement.Move(target);
            }
            else
            {
                if (canAttack)
                {
                    anim.Attack();
                }
            }
        }
    }
}
