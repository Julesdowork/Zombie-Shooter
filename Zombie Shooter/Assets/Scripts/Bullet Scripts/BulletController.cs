using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector]
    public int damage;

    public GameObject rocketExplosion;

    private float speed = 60f;
    private float defaultTimeAlive = 2f;
    private IEnumerator coroutineDeactivate;
    private Vector3 direction;
    private WaitForSeconds waitForTimeAlive = new WaitForSeconds(2f);

    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag(TagManager.ROCKET_MISSILE_TAG))
        {
            speed = 8f;
        }
    }

    void OnEnable()
    {
        coroutineDeactivate = WaitForDeactivate();
        StartCoroutine(coroutineDeactivate);
    }

    void OnDisable()
    {
        if (coroutineDeactivate != null)
        {
            StopCoroutine(coroutineDeactivate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    IEnumerator WaitForDeactivate()
    {
        yield return waitForTimeAlive;
        gameObject.SetActive(false);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }
}
