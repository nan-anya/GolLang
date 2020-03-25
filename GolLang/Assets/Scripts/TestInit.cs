using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInit : MonoBehaviour
{
    void Start()
    {
        GolLangTree gT = new GolLangTree();


        List<GolLangKeyword> tempGLK = new List<GolLangKeyword>();

        tempGLK.Add(new GolLangKeyword(GKeyword.STARTHERE));

        gT.head = new GolLangNode(new GolLangLine(tempGLK));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.FOR));
        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        tempGLK.Add(new GolLangKeyword(GKeyword.EQ));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "5"));

        gT.head.addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.FOR));
        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "j"));
        tempGLK.Add(new GolLangKeyword(GKeyword.EQ));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "5"));

    }
}
