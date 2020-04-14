using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangInterpreter : MonoBehaviour
{
    public GolLangTree gTree;
    
    public List<GolLangVarData> vars;

    public TestInit testi = new TestInit();
    public GolLangInterpreter()
    { 
    
    }

    void Start()
    {
        interpret();
    }


    public void preorderTraversal()
    {
        GolLangNode now = gTree.head;

        while (true)
        {
            if (!now.isVisited)
            {
                now.isVisited = true;

                
            }

            GolLangNode temp = now.getFirstUnvisitedChild();

            if (temp != null)
            {
                now = temp;
            }

            else if (now.hasRightSibling())
            {
                now = now.rightSibling;
            }
            else if (now.parents != null)
            {
                now = now.parents;
            }
            else
            {
                break;
            }
        }
    }
   
    public void interpret()
    {
        testi.init();

        gTree = testi.gT;

        preorderTraversal();
    }

    //문법이 맞는 줄이 들어오는 것을 전제로 한다.
    public lineKind lineCheck(GolLangLine line)
    {
        if (line.keywords[0].keyword == GKeyword.STARTHERE)
        {
            return lineKind.STARTHERE;
        }
        else if (line.keywords[0].keyword == GKeyword.FOR)
        {
            return lineKind.FOR;
        }
        else if (line.keywords[0].keyword == GKeyword.IF)
        {
            return lineKind.IF;
        }
        else if (line.keywords[0].keyword == GKeyword.ELSE)
        {
            return lineKind.ELSE;
        }
        else if (line.keywords[0].keyword == GKeyword.ELIF)
        {
            return lineKind.ELIF;
        }

        return lineKind.EXE;
    }
    //FOR, IF 다음에는 조건이 와야한다.
    //조건은 단독으로 있을 수 없다.
    //실행문은 함수가 있거나 할당연산자가 있어야한다.
    public enum lineKind {STARTHERE, FOR, IF, ELSE, ELIF, EXE, UNKNOWN}

    public void excuteLine(GolLangNode node)
    {
       
    }

    public GolLangParseTree parse(GolLangLine line)
    { 
        
    }

    private int lowestPriority(List<GolLangKeyword> keywords)
    {
        for(int i = 0; i > keywords.Count; i++)
        {
            if()

        }


        return -1;
    }
}
