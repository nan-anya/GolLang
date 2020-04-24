using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject ForEndBlock;
    public GameObject ForStartBlock;
    public GameObject IfStartBlock;
    public GameObject IfEndBlock;
    public GameObject ElseBlock;
    public GameObject GenerateBlock;
    public GameObject AttackKickBlock;

    public GameObject IBlock;
  
    public GameObject PlusBlock;
    public GameObject MinusBlock;
    public GameObject MultBlock;
    public GameObject DivBlock;
    public GameObject EqaulBlock;
    public GameObject NotEqualBlock;
    public GameObject ModBlock;

    public GameObject Number1;
    public GameObject Number2;
    public GameObject Number3;
    public GameObject Number4;
    public GameObject Number5;
    public GameObject Number6;
    public GameObject Number7;
    public GameObject Number8;
    public GameObject Number9;
    public GameObject Number0;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 블록 생성
    public void ForStartInst()
    {
        Debug.Log("For");
       
        GameObject ForBlock;

        ForBlock = (GameObject)Instantiate(ForStartBlock);
        ForBlock.transform.name += (count++);
        ForBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        ForBlock.transform.localPosition = Vector3.zero;
    }
    public void ForEndInst()
    {
        Debug.Log("Click");
    }
    public void IfStartInst()
    {
        GameObject IfBlock;

        IfBlock = (GameObject)Instantiate(IfStartBlock);
        IfBlock.transform.name += (count++);
        IfBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        IfBlock.transform.localPosition = Vector3.zero;
    }

    public void IfEndInst()
    {

    }

    public void ElseInst()
    {
        GameObject ElseB;

        ElseB = (GameObject)Instantiate(ElseBlock);
        ElseB.transform.name += (count++);
        ElseB.transform.parent = GameObject.Find("WorkSpace").transform;
        ElseB.transform.localPosition = Vector3.zero;
    }

    public void GenerateInst()
    {

    }

    public void AttackKickInst()
    {
        GameObject AttackKB;

        AttackKB = (GameObject)Instantiate(AttackKickBlock);
        AttackKB.transform.name += (count++);
        AttackKB.transform.parent = GameObject.Find("WorkSpace").transform;
        AttackKB.transform.localPosition = Vector3.zero;
    }

    public void VarIBlockInst()
    {
        GameObject VarIB;

        VarIB = (GameObject)Instantiate(IBlock);
        VarIB.transform.name += (count++);
        VarIB.transform.parent = GameObject.Find("WorkSpace").transform;
        VarIB.transform.localPosition = Vector3.zero;
    }

    public void PlusInst()
    {
        GameObject PlusB;

        PlusB = (GameObject)Instantiate(PlusBlock);
        PlusB.transform.name += (count++);
        PlusB.transform.parent = GameObject.Find("WorkSpace").transform;
        PlusB.transform.localPosition = Vector3.zero;
    }

    public void MinusInst()
    {
        GameObject MinusB;

        MinusB = (GameObject)Instantiate(MinusBlock);
        MinusB.transform.name += (count++);
        MinusB.transform.parent = GameObject.Find("WorkSpace").transform;
        MinusB.transform.localPosition = Vector3.zero;
    }

    public void MultInst()
    {
        GameObject MultB;

        MultB = (GameObject)Instantiate(MultBlock);
        MultB.transform.name += (count++);
        MultB.transform.parent = GameObject.Find("WorkSpace").transform;
        MultB.transform.localPosition = Vector3.zero;
    }

    public void DivInst()
    {
        GameObject DivB;

        DivB = (GameObject)Instantiate(DivBlock);
        DivB.transform.name += (count++);
        DivB.transform.parent = GameObject.Find("WorkSpace").transform;
        DivB.transform.localPosition = Vector3.zero;
    }

    public void ModInst()
    {
        GameObject ModB;

        ModB = (GameObject)Instantiate(ModBlock);
        ModB.transform.name += (count++);
        ModB.transform.parent = GameObject.Find("WorkSpace").transform;
        ModB.transform.localPosition = Vector3.zero;
    }

    public void EqualInst()
    {
        GameObject EqualB;

        EqualB = (GameObject)Instantiate(EqaulBlock);
        EqualB.transform.name += (count++);
        EqualB.transform.parent = GameObject.Find("WorkSpace").transform;
        EqualB.transform.localPosition = Vector3.zero;
    }

    public void NotEqualnst()
    {
        GameObject NotEqualB;

        NotEqualB = (GameObject)Instantiate(NotEqualBlock);
        NotEqualB.transform.name += (count++);
        NotEqualB.transform.parent = GameObject.Find("WorkSpace").transform;
        NotEqualB.transform.localPosition = Vector3.zero;
    }

    public void NumberInst1()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number1);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst2()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number2);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst3()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number3);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst4()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number4);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst5()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number5);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst6()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number6);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst7()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number7);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst8()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number8);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst9()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number9);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
    public void NumberInst0()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number0);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
    }
}
