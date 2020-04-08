using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInit
{
    public GolLangTree gT;
    
    public void init()
    {
        gT = new GolLangTree();
        
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

        gT.head.children[0].addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.IF));
        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        tempGLK.Add(new GolLangKeyword(GKeyword.MOD));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "2"));
        tempGLK.Add(new GolLangKeyword(GKeyword.EQ));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "1"));

        gT.head.children[0].children[0].addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.FUNC, "create"));
        tempGLK.Add(new GolLangKeyword(GKeyword.BLOCK1));

        gT.head.children[0].children[0].children[0].addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Clear();
        tempGLK.Add(new GolLangKeyword(GKeyword.ELSE));

        gT.head.children[0].children[0].addChild(new GolLangNode(new GolLangLine(tempGLK)));
        
        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.FUNC, "create"));
        tempGLK.Add(new GolLangKeyword(GKeyword.BLOCK2));

        gT.head.children[0].children[0].children[1].addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.FUNC, "LFCR"));

        gT.head.addChild(new GolLangNode(new GolLangLine(tempGLK)));
        
    }
}
