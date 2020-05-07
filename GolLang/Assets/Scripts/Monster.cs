﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator animator;

    enum AttackType
    {
        Attack01, Attack02
    };
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Die();
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            InBattle();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            Attack(AttackType.Attack01);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Attack(AttackType.Attack02);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Move01");
        }
        else if(Input.GetKeyDown(KeyCode.H))
        {
            Hit();
        }
    }

    void Attack(AttackType Type)
    {
        if (Type == AttackType.Attack01)
        {
            animator.SetTrigger("Attack01");
        }
        else if (Type == AttackType.Attack02)
        {
            animator.SetTrigger("Attack02");
        }
    }

    void Hit()
    {
        animator.SetTrigger("Hit");
    }

    void Die()
    {
        animator.SetTrigger("Die");
    }

    void InBattle()
    {
        animator.SetTrigger("InBattle");
    }
}