using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float movedSpeed = 6.0f;
    private float jumpPower = 7.0f;

    public Transform groundChecker;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rigid;
    bool isGround = true;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isAttack", true);
            soundManager.instance.AttackSound();
            Collider2D col = Physics2D.OverlapCircle(transform.position, 2, (1 << LayerMask.NameToLayer("Enemy")));
            if(col!= null)
            {
                col.GetComponent<enemy>().Die();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isAttack", false);
        }

        isGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGround = false;
        }
    }

    void Move()
    {
        float posX = Input.GetAxis("Horizontal");
        if (posX != 0)
        {
            if (posX >= 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        transform.Translate(Mathf.Abs(posX) * Vector3.right * movedSpeed * Time.deltaTime);
    }
}
