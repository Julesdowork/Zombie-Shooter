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

        if (collision.CompareTag(TagManager.BULLET_TAG) || collision.CompareTag(TagManager.ROCKET_MISSILE_TAG))
        {
            anim.Hurt();

            health -= collision.GetComponent<BulletController>().damage;

            if (collision.CompareTag(TagManager.ROCKET_MISSILE_TAG))
            {
                collision.GetComponent<BulletController>().ExplosionFX();
            }

            if (health <= 0)
            {
                alive = false;
                anim.Dead();

                StartCoroutine(DeactivateZombie());
            }

            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag(TagManager.FIRE_BULLET_TAG))
        {
            anim.Hurt();
            health -= fireDamage;
            if (health <= 0)
            {
                alive = false;
                anim.Dead();
                StartCoroutine(DeactivateZombie());
            }
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

    IEnumerator DeactivateZombie()
    {
        yield return new WaitForSeconds(2f);

        //Instantiate(coinCollectable, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void ActivateDeadEffect(int index)
    {
        fxDead[index].SetActive(true);

        if (fxDead[index].GetComponent<ParticleSystem>())
        {
            fxDead[index].GetComponent<ParticleSystem>().Play();
        }
    }

    public void DealDamage(int damage)
    {
        anim.Hurt();
        health -= damage;

        if (health <= 0)
        {
            alive = false;
            anim.Dead();

            StartCoroutine(DeactivateZombie());
        }
    }

    public void ActivateDamagePoint()
    {
        damageCollider.SetActive(true);
    }

    public void DeactivateDamagePoint()
    {
        damageCollider.SetActive(false);
    }
}
