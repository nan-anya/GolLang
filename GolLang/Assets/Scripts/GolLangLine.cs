using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangLine : MonoBehaviour
{
    public List<GolLangKeyword> keywords;

    public GolLangLine()
    {
        keywords = new List<GolLangKeyword>();
    }
    public GolLangLine(List<GolLangKeyword> keywords)
    {
        keywords = new List<GolLangKeyword>(keywords);
    }

    public void excuteLine()
    {
        print(this.ToString());
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
