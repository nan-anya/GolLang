using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangInterpreter : MonoBehaviour
{
    public GolLangTree gTree;
    
    public List<GolLangVarData> vars;

    public List<GolLangFunctionDescription> functions;

    public GolLangInterpreter()
    { 
        
    }

    void Start()
    {
        vars = new List<GolLangVarData>();
        functions = new List<GolLangFunctionDescription>();

        test();
    }

    void test()
    {
        functions.Add(new GolLangFunctionDescription("F1", new List<ValueType>(new ValueType[] { ValueType.ONEI, ValueType.ONEI }), ValueType.ONEI));
        functions.Add(new GolLangFunctionDescription("F2", new List<ValueType>(new ValueType[] { ValueType.ONEI, ValueType.ONEI }), ValueType.ONEI));
        functions.Add(new GolLangFunctionDescription("F3", new List<ValueType>(new ValueType[] { ValueType.ONEI, ValueType.ONEI }), ValueType.ONEI));
        functions.Add(new GolLangFunctionDescription("F4", new List<ValueType>(new ValueType[] { ValueType.ONEI}), ValueType.ONEI));

        List<GolLangKeyword> gl = new List<GolLangKeyword>();

        gl.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        gl.Add(new GolLangKeyword(GKeyword.ASS));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "a"));
        gl.Add(new GolLangKeyword(GKeyword.PLUS));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "b"));

        GolLangLine line = new GolLangLine(gl);

        GolLangParseTree t = parse(line);

        print(t);
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
        GolLangParseTree parseTree = new GolLangParseTree(new GolLangParseNode(line));

        spliteNode(parseTree.head);

        return parseTree;
    }

    private int lowestPriorityOperator(List<GolLangKeyword> keywords)
    {
        List<int> exclude = new List<int>();

        int bracketCount = 0;

        for (int i = 0; i < keywords.Count; i++)
        {
            // 여는 괄호 제외
            if (keywords[i].keyword == GKeyword.BOP)
            {
                bracketCount++;
                exclude.Add(i);
            }
            //닫는 괄호 제외
            else if (keywords[i].keyword == GKeyword.BCL)
            {
                bracketCount--;
                exclude.Add(i);
            }
            //괄호안에 있는 것들 제외
            else if (bracketCount != 0)
            {
                exclude.Add(i);
            }
            //콤마 제외
            else if (keywords[i].keyword == GKeyword.COMMA)
            {
                exclude.Add(i);
            }
            //피연산자 제외
            else if (keywords[i].keyword == GKeyword.VARI ||
                     keywords[i].keyword == GKeyword.VARB ||
                     keywords[i].keyword == GKeyword.ARRI ||
                     keywords[i].keyword == GKeyword.ARRB ||
                     keywords[i].keyword == GKeyword.CONSTI ||
                     keywords[i].keyword == GKeyword.CONSTB)
            {
                exclude.Add(i);
            }
        }



        for(int i = 0; i < keywords.Count; i++)
        {
            if (exclude.Contains(i))
            {
                continue;
            }

            // =
            if (keywords[i].keyword == GKeyword.ASS)
            {
                return i;
            }
            // ||
            else if (keywords[i].keyword == GKeyword.OR)
            {
                return i;
            }
            // &&
            else if (keywords[i].keyword == GKeyword.AND)
            {
                return i;
            }
            // !=, ==, >=, <=, <, >
            else if (keywords[i].keyword == GKeyword.EQ ||
                     keywords[i].keyword == GKeyword.NEQ ||
                     keywords[i].keyword == GKeyword.BT ||
                     keywords[i].keyword == GKeyword.LT ||
                     keywords[i].keyword == GKeyword.BE ||
                     keywords[i].keyword == GKeyword.LE)
            {
                return i;
            }
            // +, -
            else if (keywords[i].keyword == GKeyword.PLUS ||
                     keywords[i].keyword == GKeyword.MINUS)
            {
                return i;
            }
            // *, /, %
            else if (keywords[i].keyword == GKeyword.MUL ||
                     keywords[i].keyword == GKeyword.DIV ||
                     keywords[i].keyword == GKeyword.MOD)
            {
                return i;
            }
            // -(음수)
            else if (keywords[i].keyword == GKeyword.NEG)
            {
                return i;
            }
            // !
            else if (keywords[i].keyword == GKeyword.NOT)
            {
                return i;
            }
            // 함수
            else if (keywords[i].keyword == GKeyword.FUNC)
            {
                return i;
            }

        }

        return -1;
    }

    private void spliteNode(GolLangParseNode node)
    {
        int lpo = lowestPriorityOperator(node.line.keywords);

        if (lpo == -1)
        {
            return;
        }

        //함수( 피연산자, 피연산자, ....)
        if (node.line.keywords[lpo].keyword == GKeyword.FUNC)
        {
            List<GolLangParseNode> tempL = new List<GolLangParseNode>();

            List<GolLangKeyword> keywords = new List<GolLangKeyword>();

            int from = 1;
            int to = 0;

            for (int i = 2; i < node.line.keywords.Count-2; i++)
            {
                if (node.line.keywords[i].keyword != GKeyword.COMMA)
                {
                    keywords.Add(node.line.keywords[i]);
                }
                else
                {
                    tempL.Add(new GolLangParseNode(new GolLangLine(keywords)));
                    keywords.Clear();
                }
            }

            tempL.Add(new GolLangParseNode(new GolLangLine(keywords)));

            node.line.keywords = new List<GolLangKeyword>(new GolLangKeyword[]{node.line.keywords[0]});

            foreach (GolLangParseNode i in tempL)
            {
                node.addChild(i);
            }
        }
        //연산자 피연산자
        else if (node.line.keywords[lpo].keyword == GKeyword.NEG ||
                 node.line.keywords[lpo].keyword == GKeyword.NOT)
        {
            GolLangParseNode tempN = new GolLangParseNode(new GolLangLine(node.line.extract(lpo + 1, node.line.keywords.Count - 1)));

            node.addChild(tempN);
        }
        //피연산자 연산자 피연산자
        else
        {
            GolLangParseNode rNode = new GolLangParseNode(new GolLangLine(node.line.extract(lpo + 1, node.line.keywords.Count - 1)));

            GolLangParseNode lNode = new GolLangParseNode(new GolLangLine(node.line.extract(0, lpo - 1)));

            node.addChild(lNode);
            node.addChild(rNode);
        }

        foreach (GolLangParseNode i in node.children)
        {
            spliteNode(i);
        }
    }
}

public class GolLangFunctionDescription
{
    string functionName;

    List<ValueType> operands;

    ValueType returnType;

    public GolLangFunctionDescription(string functionName, List<ValueType> operands, ValueType returnType)
    {
        this.functionName = functionName;
        this.operands = new List<ValueType>(operands);
        this.returnType = returnType;
    }
}