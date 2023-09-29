using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float Speed;

    public float targetPositionX; // A posição X até onde o inimigo deve andar

    private Vector3 initialPosition; // A posição inicial do inimigo

    private bool isMoving; // Variável para controlar o estado de movimento do inimigo

    private Rigidbody2D rig;

    private Animator anim;

    public GameObject explosion;

    private Boolean isExploding;

    void Start()
    {
        isExploding = false;
        isMoving = true;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        while (!anim.GetBool("hit"))
        {
            anim.SetBool("walk", true);
            float movement = Speed * Time.deltaTime;
            transform.position += Vector3.right * movement;

            if ((Speed > 0 && transform.position.x >= targetPositionX) || (Speed < 0 && transform.position.x <= initialPosition.x))
            {
                Speed *= -1;
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                if (transform.position.x <= initialPosition.x)
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
            }

            yield return null;
        }
    }

    IEnumerator DestroyAfterExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        explosion.SetActive(true);
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            anim.SetBool("hit", true);

            isExploding = true;
            StartCoroutine(DestroyAfterExplosion());

        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == 8)
    //    {
    //        isJumping = true;
    //    }
    //}
}