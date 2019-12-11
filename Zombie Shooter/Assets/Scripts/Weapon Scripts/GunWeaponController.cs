using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem shootFX;
    public GameObject bulletFallFX;

    private Collider2D fireCollider;
    private WaitForSeconds waitTime = new WaitForSeconds(0.02f);
    private WaitForSeconds fireColliderWait = new WaitForSeconds(0.02f);

    void Start()
    {
        
    }

    public override void ProcessAttack()
    {
        switch (wpName)
        {
            case WeaponName.Pistol:
                break;
            case WeaponName.MP5:
                break;
            case WeaponName.M3:
                break;
            case WeaponName.AK:
                break;
            case WeaponName.AWP:
                break;
            case WeaponName.Fire:
                break;
            case WeaponName.Rocket:
                break;
        }

        // SPAWN A BULLET
    }

    IEnumerator WaitForShootEffect()
    {
        yield return waitTime;
        shootFX.Play();
    }

    IEnumerator ActiveFireCollider()
    {
        fireCollider.enabled = true;
        yield return fireColliderWait;
        fireCollider.enabled = false;
    }
}
