using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Vector2 RightAttackOffset;

    public Collider2D SwordCollider;


    private void Start()
    {
        SwordCollider = GetComponent<Collider2D>();
        RightAttackOffset = transform.position;
        SwordCollider.enabled = false;
    }

    public void Attack()
    {
        SwordCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy" && SwordCollider.enabled == true)
        {
            SlimeBehavior slimeBehavior = collider.GetComponent<SlimeBehavior>();
            if (slimeBehavior != null)
            {
                slimeBehavior.Damage();
            }
        }
    }

}
