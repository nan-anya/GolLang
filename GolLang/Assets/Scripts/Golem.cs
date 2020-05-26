using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    private Animator animator;

    bool aniEnd = false;

    //max = 3
    public int HP;

    //max = 3
    public int AP;

    // Start is called before the first frame update
    void Start()
    {
        HP = 3;

        AP = 3;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("A");
            StartCoroutine(die_Coroutine());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            print("S");
            StartCoroutine(attack_Coroutine());
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            print("D");
            StartCoroutine(hit_Coroutine());
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            print("F");
            StartCoroutine(victory_Coroutine());
        }
    }

    public void animationEnded()
    {
        aniEnd = true;
    }

    public void attack()
    {
        StartCoroutine(attack_Coroutine());
    }

    public void hit()
    {
        StartCoroutine(hit_Coroutine());
    }

    public void defence()
    {
        StartCoroutine(defence_Coroutine());
    }

    public void die()
    {
        StartCoroutine(die_Coroutine());
    }

    public void victory()
    {
        StartCoroutine(victory_Coroutine());
    }

    public IEnumerator attack_Coroutine()
    {
        animator.SetTrigger("Attack");
        aniEnd = false;

        while (!aniEnd)
        {
            yield return null;
        }

        animator.SetTrigger("Idle");
    }

    public IEnumerator hit_Coroutine()
    {
        animator.SetTrigger("GetHit");

        aniEnd = false;

        while (!aniEnd)
        {
            yield return null;
        }

        animator.SetTrigger("Idle");
    }
    
    public IEnumerator defence_Coroutine()
    {
        transform.Find("Shield").gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        transform.Find("Shield").gameObject.SetActive(false);

        animator.SetTrigger("Idle");
    }

    public IEnumerator die_Coroutine()
    {
        animator.SetTrigger("Die");
        aniEnd = false;

        while (!aniEnd)
        {
            yield return null;
        }

        animator.SetTrigger("Idle");
    }
    
    public IEnumerator victory_Coroutine()
    {
        animator.SetTrigger("Victory");

        yield return null;
    }

    public void getAP()
    {
        if (AP <= 2)
        {
            AP++;
        }
    }

    public void getDamage(int damage)
    {
        HP -= damage;
    }

    public void reset()
    {
        AP = 0;

        HP = 3;

        animator.SetTrigger("Idle");
    }
}
