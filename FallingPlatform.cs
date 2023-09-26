using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D target;

    private BoxCollider2D boxColl;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        anim.SetBool("off", true);
        target.enabled = false;
        boxColl.isTrigger = true;
    }
}
