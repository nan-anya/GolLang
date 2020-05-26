using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator animator;

    bool aniEnd = false;

    //max = 3
    public int HP;

    //max = 3
    public int AP;

    /*
    다음에 취할 행동패턴
    0 : 에너지 충전
    1 : 근거리 공격
    2 : 방어
    */
    public int nextAction = 0;

    private int previousAction = 0;

    // Start is called before the first frame update
    void Start()
    {
        HP = 3;

        AP = 0;

        nextAction = 0;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
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
        animator.SetTrigger("Die");
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
        print("m hit");

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
    //

    public void moveNext()
    {
        previousAction = nextAction;

        if (previousAction == 1)
        {
            nextAction = 2;
        }
        else if (AP == 0)
        {
            nextAction = 0;
        }
        else if(AP != 0)
        {
            nextAction = 1;
        }
    }

    public int getNextAction()
    {
        return nextAction;
    }
}
