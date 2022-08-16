using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Damage()
    {
        anim.SetTrigger("Damage");
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
