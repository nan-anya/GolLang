using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    //Reserved Word
    public GameObject ForBlock;
    public GameObject IfBlock;
    public GameObject ElseIfBlock;
    public GameObject ElseBlock;

    //Int and Bool Compare
    public GameObject EqualBlock;
    public GameObject NotEqualBlock;

    //Int only Compare
    public GameObject GreaterThenBlock;
    public GameObject LessThenBlock;
    public GameObject GreaterEqualBlock;
    public GameObject LessEqualBlock;

    //Calculate
    public GameObject PlusBlock;
    public GameObject MinusBlock;
    public GameObject MulBlock;
    public GameObject DivBlock;
    public GameObject ModBlock;

    //Negative Num
    public GameObject NegativeBlock;

    //Logical
    public GameObject AndBlock;
    public GameObject OrBlock;
    public GameObject NotBlock;

    //Bracket
    public GameObject BracketOpenBlock;
    public GameObject BracketCloseBlock;

    //Assignment
    public GameObject AssignmentBlock;

    //ETC
    public GameObject CommaBlock;

    //Const Int
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

    //Const Bool
    public GameObject BoolTrueBlock;
    public GameObject BoolFalseBlock;

    //Int Variable
    public GameObject IntVarABlock;
    public GameObject IntVarBBlock;
    public GameObject IntVarCBlock;
    public GameObject IntVarIBlock;
    public GameObject IntVarJBlock;
    public GameObject IntVarKBlock;

    //Bool Variable
    public GameObject BoolVarWBlock;
    public GameObject BoolVarXBlock;
    public GameObject BoolVarYBlock;
    public GameObject BoolVarZBlock;

    //Function
    public GameObject FuncMeleeAttackBlock;
    public GameObject FuncRangeAttackBlock;
    public GameObject FuncObserveBlock;
    public GameObject FuncDefenceBlock;
    public GameObject FuncEnergyChargeBlock;
    public GameObject FuncBreakShieldBlock;
    public GameObject FuncRepairBlock;



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
            case "ForBlock":
                return ForBlock;
            case "IfBlock":
                return IfBlock;
            case "ElseIfBlock":
                return ElseIfBlock;
            case "ElseBlock":
                return ElseBlock;
            case "EqualBlock":
                return EqualBlock;
            case "NotEqualBlock":
                return NotEqualBlock;
            case "GreaterThenBlock":
                return GreaterThenBlock;
            case "LessThenBlock":
                return LessThenBlock;
            case "GreaterEqualBlock":
                return GreaterEqualBlock;
            case "LessEqualBlock":
                return LessEqualBlock;
            case "PlusBlock":
                return PlusBlock;
            case "MinusBlock":
                return MinusBlock;
            case "MulBlock":
                return MulBlock;
            case "DivBlock":
                return DivBlock;
            case "ModBlock":
                return ModBlock;
            case "NegativeBlock":
                return NegativeBlock;
            case "AndBlock":
                return AndBlock;
            case "OrBlock":
                return OrBlock;
            case "NotBlock":
                return NotBlock;
            case "BracketOpenBlock":
                return BracketOpenBlock;
            case "BracketCloseBlock":
                return BracketCloseBlock;
            case "AssignmentBlock":
                return AssignmentBlock;
            case "CommaBlock":
                return CommaBlock;
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
            case "Number0":
                return Number0;
            case "BoolTrueBlock":
                return BoolTrueBlock;
            case "BoolFalseBlock":
                return BoolFalseBlock;
            case "IntVarABlock":
                return IntVarABlock;
            case "IntVarBBlock":
                return IntVarBBlock;
            case "IntVarCBlock":
                return IntVarCBlock;
            case "IntVarIBlock":
                return IntVarIBlock;
            case "IntVarJBlock":
                return IntVarJBlock;
            case "IntVarKBlock":
                return IntVarKBlock;
            case "BoolVarWBlock":
                return BoolVarWBlock;
            case "BoolVarXBlock":
                return BoolVarXBlock;
            case "BoolVarYBlock":
                return BoolVarYBlock;
            case "BoolVarZBlock":
                return BoolVarZBlock;
            case "FuncMeleeAttackBlock":
                return FuncMeleeAttackBlock;
            case "FuncRangeAttackBlock":
                return FuncRangeAttackBlock;
            case "FuncObserveBlock":
                return FuncObserveBlock;
            case "FuncDefenceBlock":
                return FuncDefenceBlock;
            case "FuncEnergyChargeBlock":
                return FuncEnergyChargeBlock;
            case "FuncBreakShieldBlock":
                return FuncBreakShieldBlock;
            case "FuncRepairBlock":
                return FuncRepairBlock;
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
<<<<<<< HEAD
        //NewBlock.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));

        switch (name)
        {
            case "StartHere":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.STARTHERE);
                break;
            case "Reserved_For":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.FOR);
                break;
            case "Reserved_If":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.IF);
                break;
            case "Reserved_ElseIf":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.ELIF);
                break;
            case "Reserved_Else":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.ELSE);
                break;
            case "Operator_Equal":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.EQ);
                break;
            case "Operator_NotEqual":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.NEQ);
                break;
            case "Operator_GT":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.GT);
                break;
            case "Operator_LT":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.LT);
                break;
            case "Operator_GE":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.GE);
                break;
            case "Operator_LE":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.LE);
                break;
            case "Operator_Plus":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.PLUS);
                break;
            case "Operator_Minus":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.MINUS);
                break;
            case "Operator_Mul":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.MUL);
                break;
            case "Operator_Div":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.DIV);
                break;
            case "Operator_Mod":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.MOD);
                break;
            case "Operator_Neg":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.NEG);
                break;
            case "Operator_And":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.AND);
                break;
            case "Operator_Or":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.OR);
                break;
            case "Operator_Not":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.NOT);
                break;
            case "Operator_Bop":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.BOP);
                break;
            case "Operator_Bcl":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.BCL);
                break;
            case "Operator_Ass":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.ASS);
                break;
            case "Operator_Comma":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.COMMA);
                break;
            case "Const_1":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_1);
                break;
            case "Const_2":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_2);
                break;
            case "Const_3":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_3);
                break;
            case "Const_4":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_4);
                break;
            case "Const_5":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_5);
                break;
            case "Const_6":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_6);
                break;
            case "Const_7":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_7);
                break;
            case "Const_8":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_8);
                break;
            case "Const_9":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_9);
                break;
            case "Const_0":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTI_0);
                break;
            case "Bool_True":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTB_TRUE);
                break;
            case "Bool_False":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.CONSTB_FALSE);
                break;
            case "Var_a":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARI_a);
                break;
            case "Var_b":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARI_b);
                break;
            case "Var_c":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARI_c);
                break;
            case "Var_i":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARI_i);
                break;
            case "Var_j":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARI_j);
                break;
            case "Var_k":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARI_k);
                break;
            case "Var_w":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARB_w);
                break;
            case "Var_x":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARB_x);
                break;
            case "Var_y":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARB_y);
                break;
            case "Var_z":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.VARB_z);
                break;
            case "Func_AttackMelee":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.FUNC_MELEEATTACK);
                break;
            case "Func_AttackRange":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.FUNC_RANGEATTACK);
                break;
            case "Func_Observe":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.FUNC_OBSERVE);
                break;
            case "Func_Defence":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.FUNC_DEFENCE);
                break;
            case "Func_EnergyCharge":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.FUNC_ENERGYCHARGE);
                break;
            case "Func_BreakShield":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.FUNC_BREAKSHIELD);
                break;
            case "Func_Repair":
                NewBlock.GetComponent<Block>().initBlock(Block.BlockKind.FUNC_REPAIR);
                break;
        }
=======
        NewBlock.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
>>>>>>> b853c034b748469a3556853efa0abb90b9dddaf8
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
