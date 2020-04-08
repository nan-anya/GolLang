using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangKeyword
{
    public GKeyword keyword;
    public string name;//함수, 변수라면 이름, 상수라면 값

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

    public override string ToString()
    {
        if(name.Equals(""))
        {
            return keyword.ToString();
        }
        else
        {
            return name;
        }
    }
}

public enum GKeyword
{
    //META
    STARTHERE,
    //Data1
    VARI, VARB, ARRI, ARRB, CONSTI, CONSTB,
    //Data2
    BLOCK1, BLOCK2,
    //Control
    FOR, IF, ELIF, ELSE,
    //Compare
    EQ, BT, LT, BE, LE,
    //Calculate
    PLUS, MINUS, MUL, DIV, MOD,
    //Assignment
    ASS, PLUSONE, MINUSONE,
    //Function
    FUNC,
    //ETC
    COMMA
}