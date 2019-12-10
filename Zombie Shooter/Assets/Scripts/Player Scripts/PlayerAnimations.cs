using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerRunAnimation(bool run)
    {
        anim.SetBool(TagManager.RUN_PARAM, run);
    }

    public void AttackAnimation()
    {
        anim.SetTrigger(TagManager.ATTACK_PARAM);
    }

    public void SwitchWeaponAnimation(int typeWeapon)
    {
        anim.SetInteger(TagManager.TYPE_WEAPON_PARAM, typeWeapon);
        anim.SetTrigger(TagManager.SWITCH_PARAM);
    }

    public void HurtAnimation()
    {
        anim.SetTrigger(TagManager.GET_HURT_PARAM);
    }

    public void DeadAnimation()
    {
        anim.SetTrigger(TagManager.DEAD_PARAM);
    }
}
