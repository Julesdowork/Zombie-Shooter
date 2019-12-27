using System.Collections;
using UnityEngine;

public class FenceHealth : MonoBehaviour
{
    public int health = 100;
    public ParticleSystem woodBreakFX, woodExplodeFX;

    public void DealDamage(int amount)
    {
        health -= amount;
        woodBreakFX.Play();

        if (health <= 0)
        {
            woodExplodeFX.Play();
            GameplayController.instance.fenceDestroyed = true;
            StartCoroutine(DeactivateGameObject());
        }
    }

    private IEnumerator DeactivateGameObject()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
