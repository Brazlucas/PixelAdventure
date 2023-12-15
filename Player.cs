using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed;

    public float JumpForce;

    public int Life;

    private int TemporaryLife;

    private bool Dead;

    private Rigidbody2D rig;

    private Animator anim;

    public bool isJumping;

    public bool isWalking;

    public GameObject[] hearts;

    void Start()
    {
        Life = hearts.Length;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Dead)
        {
            Move();
            Jump();
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            isWalking = true;
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            isWalking = true;
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
            isWalking = false;
        }
    }

    void Jump()
    {
       if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);
            } 
        }
    }

    void FreezeAnimation()
    {
        if (Dead)
        {
            anim.enabled = false;
        }
    }

    void PlayerDamage()
    {
        if (Life > 0)
        {
            Life--;
            Destroy(hearts[Life].gameObject);

            if (Life < 1)
            {
                Dead = true;
                anim.SetBool("damage", true);
                Invoke("CallGameOver", 0.5f);
            }
        }
    }
    void CallGameOver()
    {
        GameController.instance.ShowGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "Explosion")
        {
            PlayerDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "Enemy" && collision.collider.GetType() == typeof(BoxCollider2D))
        {
            PlayerDamage();
        }

        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Saw")
        {
            for (int i = 0; i < 2; i++)
            {
                PlayerDamage();
            }
        }

        if (collision.gameObject.tag == "Trampoline")
        {
            rig.AddForce(new Vector2(0f, JumpForce +8), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
