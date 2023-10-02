using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpike : MonoBehaviour
{
    private bool dirRight = true;

    public float speed;

    public float moveTime;

    private float timer;

    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
