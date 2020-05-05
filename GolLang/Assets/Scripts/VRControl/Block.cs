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

    BlockKind blockKind;

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


}
