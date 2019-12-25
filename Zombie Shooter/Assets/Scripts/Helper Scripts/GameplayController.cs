using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public bool bulletAndBulletFXCreated, rocketMissileCreated;
    [HideInInspector]
    public bool playerAlive;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        playerAlive = true;
    }

    void OnDisable()
    {
        instance = null;
    }
}
