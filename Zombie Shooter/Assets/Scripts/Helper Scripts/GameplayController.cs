using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int zombieCount = 20;
    public int stepCount = 100;
    public int timer = 100;
    [HideInInspector] public int coinCount;

    public ZombieGoal zombieGoal = ZombieGoal.PLAYER;
    public GameGoal gameGoal = GameGoal.DEFEND_FENCE;

    public GameObject pausePanel, gameOverPanel;

    private Transform playerTarget;
    private Vector3 playerPreviousPos;
    private Text zombieCountText, timerText, stepCountText;
    private Image playerLife;

    private int initialStepCount;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        playerAlive = true;

        if (gameGoal == GameGoal.WALK_TO_GOAL_STEPS)
        {
            playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
            playerPreviousPos = playerTarget.position;
            
            initialStepCount = stepCount;
            stepCountText = GameObject.Find("Step Counter").GetComponent<Text>();
            stepCountText.text = stepCount.ToString();
        }

        if (gameGoal == GameGoal.TIMER_COUNTDOWN || gameGoal == GameGoal.DEFEND_FENCE)
        {
            timerText = GameObject.Find("Timer Counter").GetComponent<Text>();
            timerText.text = timer.ToString();

            InvokeRepeating("TimerCountdown", 1f, 1f);
        }

        if (gameGoal == GameGoal.KILL_ZOMBIES)
        {
            zombieCountText = GameObject.Find("Zombie Counter").GetComponent<Text>();
            zombieCountText.text = zombieCount.ToString();
        }

        playerLife = GameObject.Find("Life Full").GetComponent<Image>();
    }

    void OnDisable()
    {
        instance = null;
    }

    void Update()
    {
        if (gameGoal == GameGoal.WALK_TO_GOAL_STEPS)
        {
            CountPlayerMovement();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    private void TimerCountdown()
    {
        timer--;
        timerText.text = timer.ToString();

        if (timer <= 0)
        {
            print("Game Over");
            CancelInvoke();
        }
    }

    public void ZombieDied()
    {
        zombieCount--;
        zombieCountText.text = zombieCount.ToString();

        if (zombieCount <= 0)
        {
            print("Game Over");
        }
    }

    public void PlayerLifeCounter(float fillPercentage)
    {
        fillPercentage /= 100f;
        playerLife.fillAmount = fillPercentage;
    }

    private void CountPlayerMovement()
    {
        Vector3 playerCurrentPos = playerTarget.position;

        float dist = Vector3.Distance(new Vector3(playerCurrentPos.x, 0, 0),
            new Vector3(playerPreviousPos.x, 0, 0));

        if (playerCurrentPos.x > playerPreviousPos.x)
        {
            if (dist > 1)
            {
                stepCount--;
                if (stepCount <= 0)
                {
                    print("We made that many steps");
                }
                playerPreviousPos = playerTarget.position;
            }
        }
        else if (playerCurrentPos.x < playerPreviousPos.x)
        {
            if (dist > 0.8f)
            {
                stepCount++;
                if (stepCount >= initialStepCount)
                    stepCount = initialStepCount;
                playerPreviousPos = playerTarget.position;
            }
        }

        stepCountText.text = stepCount.ToString();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_NAME);
    }
}
