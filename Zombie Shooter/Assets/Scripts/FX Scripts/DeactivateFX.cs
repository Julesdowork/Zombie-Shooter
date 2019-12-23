using UnityEngine;

public class DeactivateFX : MonoBehaviour
{
    // Called every time when game object is activated
    void OnEnable()
    {
        Invoke("DeactivateGameObject", 2f);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}