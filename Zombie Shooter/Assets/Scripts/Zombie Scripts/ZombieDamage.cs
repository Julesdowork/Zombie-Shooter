using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public LayerMask collisionLayer;

    public float radius = 1f;
    public int damage = 3;

    // Update is called once per frame
    void Update()
    {
        if (GameplayController.instance.zombieGoal == ZombieGoal.PLAYER)
            AttackPlayer();
        else
            AttackFence();
    }

    private void AttackPlayer()
    {
        if (GameplayController.instance.playerAlive)
        {
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

            if (target.tag == TagManager.PLAYER_HEALTH_TAG)
            {
                target.GetComponent<PlayerHealth>().DealDamage(damage);
            }
        }
    }

    private void AttackFence()
    {
        if (!GameplayController.instance.fenceDestroyed)
        {
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

            if (target.CompareTag(TagManager.FENCE_TAG))
            {
                target.GetComponent<FenceHealth>().DealDamage(damage);
            }
        }
    }
}
