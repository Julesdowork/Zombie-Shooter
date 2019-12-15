using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public bool bulletAndBulletFXCreated, rocketMissileCreated;

    void Awake()
    {
        if (instance == null) { instance = this; }
    }

    void OnDisable()
    {
        instance = null;
    }
}
