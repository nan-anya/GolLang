using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangInterpreter : MonoBehaviour
{
    public GolLangTree gTree;
    
    public List<GolLangVarData> vars;

    public List<GolLangFunctionDescription> functions;

    private Stack<GolLangParseNode> calculateStack;

    private List<GolLangVarData> variables;

    public GolLangInterpreter()
    { 
        
    }

    void Start()
    {
        vars = new List<GolLangVarData>();
        functions = new List<GolLangFunctionDescription>();
        calculateStack = new Stack<GolLangParseNode>();
        variables = new List<GolLangVarData>();

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
        gl.Add(new GolLangKeyword(GKeyword.FUNC, "F1"));
        gl.Add(new GolLangKeyword(GKeyword.BOP));
        gl.Add(new GolLangKeyword(GKeyword.FUNC, "F2"));
        gl.Add(new GolLangKeyword(GKeyword.BOP));
        gl.Add(new GolLangKeyword(GKeyword.CONSTI, "1"));
        gl.Add(new GolLangKeyword(GKeyword.CONSTI, "2"));
        gl.Add(new GolLangKeyword(GKeyword.COMMA));
        gl.Add(new GolLangKeyword(GKeyword.CONSTI, "3"));
        gl.Add(new GolLangKeyword(GKeyword.CONSTI, "4"));
        gl.Add(new GolLangKeyword(GKeyword.BCL));
        gl.Add(new GolLangKeyword(GKeyword.COMMA));
        gl.Add(new GolLangKeyword(GKeyword.FUNC, "F3"));
        gl.Add(new GolLangKeyword(GKeyword.BOP));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "c"));
        gl.Add(new GolLangKeyword(GKeyword.MUL));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "d"));
        gl.Add(new GolLangKeyword(GKeyword.DIV));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "e"));
        gl.Add(new GolLangKeyword(GKeyword.COMMA));
        gl.Add(new GolLangKeyword(GKeyword.BOP));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "f"));
        gl.Add(new GolLangKeyword(GKeyword.PLUS));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "g"));
        gl.Add(new GolLangKeyword(GKeyword.BCL));
        gl.Add(new GolLangKeyword(GKeyword.MUL));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "h"));
        gl.Add(new GolLangKeyword(GKeyword.BCL));
        gl.Add(new GolLangKeyword(GKeyword.BCL));
        gl.Add(new GolLangKeyword(GKeyword.PLUS));
        gl.Add(new GolLangKeyword(GKeyword.FUNC, "F4"));
        gl.Add(new GolLangKeyword(GKeyword.BOP));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "j"));
        gl.Add(new GolLangKeyword(GKeyword.PLUS));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "k"));
        gl.Add(new GolLangKeyword(GKeyword.MINUS));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "l"));
        gl.Add(new GolLangKeyword(GKeyword.PLUS));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "m"));
        gl.Add(new GolLangKeyword(GKeyword.BCL));
        gl.Add(new GolLangKeyword(GKeyword.MUL));
        gl.Add(new GolLangKeyword(GKeyword.VARI, "n"));

        GolLangLine line = new GolLangLine(gl);

        GolLangParseTree t = parse(line);

        string s = "";

        print(s);
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

    public int excuteLine(GolLangNode node)
    {
        //int로 에러코드 반환
        //0 정상
        //1 할당되지 않은 변수
        //2 피연산자 타입오류
        //3 알려지지 않은 연산자

        GolLangParseTree parseTree = parse(node.line);

        foreach (GolLangParseNode i in parseTree)
        {
            if (i.line.keywords[0].keyword == GKeyword.CONSTI ||
                i.line.keywords[0].keyword == GKeyword.CONSTB ||
                i.line.keywords[0].keyword == GKeyword.VARI ||
                i.line.keywords[0].keyword == GKeyword.VARB ||
                i.line.keywords[0].keyword == GKeyword.ARRI ||
                i.line.keywords[0].keyword == GKeyword.ARRB)
            {
                calculateStack.Push(i);
            }
            else
            {
                if (i.line.keywords[0].keyword == GKeyword.PLUS)
                { 
                
                }
                else if (i.line.keywords[0].keyword == GKeyword.MINUS)
                {

                }
            }


        }

        return 0;
    }

    public int dataEvaluation(GolLangParseNode node)
    {
        if (node.line.keywords[0].keyword == GKeyword.CONSTI)
        { 
            
        }
        else if (node.line.keywords[0].keyword == GKeyword.CONSTB)
        {

        }
        else if (node.line.keywords[0].keyword == GKeyword.VARI)
        {

        }
        else if (node.line.keywords[0].keyword == GKeyword.VARB)
        {

        }

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

        while (true)
        {
            exclude.Clear();

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

            if (exclude.Count == keywords.Count)
            {
                //순서에 관계없는 괄호로 인해 검출이 안되는지 검사  {예 : (a+b)}
                if (keywords[0].keyword == GKeyword.BOP)
                {
                    keywords.RemoveAt(keywords.Count - 1);
                    keywords.RemoveAt(0);
                    continue;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                break;
            }
        }

        int lowest = -1;

        int priority = 9999;

        for (int i = 0; i < keywords.Count; i++)
        {
            if (exclude.Contains(i))
            {
                continue;
            }

            // =
            if (keywords[i].keyword == GKeyword.ASS)
            {
                if (priority >= 0)
                {
                    lowest = i;
                    priority = 0;
                }
            }
            // ||
            else if (keywords[i].keyword == GKeyword.OR)
            {
                if (priority >= 1)
                {
                    lowest = i;
                    priority = 1;
                }
            }
            // &&
            else if (keywords[i].keyword == GKeyword.AND)
            {
                if (priority >= 2)
                {
                    lowest = i;
                    priority = 2;
                }
            }
            // !=, ==, >=, <=, <, >
            else if (keywords[i].keyword == GKeyword.EQ ||
                     keywords[i].keyword == GKeyword.NEQ ||
                     keywords[i].keyword == GKeyword.GT ||
                     keywords[i].keyword == GKeyword.LT ||
                     keywords[i].keyword == GKeyword.GE ||
                     keywords[i].keyword == GKeyword.LE)
            {
                if (priority >= 3)
                {
                    lowest = i;
                    priority = 3;
                }
            }
            // +, -
            else if (keywords[i].keyword == GKeyword.PLUS ||
                     keywords[i].keyword == GKeyword.MINUS)
            {
                if (priority >= 4)
                {
                    lowest = i;
                    priority = 4;
                }
            }
            // *, /, %
            else if (keywords[i].keyword == GKeyword.MUL ||
                     keywords[i].keyword == GKeyword.DIV ||
                     keywords[i].keyword == GKeyword.MOD)
            {
                if (priority >= 5)
                {
                    lowest = i;
                    priority = 5;
                }
            }
            // -(음수)
            else if (keywords[i].keyword == GKeyword.NEG)
            {
                if (priority >= 6)
                {
                    lowest = i;
                    priority = 6;
                }
            }
            // !
            else if (keywords[i].keyword == GKeyword.NOT)
            {
                if (priority >= 7)
                {
                    lowest = i;
                    priority = 7;
                }
            }
            // 함수
            else if (keywords[i].keyword == GKeyword.FUNC)
            {
                if (priority >= 8)
                {
                    lowest = i;
                    priority = 8;
                }
            }

        }

        return lowest;
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

            int bracketCount = 0;

            for (int i = 2; i < node.line.keywords.Count-1; i++)
            {
                //함수의 파라미터들을 콤마 단위로 끊음, 단 괄호의 안일경우 끊지 않음
                if (node.line.keywords[i].keyword == GKeyword.COMMA)
                {
                    if (bracketCount == 0)
                    {
                        tempL.Add(new GolLangParseNode(new GolLangLine(keywords)));
                        keywords.Clear();
                    }
                    else
                    {
                        keywords.Add(node.line.keywords[i]);
                    }
                }
                else
                {
                    if (node.line.keywords[i].keyword == GKeyword.BOP)
                    {
                        bracketCount++;
                    }
                    else if (node.line.keywords[i].keyword == GKeyword.BCL)
                    {
                        bracketCount--;
                    }

                    keywords.Add(node.line.keywords[i]);
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





    public class dataState
    { 
        
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