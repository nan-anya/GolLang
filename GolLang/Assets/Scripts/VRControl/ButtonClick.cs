using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    //Meta
    public GameObject StartHere;

    //Reserved Word
    public GameObject Reserved_For;
    public GameObject Reserved_If;
    public GameObject Reserved_ElseIf;
    public GameObject Reserved_Else;

    //Int and Bool Compare
    public GameObject Operator_Equal;
    public GameObject Operator_NotEqual;

    //Int only Compare
    public GameObject Operator_GT;
    public GameObject Operator_LT;
    public GameObject Operator_GE;
    public GameObject Operator_LE;

    //Calculate
    public GameObject Operator_Plus;
    public GameObject Operator_Minus;
    public GameObject Operator_Mul;
    public GameObject Operator_Div;
    public GameObject Operator_Mod;

    //Negative Num
    public GameObject Operator_Neg;

    //Logical
    public GameObject Operator_And;
    public GameObject Operator_Or;
    public GameObject Operator_Not;

    //Bracket
    public GameObject Operator_Bop;
    public GameObject Operator_Bcl;

    //Assignment
    public GameObject Operator_Ass;

    //ETC
    public GameObject Operator_Comma;

    //Const Int
    public GameObject Const_1;
    public GameObject Const_2;
    public GameObject Const_3;
    public GameObject Const_4;
    public GameObject Const_5;
    public GameObject Const_6;
    public GameObject Const_7;
    public GameObject Const_8;
    public GameObject Const_9;
    public GameObject Const_0;

    //Const Bool
    public GameObject Bool_True;
    public GameObject Bool_False;

    //Int Variable
    public GameObject Var_a;
    public GameObject Var_b;
    public GameObject Var_c;
    public GameObject Var_i;
    public GameObject Var_j;
    public GameObject Var_k;

    //Bool Variable
    public GameObject Var_w;
    public GameObject Var_x;
    public GameObject Var_y;
    public GameObject Var_z;

    //Function
    public GameObject Func_AttackMelee;
    public GameObject Func_AttackRange;
    public GameObject Func_Observe;
    public GameObject Func_Defence;
    public GameObject Func_EnergyCharge;
    public GameObject Func_BreakShield;
    public GameObject Func_Repair;



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
            case "StartHere":
                return StartHere;
            case "Reserved_For":
                return Reserved_For;
            case "Reserved_If":
                return Reserved_If;
            case "Reserved_ElseIf":
                return Reserved_ElseIf;
            case "Reserved_Else":
                return Reserved_Else;
            case "Operator_Equal":
                return Operator_Equal;
            case "Operator_NotEqual":
                return Operator_NotEqual;
            case "Operator_GT":
                return Operator_GT;
            case "Operator_LT":
                return Operator_LT;
            case "Operator_GE":
                return Operator_GE;
            case "Operator_LE":
                return Operator_LE;
            case "Operator_Plus":
                return Operator_Plus;
            case "Operator_Minus":
                return Operator_Minus;
            case "Operator_Mul":
                return Operator_Mul;
            case "Operator_Div":
                return Operator_Div;
            case "Operator_Mod":
                return Operator_Mod;
            case "Operator_Neg":
                return Operator_Neg;
            case "Operator_And":
                return Operator_And;
            case "Operator_Or":
                return Operator_Or;
            case "Operator_Not":
                return Operator_Not;
            case "Operator_Bop":
                return Operator_Bop;
            case "Operator_Bcl":
                return Operator_Bcl;
            case "Operator_Ass":
                return Operator_Ass;
            case "Operator_Comma":
                return Operator_Comma;
            case "Const_1":
                return Const_1;
            case "Const_2":
                return Const_2;
            case "Const_3":
                return Const_3;
            case "Const_4":
                return Const_4;
            case "Const_5":
                return Const_5;
            case "Const_6":
                return Const_6;
            case "Const_7":
                return Const_7;
            case "Const_8":
                return Const_8;
            case "Const_9":
                return Const_9;
            case "Const_0":
                return Const_0;
            case "Bool_True":
                return Bool_True;
            case "Bool_False":
                return Bool_False;
            case "Var_a":
                return Var_a;
            case "Var_b":
                return Var_b;
            case "Var_c":
                return Var_c;
            case "Var_i":
                return Var_i;
            case "Var_j":
                return Var_j;
            case "Var_k":
                return Var_k;
            case "Var_w":
                return Var_w;
            case "Var_x":
                return Var_x;
            case "Var_y":
                return Var_y;
            case "Var_z":
                return Var_z;
            case "Func_AttackMelee":
                return Func_AttackMelee;
            case "Func_AttackRange":
                return Func_AttackRange;
            case "Func_Observe":
                return Func_Observe;
            case "Func_Defence":
                return Func_Defence;
            case "Func_EnergyCharge":
                return Func_EnergyCharge;
            case "Func_BreakShield":
                return Func_BreakShield;
            case "Func_Repair":
                return Func_Repair;
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
        //NewBlock.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    /*
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
    */
}
