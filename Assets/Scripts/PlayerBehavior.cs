using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] float attackwait = 0.1f;

    public SwordAttack swordAttack;

    private Vector2 movementInput;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        if (movementInput != Vector2.zero)
        {
            anim.SetBool("Run", true);
            if(movementInput.x != 0)
            {
                transform.localScale = new Vector2(movementInput.x, 1);
                
            }
        }
        else
        {
            anim.SetBool("Run", false);
        }

        StartCoroutine(Attack());

     

    }

    IEnumerator Attack()
    {
        if (Input.GetButton("Fire1") && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") != true)
        {
            anim.SetTrigger("Attack");
            if (transform.localScale.x == 1)
            {
                yield return new WaitForSeconds(attackwait);
                swordAttack.AttackRight();
            }
            else
            {
                yield return new WaitForSeconds(attackwait);
                swordAttack.AttackLeft();
            }

        }
    }

    void FixedUpdate()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") != true)
        {
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            swordAttack.SwordCollider.enabled = false;
        }
        

    }

 
}
