using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem shootFX;
    public GameObject bulletFallFXPrefab;

    private Collider2D fireCollider;
    private WaitForSeconds waitTime = new WaitForSeconds(0.02f);
    private WaitForSeconds fireColliderWait = new WaitForSeconds(0.02f);

    void Start()
    {
        // create bullets
        if (!GameplayController.instance.bulletAndBulletFXCreated)
        {
            GameplayController.instance.bulletAndBulletFXCreated = true;
            if (wpName != WeaponName.Fire && wpName != WeaponName.Rocket)
            {
                SmartPool.instance.CreateBulletandBulletFall(bulletPrefab, bulletFallFXPrefab, 100);
            }
        }

        if (!GameplayController.instance.rocketMissileCreated)
        {
            if (wpName == WeaponName.Rocket)
            {
                GameplayController.instance.rocketMissileCreated = true;
                SmartPool.instance.CreateRocket(bulletPrefab, 100);
            }
        }
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

        if (transform != null && wpName != WeaponName.Fire)
        {
            if (wpName != WeaponName.Rocket)
            {
                GameObject fallFX = SmartPool.instance.SpawnBulletFallFX(
                    spawnPoint.position, Quaternion.identity);

                fallFX.transform.localScale =
                    (transform.root.eulerAngles.y > 1) ? new Vector3(-1, 1, -1) : new Vector3(1, 1, 1);

                StartCoroutine(WaitForShootEffect());
            }

            SmartPool.instance.SpawnBullet(spawnPoint.position,
                new Vector3(-transform.root.localScale.x, 0, 0), spawnPoint.rotation, wpName);
        }
        else
        {
            StartCoroutine(ActiveFireCollider());
        }
    }

    IEnumerator WaitForShootEffect()
    {
        yield return waitTime;
        shootFX.Play();
    }

    IEnumerator ActiveFireCollider()
    {
        //fireCollider.enabled = true;
        shootFX.Play();
        yield return fireColliderWait;
        //fireCollider.enabled = false;
    }
}
