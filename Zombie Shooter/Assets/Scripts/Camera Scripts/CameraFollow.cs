using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    void LateUpdate()
    {
        if (GameplayController.instance.gameGoal != GameGoal.DEFEND_FENCE &&
            GameplayController.instance.gameGoal != GameGoal.GAME_OVER)
        {
            if (player)
            {
                Vector3 temp = transform.position;
                temp.x = player.position.x;
                transform.position = temp;
            }
        }
    }
}
