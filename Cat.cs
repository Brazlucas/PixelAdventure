using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Transform playerTransform;

    private Animator anim;

    public float followSpeed;

    public GameObject player;

    public NewBehaviourScript playerScript;

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<NewBehaviourScript>();
    }

    void Update()
    {
        if (playerScript.isWalking)
        {
            Move();
        }
        if (!playerScript.isWalking)
        {
            anim.SetBool("walk", false);
        }
        if (playerScript.isJumping)
        {
            anim.SetBool("jump", true);
        }
        if (!playerScript.isJumping)
        {
            anim.SetBool("jump", false);
        }
    }

    void Move()
    {
        anim.SetBool("walk", true);
        Vector3 direction = playerTransform.position - transform.position;
        transform.position += direction * followSpeed * Time.deltaTime;
        direction.Normalize();

        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
