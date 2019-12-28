using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPool : MonoBehaviour
{
    public static SmartPool instance;

    public GameObject[] zombies;

    private List<GameObject> bulletFallFX = new List<GameObject>();
    private List<GameObject> bulletPrefabs = new List<GameObject>();
    private List<GameObject> rocketMissilePrefabs = new List<GameObject>();
    //private Camera mainCamera;

    private float ySpawnPosMin = -3.7f, ySpawnPosMax = -0.36f;

    void Awake()
    {
        if (instance == null) { instance = this; }
    }

    void Start()
    {
        InvokeRepeating("StartSpawningZombies", 1f, Random.Range(1f, 5f));
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

                    bulletPrefabs[i].GetComponent<BulletController>().SetDirection(dir);

                    SetBulletDamage(wpName, bulletPrefabs[i]);

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

                    rocketMissilePrefabs[i].GetComponent<BulletController>().SetDirection(dir);

                    SetBulletDamage(wpName, rocketMissilePrefabs[i]);

                    break;
                }
            }
        }
    }

    void SetBulletDamage(WeaponName weaponName, GameObject bullet)
    {
        switch (weaponName)
        {
            case WeaponName.Pistol:
                bullet.GetComponent<BulletController>().damage = 2;
                break;
            case WeaponName.MP5:
                bullet.GetComponent<BulletController>().damage = 3;
                break;
            case WeaponName.M3:
                bullet.GetComponent<BulletController>().damage = 4;
                break;
            case WeaponName.AWP:
                bullet.GetComponent<BulletController>().damage = 10;
                break;
            case WeaponName.AK:
                bullet.GetComponent<BulletController>().damage = 5;
                break;
            case WeaponName.Rocket:
                bullet.GetComponent<BulletController>().damage = 10;
                break;
        }
    }

    private void StartSpawningZombies()
    {
        if (GameplayController.instance.gameGoal == GameGoal.DEFEND_FENCE)
        {
            float xPos = Camera.main.transform.position.x;
            xPos += 15;

            float yPos = Random.Range(ySpawnPosMin, ySpawnPosMax);

            Instantiate(zombies[Random.Range(0, zombies.Length)],
                new Vector3(xPos, yPos, 0), Quaternion.identity);
        }
        else if (GameplayController.instance.gameGoal == GameGoal.KILL_ZOMBIES ||
            GameplayController.instance.gameGoal == GameGoal.TIMER_COUNTDOWN ||
            GameplayController.instance.gameGoal == GameGoal.WALK_TO_GOAL_STEPS)
        {
            float xPos = Camera.main.transform.position.x;

            if (Random.Range(0, 2) > 0)
            {
                xPos += Random.Range(10f, 15f);
            }
            else
            {
                xPos -= Random.Range(10f, 15f);
            }

            float yPos = Random.Range(ySpawnPosMin, ySpawnPosMax);

            Instantiate(zombies[Random.Range(0, zombies.Length)],
                new Vector3(xPos, yPos, 0), Quaternion.identity);
        }
        else
        {
            CancelInvoke("StartSpawningZombies");
        }
    }
}
