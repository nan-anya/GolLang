using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GolLangKeyword keyword;

    // For, If, ElseIF는 자식을 가질 수 있다
    bool canHaveChild;
    // 변수, 함수, 예약어 등은 형제를 가질수 있다. 즉 문장의 처음에 올 수 있다.
    // StartHere, 상수, 연산자 등은 문장의 처음에 올 수 없다.
    bool canHaveSibling;
    // Else, StartHere은 한 문장안에서 자신을 제외한 다른 키워드 들과 같이 있을 수 없다.
    bool canHaveRight;
    
    BlockLocation blockLoc;

    public BlockKind blockKind;

    public EditorNode node = null;
    


    //라인의 어디에 위치 하는가
    public enum BlockLocation {HEAD, MIDDLE, END, NULL}

    // GKeyword와 유사하나 모든 블록에 대한 코드를 가짐  
    public enum BlockKind 
    {
        //META
        STARTHERE,
        //Control
        FOR, IF, ELIF, ELSE,
        //Int and Bool Compare
        EQ, NEQ,
        //Int only Compare
        GT, LT, GE, LE,
        //Calculate
        PLUS, MINUS, MUL, DIV, MOD,
        //Negative Num
        NEG,
        //Logical
        AND, OR, NOT,
        //Bracket
        BOP, BCL,
        //Assignment
        ASS,
        //ETC
        COMMA,
        //Const Int
        CONSTI_0, CONSTI_1, CONSTI_2, CONSTI_3, CONSTI_4, CONSTI_5, CONSTI_6, CONSTI_7, CONSTI_8, CONSTI_9,
        //Const Bool
        CONSTB_TRUE, CONSTB_FALSE,
        //Int Variable
        VARI_a, VARI_b, VARI_c, VARI_i, VARI_j, VARI_k,
        //Bool Variable
        VARB_w, VARB_x, VARB_y, VARB_z,
        //Function
        FUNC_MELEEATTACK, FUNC_RANGEATTACK, FUNC_OBSERVE, FUNC_DEFENCE, FUNC_ENERGYCHARGE, FUNC_BREAKSHIELD, FUNC_REPAIR
    }

    public void Start()
    {

    }

    void initBlock(BlockKind blockKind)
    {
        switch (blockKind)
        {
            //META
            case BlockKind.STARTHERE:
                keyword = new GolLangKeyword(GKeyword.STARTHERE);
                canHaveChild = true;
                canHaveSibling = false;
                canHaveRight = false;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Control
            case BlockKind.FOR:
                keyword = new GolLangKeyword(GKeyword.FOR);
                canHaveChild = true;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.IF:
                keyword = new GolLangKeyword(GKeyword.IF);
                canHaveChild = true;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.ELIF:
                keyword = new GolLangKeyword(GKeyword.ELIF);
                canHaveChild = true;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.ELSE:
                keyword = new GolLangKeyword(GKeyword.ELSE);
                canHaveChild = true;
                canHaveSibling = true;
                canHaveRight = false;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Int and Bool Compare
            case BlockKind.EQ:
                keyword = new GolLangKeyword(GKeyword.EQ);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.NEQ:
                keyword = new GolLangKeyword(GKeyword.NEQ);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Int only Compare
            case BlockKind.GT:
                keyword = new GolLangKeyword(GKeyword.GT);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;
            case BlockKind.LT:
                keyword = new GolLangKeyword(GKeyword.LT);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.GE:
                keyword = new GolLangKeyword(GKeyword.GE);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.LE:
                keyword = new GolLangKeyword(GKeyword.LE);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;
           
            //Calculate
            case BlockKind.PLUS:
                keyword = new GolLangKeyword(GKeyword.PLUS);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;
            case BlockKind.MINUS:
                keyword = new GolLangKeyword(GKeyword.MINUS);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;
            case BlockKind.MUL:
                keyword = new GolLangKeyword(GKeyword.MUL);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;
            case BlockKind.DIV:
                keyword = new GolLangKeyword(GKeyword.DIV);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;
            case BlockKind.MOD:
                keyword = new GolLangKeyword(GKeyword.MOD);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Negative Num
            case BlockKind.NEG:
                keyword = new GolLangKeyword(GKeyword.NEG);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Logical
            case BlockKind.AND:
                keyword = new GolLangKeyword(GKeyword.AND);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.OR:
                keyword = new GolLangKeyword(GKeyword.OR);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.NOT:
                keyword = new GolLangKeyword(GKeyword.NOT);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Bracket
            case BlockKind.BOP:
                keyword = new GolLangKeyword(GKeyword.BOP);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.BCL:
                keyword = new GolLangKeyword(GKeyword.BCL);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Assignment
            case BlockKind.ASS:
                keyword = new GolLangKeyword(GKeyword.ASS);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;
            //ETC
            case BlockKind.COMMA:
                keyword = new GolLangKeyword(GKeyword.COMMA);
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Const Int
            case BlockKind.CONSTI_0:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "0");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_1:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "1");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_2:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "2");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_3:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "3");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_4:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "4");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_5:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "5");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_6:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "6");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_7:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "7");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_8:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "8");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_9:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "9");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Const Bool
            case BlockKind.CONSTB_TRUE:
                keyword = new GolLangKeyword(GKeyword.CONSTB, "1");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTB_FALSE:
                keyword = new GolLangKeyword(GKeyword.CONSTB, "0");
                canHaveChild = false;
                canHaveSibling = false;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Int Variable
            case BlockKind.VARI_a:
                keyword = new GolLangKeyword(GKeyword.VARI, "a");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_b:
                keyword = new GolLangKeyword(GKeyword.VARI, "b");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_c:
                keyword = new GolLangKeyword(GKeyword.VARI, "c");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_i:
                keyword = new GolLangKeyword(GKeyword.VARI, "i");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_j:
                keyword = new GolLangKeyword(GKeyword.VARI, "j");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_k:
                keyword = new GolLangKeyword(GKeyword.VARI, "k");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Bool Variable
            case BlockKind.VARB_w:
                keyword = new GolLangKeyword(GKeyword.VARB, "w");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.VARB_x:
                keyword = new GolLangKeyword(GKeyword.VARB, "x");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.VARB_y:
                keyword = new GolLangKeyword(GKeyword.VARB, "y");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.VARB_z:
                keyword = new GolLangKeyword(GKeyword.VARB, "z");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            //Function
            case BlockKind.FUNC_MELEEATTACK:
                keyword = new GolLangKeyword(GKeyword.FUNC, "MeleeAttack");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_RANGEATTACK:
                keyword = new GolLangKeyword(GKeyword.FUNC, "RangeAttack");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_OBSERVE:
                keyword = new GolLangKeyword(GKeyword.FUNC, "Observe");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_DEFENCE:
                keyword = new GolLangKeyword(GKeyword.FUNC, "Defence");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_ENERGYCHARGE:
                keyword = new GolLangKeyword(GKeyword.FUNC, "EnergyCharge");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_BREAKSHIELD:
                keyword = new GolLangKeyword(GKeyword.FUNC, "BreakShield");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_REPAIR:
                keyword = new GolLangKeyword(GKeyword.FUNC, "Repair");
                canHaveChild = false;
                canHaveSibling = true;
                canHaveRight = true;
                blockLoc = BlockLocation.NULL;
                this.blockKind = blockKind;
                break;
        }
    }

    public void rightTrigger(GameObject right)
    {
        Block b = right.GetComponent<Block>();

        MeshFilter m = b.GetComponent<MeshFilter>();

        float offset = 0.0f;

        switch (blockKind)
        {
            //Control
            case BlockKind.FOR:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }  
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.IF:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.ELIF:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Int and Bool Compare
            case BlockKind.EQ:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.NEQ:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Int only Compare
            case BlockKind.GT:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.LT:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.GE:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.LE:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Calculate
            case BlockKind.PLUS:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.MINUS:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.MUL:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.DIV:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.MOD:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Negative Num
            case BlockKind.NEG:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.NEG ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Logical
            case BlockKind.AND:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.OR:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.NOT:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Bracket
            case BlockKind.BOP:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.BCL:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Assignment
            case BlockKind.ASS:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;
            //ETC
            case BlockKind.COMMA:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                    b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                    b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                    b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                    b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Const Int
            case BlockKind.CONSTI_0:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_1:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_2:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_3:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_4:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_5:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_6:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_7:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_8:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTI_9:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Const Bool
            case BlockKind.CONSTB_TRUE:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.AND || b.blockKind == BlockKind.OR ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.CONSTB_FALSE:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.AND || b.blockKind == BlockKind.OR ||
                    b.blockKind == BlockKind.BCL)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Int Variable
            case BlockKind.VARI_a:
                
                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.VARI_b:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.VARI_c:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.VARI_i:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.VARI_j:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.VARI_k:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                    b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Bool Variable
            case BlockKind.VARB_w:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.AND || b.blockKind == BlockKind.OR ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.VARB_x:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.AND || b.blockKind == BlockKind.OR ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.VARB_y:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.AND || b.blockKind == BlockKind.OR ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.VARB_z:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.COMMA ||
                    b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                    b.blockKind == BlockKind.AND || b.blockKind == BlockKind.OR ||
                    b.blockKind == BlockKind.BCL ||
                    b.blockKind == BlockKind.ASS)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02
                            offset = 0.0508F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            //Function
            case BlockKind.FUNC_MELEEATTACK:

                //뒤에 붙일 수 있는 블록이면
                if (b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.FUNC_RANGEATTACK:

                if (b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.FUNC_OBSERVE:

                if (b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.FUNC_DEFENCE:

                if (b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.FUNC_ENERGYCHARGE:

                if (b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.FUNC_BREAKSHIELD:

                if (b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            case BlockKind.FUNC_REPAIR:

                if (b.blockKind == BlockKind.BOP)
                {
                    if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("SmallBlock"))
                    {
                        if (m.mesh.name.Equals("LongBlock1"))
                        {
                            //2.54 * 0.02 * 2
                            offset = 0.1016F;
                        }
                        else if (m.mesh.name.Equals("SmallBlock"))
                        {
                            //2.54 * 0.02 * 1.5
                            offset = 0.0762F;
                        }

                        right.transform.position = new Vector3(gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z);

                        node.attachBlockRight(this, right.GetComponent<Block>());

                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().attachable = false;
                        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().detachable = true;
                    }
                    //LongBlock2, LongBlock3는 다른 것의 뒤에 올 수 없음
                    else
                    {
                        Destroy(right);
                    }
                }
                else
                {
                    Destroy(right);
                }

                break;

            default :
                Destroy(right);
                
                break;
        }
    }

    public void childTrigger(GameObject child)
    {
        Block b = child.GetComponent<Block>();

        MeshFilter m = b.GetComponent<MeshFilter>();

        float offsetX = 0.0f;

        //2.54 * 0.02
        float offsetY = 0.0508f;

        if (b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
            b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
            b.blockKind == BlockKind.FOR || b.blockKind == BlockKind.IF ||
            b.blockKind == BlockKind.FUNC_BREAKSHIELD || b.blockKind == BlockKind.FUNC_DEFENCE || b.blockKind == BlockKind.FUNC_ENERGYCHARGE || b.blockKind == BlockKind.FUNC_MELEEATTACK || b.blockKind == BlockKind.FUNC_OBSERVE || b.blockKind == BlockKind.FUNC_RANGEATTACK || b.blockKind == BlockKind.FUNC_REPAIR)
        {
            MeshFilter thisMesh = gameObject.GetComponent<MeshFilter>();

            if (thisMesh.mesh.name.Equals("LongBlock2"))
            {
                if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("LongBlock2"))
                {
                    //2.54 * 0.02
                    offsetX = 0.0508F;
                }
                else if (m.mesh.name.Equals("SmallBlock"))
                {
                    //2.54 * 0.02 * 0.5
                    offsetX = 0.0254F;
                }
                child.transform.position = new Vector3(gameObject.transform.position.x - offsetX, gameObject.transform.position.y - offsetY, gameObject.transform.position.z);

                node.attachBlockChild(b);

                gameObject.transform.Find("ChildTrigger").GetComponent<CTrigger>().attachable = false;
                gameObject.transform.Find("ChildTrigger").GetComponent<CTrigger>().detachable = true;

                node.adjustSiblingTrigger();
            }
            else if (thisMesh.mesh.name.Equals("LongBlock3"))
            {
                if (m.mesh.name.Equals("LongBlock1") || m.mesh.name.Equals("LongBlock2"))
                {
                    //2.54 * 0.02 * 1.25
                    offsetX = 0.0635F;
                }
                else if (m.mesh.name.Equals("SmallBlock"))
                {
                    //2.54 * 0.02 * 0.75
                    offsetX = 0.0381F;
                }
                child.transform.position = new Vector3(gameObject.transform.position.x - offsetX, gameObject.transform.position.y - offsetY, gameObject.transform.position.z);

                node.attachBlockChild(b);

                gameObject.transform.Find("ChildTrigger").GetComponent<CTrigger>().attachable = false;
                gameObject.transform.Find("ChildTrigger").GetComponent<CTrigger>().detachable = true;

                node.adjustSiblingTrigger();
            }
            //LongBlock1과 SmallBlock인 블록은 자식을 가질 수 없다.
            else
            {
                Destroy(child);
            }
        }
        else
        {
            Destroy(child);
        }
    }

    public void siblingTrigger(GameObject sibling)
    {
        Block b = sibling.GetComponent<Block>();

        MeshFilter m = b.GetComponent<MeshFilter>();

        float offsetX = 0.0f;

        //2.54 * 0.02
        float offsetY = 0.0508f;

        if (b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
            b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
            b.blockKind == BlockKind.FOR || b.blockKind == BlockKind.IF || b.blockKind == BlockKind.ELIF || b.blockKind == BlockKind.ELSE ||
            b.blockKind == BlockKind.FUNC_BREAKSHIELD || b.blockKind == BlockKind.FUNC_DEFENCE || b.blockKind == BlockKind.FUNC_ENERGYCHARGE || b.blockKind == BlockKind.FUNC_MELEEATTACK || b.blockKind == BlockKind.FUNC_OBSERVE || b.blockKind == BlockKind.FUNC_RANGEATTACK || b.blockKind == BlockKind.FUNC_REPAIR)
        {
            MeshFilter thisMesh = gameObject.GetComponent<MeshFilter>();

            if (thisMesh.mesh.name.Equals("LongBlock1") || thisMesh.mesh.name.Equals("LongBlock2"))
            {
                if (m.mesh.name.Equals("LongBlock1") || thisMesh.mesh.name.Equals("LongBlock2"))
                {
                    offsetX = 0.0f;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else if (m.mesh.name.Equals("LongBlock3"))
                {
                    //2.54 8 0.02 * 0.25
                    offsetX = -0.0127f;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else if (m.mesh.name.Equals("SmallBlock"))
                {
                    //2.54 8 0.02 * 0.5
                    offsetX = -0.0254f;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else
                {
                    Destroy(sibling);
                }
            }
            else if (thisMesh.mesh.name.Equals("LongBlock3"))
            {
                if (m.mesh.name.Equals("LongBlock1") || thisMesh.mesh.name.Equals("LongBlock2"))
                {
                    //2.54 8 0.02 * 0.25
                    offsetX = 0.0127f;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else if (m.mesh.name.Equals("LongBlock3"))
                {
                    offsetX = 0;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else if (m.mesh.name.Equals("SmallBlock"))
                {
                    //2.54 8 0.02 * 0.25
                    offsetX = -0.0127f;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else
                {
                    Destroy(sibling);
                }
            }
            else if (thisMesh.mesh.name.Equals("SmallBlock"))
            {
                if (m.mesh.name.Equals("LongBlock1") || thisMesh.mesh.name.Equals("LongBlock2"))
                {
                    //2.54 8 0.02 * 0.5
                    offsetX = 0.0254f;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else if (m.mesh.name.Equals("LongBlock3"))
                {
                    //2.54 8 0.02 * 0.25
                    offsetX = 0.0127f;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else if (m.mesh.name.Equals("SmallBlock"))
                {
                    offsetX = 0;

                    //2.54 * 0.02 * height
                    offsetY = 0.0508f * node.height();
                }
                else
                {
                    Destroy(sibling);
                }
            }
            else
            {
                Destroy(sibling);
            }

            sibling.transform.position = new Vector3(gameObject.transform.position.x - offsetX, gameObject.transform.position.y - offsetY, gameObject.transform.position.z);

            gameObject.transform.Find("SiblingTrigger").GetComponent<STrigger>().attachable = false;
            gameObject.transform.Find("SiblingTrigger").GetComponent<STrigger>().detachable = true;

            node.attachBlockSibling(b);

        }
        else
        {
            Destroy(sibling);
        }
    }
}

/*
 switch (blockKind)
        {
            //META
            case BlockKind.STARTHERE:
                
                break;

            //Control
            case BlockKind.FOR:
                
                break;

            case BlockKind.IF:
                
                break;

            case BlockKind.ELIF:
                
                break;

            case BlockKind.ELSE:
                
                break;

            //Int and Bool Compare
            case BlockKind.EQ:
                
                break;

            case BlockKind.NEQ:
                
                break;

            //Int only Compare
            case BlockKind.GT:
                
                break;
            case BlockKind.LT:
                
                break;

            case BlockKind.GE:
                
                break;

            case BlockKind.LE:
                
                break;

            //Calculate
            case BlockKind.PLUS:
                
                break;
            case BlockKind.MINUS:
                
                break;
            case BlockKind.MUL:
                
                break;
            case BlockKind.DIV:
                
                break;
            case BlockKind.MOD:
                
                break;

            //Negative Num
            case BlockKind.NEG:
                
                break;

            //Logical
            case BlockKind.AND:
                
                break;

            case BlockKind.OR:
                
                break;

            case BlockKind.NOT:
                
                break;

            //Bracket
            case BlockKind.BOP:
                
                break;

            case BlockKind.BCL:
                
                break;

            //Assignment
            case BlockKind.ASS:
                
                break;
            //ETC
            case BlockKind.COMMA:
                
                break;

            //Const Int
            case BlockKind.CONSTI_0:
                
                break;

            case BlockKind.CONSTI_1:
                
                break;

            case BlockKind.CONSTI_2:
                
                break;

            case BlockKind.CONSTI_3:
                
                break;

            case BlockKind.CONSTI_4:
                
                break;

            case BlockKind.CONSTI_5:
                
                break;

            case BlockKind.CONSTI_6:
                
                break;

            case BlockKind.CONSTI_7:
                
                break;

            case BlockKind.CONSTI_8:
                
                break;

            case BlockKind.CONSTI_9:
                
                break;

            //Const Bool
            case BlockKind.CONSTB_TRUE:
                
                break;

            case BlockKind.CONSTB_FALSE:
                
                break;

            //Int Variable
            case BlockKind.VARI_a:
                
                break;

            case BlockKind.VARI_b:
                
                break;

            case BlockKind.VARI_c:
                
                break;

            case BlockKind.VARI_i:
                
                break;

            case BlockKind.VARI_j:
                
                break;

            case BlockKind.VARI_k:
                
                break;

            //Bool Variable
            case BlockKind.VARB_w:
                
                break;

            case BlockKind.VARB_x:
                
                break;

            case BlockKind.VARB_y:
                
                break;

            case BlockKind.VARB_z:
                
                break;

            //Function
            case BlockKind.FUNC_MELEEATTACK:
                
                break;

            case BlockKind.FUNC_RANGEATTACK:
                
                break;

            case BlockKind.FUNC_OBSERVE:
                
                break;

            case BlockKind.FUNC_DEFENCE:
                
                break;

            case BlockKind.FUNC_ENERGYCHARGE:
                
                break;

            case BlockKind.FUNC_BREAKSHIELD:
                
                break;

            case BlockKind.FUNC_REPAIR:
                
                break;
        }
     */
