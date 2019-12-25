using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private float moveSpeed = 1f;

    public void Move(Transform target)
    {
        Flip(target);

        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(target.position.x, target.position.y - 0.9f, 0),
            moveSpeed * Time.deltaTime);
    }

    private void Flip(Transform target)
    {
        Vector3 tempPos = transform.position;
        Vector3 tempScale = transform.localScale;

        if (target.position.x > (tempPos.x + 0.08f))
            tempScale.x = -1f;
        else if (target.position.x < (tempPos.x - 0.08f))
            tempScale.x = 1f;

        transform.localScale = tempScale;
    }
}
