﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPool : MonoBehaviour
{
    public static SmartPool instance;

    private List<GameObject> bulletFallFX = new List<GameObject>();
    private List<GameObject> bulletPrefabs = new List<GameObject>();
    private List<GameObject> rocketMissilePrefabs = new List<GameObject>();


    void Awake()
    {
        if (instance == null) { instance = this; }
    }

    void OnDisable()
    {
        instance = null;
    }

    public void CreateBulletandBulletFall(GameObject bullet, GameObject bulletFall, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempBullet = Instantiate(bullet);
            GameObject tempBulletFall = Instantiate(bulletFall);

            bulletPrefabs.Add(tempBullet);
            bulletFallFX.Add(tempBulletFall);

            bulletPrefabs[i].SetActive(false);
            bulletFallFX[i].SetActive(false);
        }
    }

    public void CreateRocket(GameObject rocket, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempRocket = Instantiate(rocket);
            rocketMissilePrefabs.Add(tempRocket);
            rocketMissilePrefabs[i].SetActive(false);
        }
    }

    public GameObject SpawnBulletFallFX(Vector3 pos, Quaternion rot)
    {
        for (int i = 0; i < bulletFallFX.Count; i++)
        {
            if (!bulletFallFX[i].activeInHierarchy)
            {
                bulletFallFX[i].SetActive(true);
                bulletFallFX[i].transform.position = pos;
                bulletFallFX[i].transform.rotation = rot;

                return bulletFallFX[i];
            }
        }

        return null;
    }

    public void SpawnBullet(Vector3 pos, Vector3 dir, Quaternion rot, WeaponName wpName)
    {
        if (wpName != WeaponName.Rocket)
        {
            for (int i = 0; i < bulletPrefabs.Count; i++)
            {
                if (!bulletPrefabs[i].activeInHierarchy)
                {
                    bulletPrefabs[i].SetActive(true);
                    bulletPrefabs[i].transform.position = pos;
                    bulletPrefabs[i].transform.rotation = rot;

                    // GET THE BULLET SCRIPT
                    bulletPrefabs[i].GetComponent<BulletController>().SetDirection(dir);

                    // SET THE BULLET DAMAGE

                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < rocketMissilePrefabs.Count; i++)
            {
                if (!rocketMissilePrefabs[i].activeInHierarchy)
                {
                    rocketMissilePrefabs[i].SetActive(true);
                    rocketMissilePrefabs[i].transform.position = pos;
                    rocketMissilePrefabs[i].transform.rotation = rot;

                    // GET THE BULLET SCRIPT
                    rocketMissilePrefabs[i].GetComponent<BulletController>().SetDirection(dir);

                    // SET THE BULLET DAMAGE

                    break;
                }
            }
        }
    }
}