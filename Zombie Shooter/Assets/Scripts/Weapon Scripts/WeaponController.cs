using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponName
{
    Melee,
    Pistol,
    MP5,
    M3,
    AK,
    AWP,
    Fire,
    Rocket
}

public class WeaponController : MonoBehaviour
{
    public DefaultConfig defaultConfig;
    public WeaponName wpName;

    protected PlayerAnimations playerAnim;
    protected float lastShot;

    public int gunIndex;
    public int currentAmmo;
    public int magazineSize;

    void Awake()
    {
        playerAnim = GetComponentInParent<PlayerAnimations>();
        currentAmmo = magazineSize;
    }

    public void CallAttack()
    {
        if (Time.time > lastShot + defaultConfig.fireRate)
        {
            if (currentAmmo > 0)
            {
                ProcessAttack();
                playerAnim.AttackAnimation();
                lastShot = Time.time;
                currentAmmo--;
            }
            else
            {
                // PLAY NO AMMO SOUND
            }
        }
    }

    public virtual void ProcessAttack() { }
}
