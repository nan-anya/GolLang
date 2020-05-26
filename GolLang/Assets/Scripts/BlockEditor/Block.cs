using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GolLangKeyword keyword;

    public BlockKind blockKind;

    public EditorNode node = null;

    public bool haveChild = false;
    public bool haveSibling = false;
    public bool haveRight = false;

    public bool inMiddle = false;

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
        FUNC_MELEEATTACK, FUNC_RANGEATTACK, FUNC_OBSERVE, FUNC_DEFENCE, FUNC_ENERGYCHARGE, FUNC_BREAKSHIELD, FUNC_REPAIR, FUNC_GOLEMENERGY
    }

    public void Start()
    {

    }

    public void initBlock(BlockKind blockKind)
    {
        switch (blockKind)
        {
            //META
            case BlockKind.STARTHERE:
                keyword = new GolLangKeyword(GKeyword.STARTHERE);
                this.blockKind = blockKind;
                break;

            //Control
            case BlockKind.FOR:
                keyword = new GolLangKeyword(GKeyword.FOR);
                this.blockKind = blockKind;
                break;

            case BlockKind.IF:
                keyword = new GolLangKeyword(GKeyword.IF);
                this.blockKind = blockKind;
                break;

            case BlockKind.ELIF:
                keyword = new GolLangKeyword(GKeyword.ELIF);
                this.blockKind = blockKind;
                break;

            case BlockKind.ELSE:
                keyword = new GolLangKeyword(GKeyword.ELSE);       
                this.blockKind = blockKind;
                break;

            //Int and Bool Compare
            case BlockKind.EQ:
                keyword = new GolLangKeyword(GKeyword.EQ);
                this.blockKind = blockKind;
                break;

            case BlockKind.NEQ:
                keyword = new GolLangKeyword(GKeyword.NEQ);
                this.blockKind = blockKind;
                break;

            //Int only Compare
            case BlockKind.GT:
                keyword = new GolLangKeyword(GKeyword.GT);
                this.blockKind = blockKind;
                break;

            case BlockKind.LT:
                keyword = new GolLangKeyword(GKeyword.LT);
                this.blockKind = blockKind;
                break;

            case BlockKind.GE:
                keyword = new GolLangKeyword(GKeyword.GE);
                this.blockKind = blockKind;
                break;

            case BlockKind.LE:
                keyword = new GolLangKeyword(GKeyword.LE);
                this.blockKind = blockKind;
                break;
           
            //Calculate
            case BlockKind.PLUS:
                keyword = new GolLangKeyword(GKeyword.PLUS);
                this.blockKind = blockKind;
                break;

            case BlockKind.MINUS:
                keyword = new GolLangKeyword(GKeyword.MINUS);
                this.blockKind = blockKind;
                break;

            case BlockKind.MUL:
                keyword = new GolLangKeyword(GKeyword.MUL);
                this.blockKind = blockKind;
                break;

            case BlockKind.DIV:
                keyword = new GolLangKeyword(GKeyword.DIV);
                this.blockKind = blockKind;
                break;

            case BlockKind.MOD:
                keyword = new GolLangKeyword(GKeyword.MOD);
                this.blockKind = blockKind;
                break;

            //Negative Num
            case BlockKind.NEG:
                keyword = new GolLangKeyword(GKeyword.NEG);
                this.blockKind = blockKind;
                break;

            //Logical
            case BlockKind.AND:
                keyword = new GolLangKeyword(GKeyword.AND);
                this.blockKind = blockKind;
                break;

            case BlockKind.OR:
                keyword = new GolLangKeyword(GKeyword.OR);
                this.blockKind = blockKind;
                break;

            case BlockKind.NOT:
                keyword = new GolLangKeyword(GKeyword.NOT);
                this.blockKind = blockKind;
                break;

            //Bracket
            case BlockKind.BOP:
                keyword = new GolLangKeyword(GKeyword.BOP);
                this.blockKind = blockKind;
                break;

            case BlockKind.BCL:
                keyword = new GolLangKeyword(GKeyword.BCL);
                this.blockKind = blockKind;
                break;

            //Assignment
            case BlockKind.ASS:
                keyword = new GolLangKeyword(GKeyword.ASS);
                this.blockKind = blockKind;
                break;

            //ETC
            case BlockKind.COMMA:
                keyword = new GolLangKeyword(GKeyword.COMMA);
                this.blockKind = blockKind;
                break;

            //Const Int
            case BlockKind.CONSTI_0:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "0");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_1:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "1");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_2:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "2");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_3:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "3");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_4:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "4");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_5:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "5");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_6:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "6");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_7:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "7");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_8:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "8");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTI_9:
                keyword = new GolLangKeyword(GKeyword.CONSTI, "9");
                this.blockKind = blockKind;
                break;

            //Const Bool
            case BlockKind.CONSTB_TRUE:
                keyword = new GolLangKeyword(GKeyword.CONSTB, "1");
                this.blockKind = blockKind;
                break;

            case BlockKind.CONSTB_FALSE:
                keyword = new GolLangKeyword(GKeyword.CONSTB, "0");
                this.blockKind = blockKind;
                break;

            //Int Variable
            case BlockKind.VARI_a:
                keyword = new GolLangKeyword(GKeyword.VARI, "a");
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_b:
                keyword = new GolLangKeyword(GKeyword.VARI, "b");
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_c:
                keyword = new GolLangKeyword(GKeyword.VARI, "c");
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_i:
                keyword = new GolLangKeyword(GKeyword.VARI, "i");
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_j:
                keyword = new GolLangKeyword(GKeyword.VARI, "j");
                this.blockKind = blockKind;
                break;

            case BlockKind.VARI_k:
                keyword = new GolLangKeyword(GKeyword.VARI, "k");
                this.blockKind = blockKind;
                break;

            //Bool Variable
            case BlockKind.VARB_w:
                keyword = new GolLangKeyword(GKeyword.VARB, "w");
                this.blockKind = blockKind;
                break;

            case BlockKind.VARB_x:
                keyword = new GolLangKeyword(GKeyword.VARB, "x");
                this.blockKind = blockKind;
                break;

            case BlockKind.VARB_y:
                keyword = new GolLangKeyword(GKeyword.VARB, "y");
                this.blockKind = blockKind;
                break;

            case BlockKind.VARB_z:
                keyword = new GolLangKeyword(GKeyword.VARB, "z");
                this.blockKind = blockKind;
                break;

            //Function
            case BlockKind.FUNC_MELEEATTACK:
                keyword = new GolLangKeyword(GKeyword.FUNC, "MeleeAttack");
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_RANGEATTACK:
                keyword = new GolLangKeyword(GKeyword.FUNC, "RangeAttack");
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_OBSERVE:
                keyword = new GolLangKeyword(GKeyword.FUNC, "Observe");
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_DEFENCE:
                keyword = new GolLangKeyword(GKeyword.FUNC, "Defence");
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_ENERGYCHARGE:
                keyword = new GolLangKeyword(GKeyword.FUNC, "EnergyCharge");
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_BREAKSHIELD:
                keyword = new GolLangKeyword(GKeyword.FUNC, "BreakShield");
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_REPAIR:
                keyword = new GolLangKeyword(GKeyword.FUNC, "Repair");
                this.blockKind = blockKind;
                break;

            case BlockKind.FUNC_GOLEMENERGY:
                keyword = new GolLangKeyword(GKeyword.FUNC, "GolemEnergy");
                this.blockKind = blockKind;
                break;
        }
    }

    public void rightTriggerIn(GameObject right)
    {
        if(right.transform.Find("ChildTrigger") != null)
        {
            right.transform.Find("ChildTrigger").gameObject.SetActive(true);
        }
        if (right.transform.Find("RightTrigger") != null)
        {
            right.transform.Find("RightTrigger").gameObject.SetActive(true);
        }
        if (right.transform.Find("SiblingTrigger") != null)
        {
            right.transform.Find("SiblingTrigger").gameObject.SetActive(true);
        }

        Block b = right.GetComponent<Block>();

        MeshFilter m = b.GetComponent<MeshFilter>();

        float offset = 0.0f;

        //Control
        if (blockKind == BlockKind.FOR || blockKind == BlockKind.IF || blockKind == BlockKind.ELIF)
        {
            // 뒤에 붙일 수 있는 블록이면
            if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                b.blockKind == BlockKind.BOP ||
                b.blockKind == BlockKind.FUNC_GOLEMENERGY || b.blockKind == BlockKind.FUNC_OBSERVE)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        //2.54 * 20 * 2
                        offset = 101.6F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        //2.54 * 20 * 1.5
                        offset = 76.2F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
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
        }
        //Int and Bool Compare
        else if (blockKind == BlockKind.EQ || blockKind == BlockKind.NEQ)
        {
            if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                b.blockKind == BlockKind.BOP ||
                b.blockKind == BlockKind.FUNC_GOLEMENERGY || b.blockKind == BlockKind.FUNC_OBSERVE)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Int only Compare
        //Int Calculate
        //Negative Num
        else if (blockKind == BlockKind.GT || blockKind == BlockKind.LT || blockKind == BlockKind.GE || blockKind == BlockKind.LE ||
                 blockKind == BlockKind.PLUS || blockKind == BlockKind.MINUS || blockKind == BlockKind.MUL || blockKind == BlockKind.DIV || blockKind == BlockKind.MOD ||
                 blockKind == BlockKind.NEG)
        {
            if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                b.blockKind == BlockKind.NEG ||
                b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                b.blockKind == BlockKind.BOP ||
                b.blockKind == BlockKind.FUNC_GOLEMENERGY || b.blockKind == BlockKind.FUNC_OBSERVE)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Logical
        else if (blockKind == BlockKind.AND || blockKind == BlockKind.OR || blockKind == BlockKind.NOT)
        {
            if (b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                b.blockKind == BlockKind.NOT ||
                b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                b.blockKind == BlockKind.BOP)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Bracket open
        else if (blockKind == BlockKind.BOP)
        {
            if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                b.blockKind == BlockKind.BOP ||
                b.blockKind == BlockKind.FUNC_GOLEMENERGY || b.blockKind == BlockKind.FUNC_OBSERVE)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Bracket close
        else if (blockKind == BlockKind.BCL)
        {
            if (b.blockKind == BlockKind.COMMA ||
                b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                b.blockKind == BlockKind.BCL)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Assignment
        //Comma
        else if (blockKind == BlockKind.ASS ||
                 blockKind == BlockKind.COMMA)
        {
            if (b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                b.blockKind == BlockKind.CONSTB_FALSE || b.blockKind == BlockKind.CONSTB_TRUE ||
                b.blockKind == BlockKind.NEG || b.blockKind == BlockKind.NOT ||
                b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
                b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
                b.blockKind == BlockKind.BOP ||
                b.blockKind == BlockKind.FUNC_GOLEMENERGY || b.blockKind == BlockKind.FUNC_OBSERVE)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Const Int
        else if (blockKind == BlockKind.CONSTI_0 || blockKind == BlockKind.CONSTI_1 || blockKind == BlockKind.CONSTI_2 || blockKind == BlockKind.CONSTI_3 || blockKind == BlockKind.CONSTI_4 || blockKind == BlockKind.CONSTI_5 || blockKind == BlockKind.CONSTI_6 || blockKind == BlockKind.CONSTI_7 || blockKind == BlockKind.CONSTI_8 || blockKind == BlockKind.CONSTI_9)
        {
            if (b.blockKind == BlockKind.COMMA ||
                b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                b.blockKind == BlockKind.BCL)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Const Bool
        else if (blockKind == BlockKind.CONSTB_TRUE || blockKind == BlockKind.CONSTB_FALSE)
        {
            if (b.blockKind == BlockKind.COMMA ||
                b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                b.blockKind == BlockKind.AND || b.blockKind == BlockKind.OR ||
                b.blockKind == BlockKind.BCL)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Int Variable
        else if (blockKind == BlockKind.VARI_a || blockKind == BlockKind.VARI_b || blockKind == BlockKind.VARI_c || blockKind == BlockKind.VARI_i || blockKind == BlockKind.VARI_j || blockKind == BlockKind.VARI_k)
        {
            if (b.blockKind == BlockKind.COMMA ||
                b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                b.blockKind == BlockKind.BCL ||
                b.blockKind == BlockKind.ASS)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Bool Variable
        else if (blockKind == BlockKind.VARB_w || blockKind == BlockKind.VARB_x || blockKind == BlockKind.VARB_y || blockKind == BlockKind.VARB_z)
        {
            if (b.blockKind == BlockKind.COMMA ||
                b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                b.blockKind == BlockKind.AND || b.blockKind == BlockKind.OR ||
                b.blockKind == BlockKind.BCL ||
                b.blockKind == BlockKind.ASS)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 76.2F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 50.8F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        //Function
        else if (blockKind == BlockKind.FUNC_MELEEATTACK || blockKind == BlockKind.FUNC_RANGEATTACK || blockKind == BlockKind.FUNC_DEFENCE || blockKind == BlockKind.FUNC_ENERGYCHARGE || blockKind == BlockKind.FUNC_BREAKSHIELD || blockKind == BlockKind.FUNC_REPAIR)
        {
            if (b.blockKind == BlockKind.BOP)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 101.6F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 76.2F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }
        else if ( blockKind == BlockKind.FUNC_OBSERVE || blockKind == BlockKind.FUNC_GOLEMENERGY)
        {
            if (b.blockKind == BlockKind.COMMA ||
                b.blockKind == BlockKind.CONSTI_0 || b.blockKind == BlockKind.CONSTI_1 || b.blockKind == BlockKind.CONSTI_2 || b.blockKind == BlockKind.CONSTI_3 || b.blockKind == BlockKind.CONSTI_4 || b.blockKind == BlockKind.CONSTI_5 || b.blockKind == BlockKind.CONSTI_6 || b.blockKind == BlockKind.CONSTI_7 || b.blockKind == BlockKind.CONSTI_8 || b.blockKind == BlockKind.CONSTI_9 ||
                b.blockKind == BlockKind.EQ || b.blockKind == BlockKind.NEQ ||
                b.blockKind == BlockKind.GT || b.blockKind == BlockKind.LT || b.blockKind == BlockKind.GE || b.blockKind == BlockKind.LE ||
                b.blockKind == BlockKind.PLUS || b.blockKind == BlockKind.MINUS || b.blockKind == BlockKind.MUL || b.blockKind == BlockKind.DIV || b.blockKind == BlockKind.MOD ||
                b.blockKind == BlockKind.BCL)
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("SmallBlock"))
                {
                    if (m.mesh.name.Contains("LongBlock1"))
                    {
                        offset = 101.6F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        offset = 76.2F;
                    }

                    right.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offset, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

                    gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = b;

                    node.attachBlockRight(right.GetComponent<Block>());

                    haveRight = true;
                    b.inMiddle = true;
                }
                else
                {
                    Destroy(right);
                }
            }
            else
            {
                Destroy(right);
            }
        }

        else
        {
            Destroy(right);
        }
    }

    public void childTriggerIn(GameObject child)
    {
        if (child.transform.Find("ChildTrigger") != null)
        {
            child.transform.Find("ChildTrigger").gameObject.SetActive(true);
        }
        if (child.transform.Find("RightTrigger") != null)
        {
            child.transform.Find("RightTrigger").gameObject.SetActive(true);
        }
        if (child.transform.Find("SiblingTrigger") != null)
        {
            child.transform.Find("SiblingTrigger").gameObject.SetActive(true);
        }


        Block b = child.GetComponent<Block>();

        MeshFilter m = b.GetComponent<MeshFilter>();

        float offsetX = 0.0f;

        //2.54 * 20
        float offsetY = 50.8f;

        if (b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
            b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
            b.blockKind == BlockKind.FOR || b.blockKind == BlockKind.IF ||
            b.blockKind == BlockKind.FUNC_BREAKSHIELD || b.blockKind == BlockKind.FUNC_DEFENCE || b.blockKind == BlockKind.FUNC_ENERGYCHARGE || b.blockKind == BlockKind.FUNC_MELEEATTACK || b.blockKind == BlockKind.FUNC_OBSERVE || b.blockKind == BlockKind.FUNC_RANGEATTACK || b.blockKind == BlockKind.FUNC_REPAIR || b.blockKind == BlockKind.FUNC_GOLEMENERGY)
        {
            MeshFilter thisMesh = gameObject.GetComponent<MeshFilter>();

            if (thisMesh.mesh.name.Contains("LongBlock2") || thisMesh.mesh.name.Contains("LongBlock3"))
            {
                if (thisMesh.mesh.name.Contains("LongBlock2"))
                {
                    if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("LongBlock2"))
                    {
                        //2.54 * 20
                        offsetX = 50.8F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        //2.54 * 20 * 0.5
                        offsetX = 25.4F;
                    }
                }
                else if (thisMesh.mesh.name.Contains("LongBlock3"))
                {
                    if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("LongBlock2"))
                    {
                        //2.54 * 20 * 1.25
                        offsetX = 63.5F;
                    }
                    else if (m.mesh.name.Contains("SmallBlock"))
                    {
                        //2.54 * 20 * 0.75
                        offsetX = 38.1F;
                    }
                }

                child.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offsetX, gameObject.transform.localPosition.y - offsetY, gameObject.transform.localPosition.z);

                gameObject.transform.Find("ChildTrigger").GetComponent<CTrigger>().childBlock = b;

                node.attachBlockChild(b);

                node.adjustSiblingTrigger();

                haveChild = true;
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

    public void siblingTriggerIn(GameObject sibling)
    {
        if (sibling.transform.Find("ChildTrigger") != null)
        {
            sibling.transform.Find("ChildTrigger").gameObject.SetActive(true);
        }
        if (sibling.transform.Find("RightTrigger") != null)
        {
            sibling.transform.Find("RightTrigger").gameObject.SetActive(true);
        }
        if (sibling.transform.Find("SiblingTrigger") != null)
        {
            sibling.transform.Find("SiblingTrigger").gameObject.SetActive(true);
        }


        Block b = sibling.GetComponent<Block>();

        MeshFilter m = b.GetComponent<MeshFilter>();

        float offsetX = 0.0f;

        //2.54 * 0.02
        float offsetY = 50.8f;

        if (b.blockKind == BlockKind.VARI_a || b.blockKind == BlockKind.VARI_b || b.blockKind == BlockKind.VARI_c || b.blockKind == BlockKind.VARI_i || b.blockKind == BlockKind.VARI_j || b.blockKind == BlockKind.VARI_k ||
            b.blockKind == BlockKind.VARB_w || b.blockKind == BlockKind.VARB_x || b.blockKind == BlockKind.VARB_y || b.blockKind == BlockKind.VARB_z ||
            b.blockKind == BlockKind.FOR || b.blockKind == BlockKind.IF || b.blockKind == BlockKind.ELIF || b.blockKind == BlockKind.ELSE ||
            b.blockKind == BlockKind.FUNC_BREAKSHIELD || b.blockKind == BlockKind.FUNC_DEFENCE || b.blockKind == BlockKind.FUNC_ENERGYCHARGE || b.blockKind == BlockKind.FUNC_MELEEATTACK || b.blockKind == BlockKind.FUNC_OBSERVE || b.blockKind == BlockKind.FUNC_RANGEATTACK || b.blockKind == BlockKind.FUNC_REPAIR || b.blockKind == BlockKind.FUNC_GOLEMENERGY)
        {
            MeshFilter thisMesh = gameObject.GetComponent<MeshFilter>();

            if (thisMesh.mesh.name.Contains("LongBlock1") || thisMesh.mesh.name.Contains("LongBlock2"))
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("LongBlock2"))
                {
                    offsetX = 0.0f;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
                }
                else if (m.mesh.name.Contains("LongBlock3"))
                {
                    //2.54 * 20 * 0.25
                    offsetX = -12.7f;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
                }
                else if (m.mesh.name.Contains("SmallBlock"))
                {
                    //2.54 * 20 * 0.5
                    offsetX = -25.4f;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
                }
                else
                {
                    Destroy(sibling);
                }
            }
            else if (thisMesh.mesh.name.Contains("LongBlock3"))
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("LongBlock2"))
                {
                    //2.54 * 20 * 0.25
                    offsetX = 12.7f;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
                }
                else if (m.mesh.name.Contains("LongBlock3"))
                {
                    offsetX = 0.0f;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
                }
                else if (m.mesh.name.Contains("SmallBlock"))
                {
                    //2.54 * 20 * 0.25
                    offsetX = -12.7f;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
                }
                else
                {
                    Destroy(sibling);
                }
            }
            else if (thisMesh.mesh.name.Contains("SmallBlock"))
            {
                if (m.mesh.name.Contains("LongBlock1") || m.mesh.name.Contains("LongBlock2"))
                {
                    //2.54 * 20 * 0.5
                    offsetX = 25.4f;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
                }
                else if (m.mesh.name.Contains("LongBlock3"))
                {
                    //2.54 * 20 * 0.25
                    offsetX = 12.7f;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
                }
                else if (m.mesh.name.Contains("SmallBlock"))
                {
                    offsetX = 0;

                    //2.54 * 20 * height
                    offsetY = 50.8f * node.height();
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

            sibling.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + offsetX, gameObject.transform.localPosition.y - offsetY, gameObject.transform.localPosition.z);
            
            gameObject.transform.Find("SiblingTrigger").GetComponent<STrigger>().siblingBlock = b;

            node.attachBlockSibling(b);

            node.adjustSiblingTrigger();

            haveSibling = true;
        }
        else
        {
            Destroy(sibling);
        }
    }

    public void rightTriggerOut()
    {
        gameObject.transform.Find("RightTrigger").GetComponent<RTrigger>().rightBlock = null;

        Block b = node.blocks[node.blocks.Count - 1];

        if (b.transform.Find("ChildTrigger") != null)
        {
            b.transform.Find("ChildTrigger").gameObject.SetActive(false);
        }
        if (b.transform.Find("RightTrigger") != null)
        {
            b.transform.Find("RightTrigger").gameObject.SetActive(false);
        }
        if (b.transform.Find("SiblingTrigger") != null)
        {
            b.transform.Find("SiblingTrigger").gameObject.SetActive(false);
        }

        b.inMiddle = false;

        b.node = null;

        node.golLangNode.line.keywords.RemoveAt(node.blocks.Count - 1);

        node.blocks.RemoveAt(node.blocks.Count-1);

        haveRight = false;
    }

    public void childTriggerOut()
    {
        gameObject.transform.Find("ChildTrigger").GetComponent<CTrigger>().childBlock = null;

        Block b = node.children[0].blocks[0];

        if (b.transform.Find("ChildTrigger") != null)
        {
            b.transform.Find("ChildTrigger").gameObject.SetActive(false);
        }
        if (b.transform.Find("RightTrigger") != null)
        {
            b.transform.Find("RightTrigger").gameObject.SetActive(false);
        }
        if (b.transform.Find("SiblingTrigger") != null)
        {
            b.transform.Find("SiblingTrigger").gameObject.SetActive(false);
        }

        node.children[0].parents = null;
        node.children[0].golLangNode.parents = null;

        node.children.RemoveAt(0);
        node.golLangNode.children.RemoveAt(0);

        haveChild = false;

        node.adjustSiblingTrigger();
    }

    public void siblingTriggerOut()
    {
        gameObject.transform.Find("SiblingTrigger").GetComponent<STrigger>().siblingBlock = null;

        Block b = node.parents.children[node.parents.children.Count - 1].blocks[0];

        if (b.transform.Find("ChildTrigger") != null)
        {
            b.transform.Find("ChildTrigger").gameObject.SetActive(false);
        }
        if (b.transform.Find("RightTrigger") != null)
        {
            b.transform.Find("RightTrigger").gameObject.SetActive(false);
        }
        if (b.transform.Find("SiblingTrigger") != null)
        {
            b.transform.Find("SiblingTrigger").gameObject.SetActive(false);
        }

        node.parents.children[node.parents.children.Count - 1].parents = null;
        node.parents.children[node.parents.children.Count - 1].golLangNode.parents = null;

        node.parents.children[node.parents.children.Count - 1].leftSibling = null;
        node.parents.children[node.parents.children.Count - 1].golLangNode.leftSibling = null;

        node.parents.children.RemoveAt(node.parents.children.Count - 1);
        node.parents.golLangNode.children.RemoveAt(node.parents.golLangNode.children.Count - 1);

        node.rightSibling = null;
        node.golLangNode.rightSibling = null;

        haveSibling = false;

        node.adjustSiblingTrigger();
    }
}
