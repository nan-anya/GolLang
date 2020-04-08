using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangLine
{
    public List<GolLangKeyword> keywords;

    public GolLangLine()
    {
        this.keywords = new List<GolLangKeyword>();
    }
    public GolLangLine(List<GolLangKeyword> keywords)
    {
        this.keywords = new List<GolLangKeyword>(keywords);
    }

    override public string ToString()
    {
        string temp = "";

        foreach (GolLangKeyword i in keywords)
        {
            temp += i.keyword.ToString();
        }

        return temp;
    }
}
