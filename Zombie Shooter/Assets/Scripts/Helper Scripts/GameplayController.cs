using UnityEngine;

public enum ZombieGoal
{
    PLAYER,
    FENCE
}

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public bool bulletAndBulletFXCreated, rocketMissileCreated;
    [HideInInspector]
    public bool playerAlive, fenceDestroyed;

    public ZombieGoal zombieGoal = ZombieGoal.PLAYER;

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
