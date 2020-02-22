using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangKeyword : MonoBehaviour
{
    public Keyword keyword;
    public string name;//변수라면 이름
}

public enum Keyword
{
    //Data
    VARI, VARB, ARRI, ARRB, CONSTANT,
    //Control
    FOR, IF, ELIF, ELSE,
    //Compare
    EQ, BT, LT, BE, LE,
    //Calculate
    PLUS, MINUS, MUL, DIV, MOD,
    //Assignment
    ASS, PLUSONE, MINUSONE,

}