using UnityEngine;

public enum ZombieGoal
{
    PLAYER,
    FENCE
}

public enum GameGoal
{
    KILL_ZOMBIES,
    WALK_TO_GOAL_STEPS,
    DEFEND_FENCE,
    TIMER_COUNTDOWN,
    GAME_OVER
}

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public bool bulletAndBulletFXCreated, rocketMissileCreated;
    [HideInInspector]
    public bool playerAlive, fenceDestroyed;

    public ZombieGoal zombieGoal = ZombieGoal.PLAYER;
    public GameGoal gameGoal = GameGoal.DEFEND_FENCE;

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
