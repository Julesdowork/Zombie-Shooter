using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public GameObject[] bloodFX;

    private PlayerAnimations anim;

    void Awake()
    {
        anim = GetComponentInParent<PlayerAnimations>();
    }

    public void DealDamage(int damage)
    {
        health -= damage;

        anim.HurtAnimation();

        if (health <= 0)
        {
            GameplayController.instance.playerAlive = false;

            GetComponent<Collider2D>().enabled = false;
            anim.DeadAnimation();
            bloodFX[Random.Range(0, bloodFX.Length)].SetActive(true);
        }
    }
}
