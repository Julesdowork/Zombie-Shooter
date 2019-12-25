using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.SetTrigger(TagManager.ATTACK_PARAM);
    }

    public void Hurt()
    {
        anim.SetTrigger(TagManager.GET_HURT_PARAM);
    }

    public void Dead()
    {
        anim.SetTrigger(TagManager.DEAD_PARAM);
    }
}
