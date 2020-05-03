using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject ForStartBlock;
    public GameObject IfStartBlock;
    public GameObject ElseBlock;
    public GameObject PlusBlock;
    public GameObject MinusBlock;
    public GameObject MultBlock;
    public GameObject DivBlock;
    public GameObject EqualBlock;
    public GameObject NotEqualBlock;
    public GameObject ModBlock;

    public GameObject Attack01Block;
    public GameObject Attack02Block;
    public GameObject Attack03Block;

    public GameObject IBlock;
    public GameObject JBlock;
    public GameObject KBlock;
    public GameObject ABlock;
    public GameObject BBlock;
    public GameObject CBlock;

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

    List<GameObject> blockList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject CheckBlock(string blockName)
    {
        switch(blockName)
        {
            case "For":
                return ForStartBlock;
            case "If":
                return IfStartBlock;
            case "Else":
                return ElseBlock;
            case "Plus":
                return PlusBlock;
            case "Minus":
                return MinusBlock;
            case "Mult":
                return MultBlock;
            case "Div":
                return DivBlock;
            case "Equal":
                return EqualBlock;
            case "NotEqual":
                return NotEqualBlock;
            case "Mod":
                return ModBlock;
            case "Attack01":
                return Attack01Block;
            case "Attack02":
                return Attack02Block;
            case "Attack03":
                return Attack03Block;
            case "IBlock":
                return IBlock;
            case "JBlock":
                return JBlock;
            case "KBlock":
                return KBlock;
            case "ABlock":
                return ABlock;
            case "BBlock":
                return BBlock;
            case "CBlock":
                return CBlock;
            case "Number0":
                return Number0;
            case "Number1":
                return Number1;
            case "Number2":
                return Number2;
            case "Number3":
                return Number3;
            case "Number4":
                return Number4;
            case "Number5":
                return Number5;
            case "Number6":
                return Number6;
            case "Number7":
                return Number7;
            case "Number8":
                return Number8;
            case "Number9":
                return Number9;
        }
        return null;
    }

    public void GenerateBlock(string name)
    {
        Debug.Log(name + " Block");

        GameObject NewBlock;
        GameObject TargetBlock = CheckBlock(name);

        NewBlock = (GameObject)Instantiate(TargetBlock);
        NewBlock.transform.name += (count++);
        NewBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NewBlock.transform.localPosition = Vector3.zero;
        NewBlock.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
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
        ForBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void IfStartInst()
    {
        GameObject IfBlock;

        IfBlock = (GameObject)Instantiate(IfStartBlock);
        IfBlock.transform.name += (count++);
        IfBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        IfBlock.transform.localPosition = Vector3.zero;
        IfBlock.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void ElseInst()
    {
        GameObject ElseB;

        ElseB = (GameObject)Instantiate(ElseBlock);
        ElseB.transform.name += (count++);
        ElseB.transform.parent = GameObject.Find("WorkSpace").transform;
        ElseB.transform.localPosition = Vector3.zero;
        ElseB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void AttackKickInst()
    {
        GameObject AttackKB;

        AttackKB = (GameObject)Instantiate(Attack01Block);
        AttackKB.transform.name += (count++);
        AttackKB.transform.parent = GameObject.Find("WorkSpace").transform;
        AttackKB.transform.localPosition = Vector3.zero;
        AttackKB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void VarIBlockInst()
    {
        GameObject VarIB;

        Debug.Log("I BLOCK");

        VarIB = (GameObject)Instantiate(IBlock);
        VarIB.transform.name += (count++);
        VarIB.transform.parent = GameObject.Find("WorkSpace").transform;
        VarIB.transform.localPosition = Vector3.zero;
        VarIB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void PlusInst()
    {
        GameObject PlusB;

        PlusB = (GameObject)Instantiate(PlusBlock);
        PlusB.transform.name += (count++);
        PlusB.transform.parent = GameObject.Find("WorkSpace").transform;
        PlusB.transform.localPosition = Vector3.zero;
        PlusB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void MinusInst()
    {
        GameObject MinusB;

        MinusB = (GameObject)Instantiate(MinusBlock);
        MinusB.transform.name += (count++);
        MinusB.transform.parent = GameObject.Find("WorkSpace").transform;
        MinusB.transform.localPosition = Vector3.zero;
        MinusB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void MultInst()
    {
        GameObject MultB;

        MultB = (GameObject)Instantiate(MultBlock);
        MultB.transform.name += (count++);
        MultB.transform.parent = GameObject.Find("WorkSpace").transform;
        MultB.transform.localPosition = Vector3.zero;
        MultB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void DivInst()
    {
        GameObject DivB;

        DivB = (GameObject)Instantiate(DivBlock);
        DivB.transform.name += (count++);
        DivB.transform.parent = GameObject.Find("WorkSpace").transform;
        DivB.transform.localPosition = Vector3.zero;
        DivB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void ModInst()
    {
        GameObject ModB;

        ModB = (GameObject)Instantiate(ModBlock);
        ModB.transform.name += (count++);
        ModB.transform.parent = GameObject.Find("WorkSpace").transform;
        ModB.transform.localPosition = Vector3.zero;
        ModB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void EqualInst()
    {
        GameObject EqualB;

        EqualB = (GameObject)Instantiate(EqualBlock);
        EqualB.transform.name += (count++);
        EqualB.transform.parent = GameObject.Find("WorkSpace").transform;
        EqualB.transform.localPosition = Vector3.zero;
        EqualB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void NotEqualnst()
    {
        GameObject NotEqualB;

        NotEqualB = (GameObject)Instantiate(NotEqualBlock);
        NotEqualB.transform.name += (count++);
        NotEqualB.transform.parent = GameObject.Find("WorkSpace").transform;
        NotEqualB.transform.localPosition = Vector3.zero;
        NotEqualB.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void NumberInst1()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number1);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst2()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number2);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst3()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number3);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst4()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number4);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst5()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number5);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst6()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number6);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst7()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number7);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst8()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number8);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst9()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number9);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void NumberInst0()
    {
        GameObject NumberBlock;

        NumberBlock = (GameObject)Instantiate(Number0);
        NumberBlock.transform.name += (count++);
        NumberBlock.transform.parent = GameObject.Find("WorkSpace").transform;
        NumberBlock.transform.localPosition = Vector3.zero;
        NumberBlock.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
