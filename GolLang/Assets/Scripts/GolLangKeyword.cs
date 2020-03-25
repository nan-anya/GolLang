using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangKeyword : MonoBehaviour
{
    public GKeyword keyword;
    public string name;//변수라면 이름, 상수라면 값

    public GolLangKeyword(GKeyword keyword)
    {
        this.keyword = keyword;

        this.name = "";
    }
    public GolLangKeyword(GKeyword keyword, string name)
    {
        this.keyword = keyword;

        this.name = name;
    }
}

public enum GKeyword
{
    //META
    STARTHERE,
    //Data
    VARI, VARB, ARRI, ARRB, CONSTI, CONSTB,
    //Control
    FOR, IF, ELIF, ELSE,
    //Compare
    EQ, BT, LT, BE, LE,
    //Calculate
    PLUS, MINUS, MUL, DIV, MOD,
    //Assignment
    ASS, PLUSONE, MINUSONE,

}