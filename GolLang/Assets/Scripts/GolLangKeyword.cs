using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangKeyword
{
    public GKeyword keyword;
    public string nameOrValue;//함수, 변수라면 이름, 상수라면 값

    public GolLangKeyword(GKeyword keyword)
    {
        this.keyword = keyword;

        this.nameOrValue = "";
    }
    public GolLangKeyword(GKeyword keyword, string nameOrValue)
    {
        this.keyword = keyword;

        this.nameOrValue = nameOrValue;
    }

    public override string ToString()
    {
        if(nameOrValue.Equals(""))
        {
            return keyword.ToString();
        }
        else
        {
            return nameOrValue;
        }
    }

    public GolLangKeyword clone()
    {
        return new GolLangKeyword(this.keyword, this.nameOrValue);
    }
}

public enum GKeyword
{
    //META
    STARTHERE,
    //Data1
    VARI, VARB, ARRI, ARRB, CONSTI, CONSTB,
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
    ASS, //PLUSONE, MINUSONE,
    //Function
    FUNC,
    //ETC
    COMMA
}

public enum ValueType
{
    VARI, VARB, ARRI, ARRB, VOID
}