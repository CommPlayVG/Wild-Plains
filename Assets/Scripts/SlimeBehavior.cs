using Pathfinding;
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
    private void Awake()
    {
        AIDestinationSetter ai_seek = this.GetComponent<AIDestinationSetter>();
        ai_seek.target = GameObject.FindGameObjectWithTag("Player").transform;
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
