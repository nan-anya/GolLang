﻿using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GolLangInterpreter : MonoBehaviour
{
    public GolLangTree gTree;

    public List<GolLangFunctionDescription> functions;

    private List<GolLangVarData> variables;

    void Start()
    {
        functions = new List<GolLangFunctionDescription>();
        variables = new List<GolLangVarData>();

        test();
    }

    void test()
    {
        functions.Add(new GolLangFunctionDescription("F1", new List<ValueType>(new ValueType[] { ValueType.VARI, ValueType.VARI }), ValueType.VARI));
        functions.Add(new GolLangFunctionDescription("F2", new List<ValueType>(new ValueType[] { ValueType.VARI, ValueType.VARI }), ValueType.VARI));
        functions.Add(new GolLangFunctionDescription("F3", new List<ValueType>(new ValueType[] { ValueType.VARI, ValueType.VARI }), ValueType.VARI));
        functions.Add(new GolLangFunctionDescription("F4", new List<ValueType>(new ValueType[] { ValueType.VARI }), ValueType.VARI));

        gTree = new GolLangTree();

        List<GolLangKeyword> tempGLK = new List<GolLangKeyword>();

        tempGLK.Add(new GolLangKeyword(GKeyword.STARTHERE));

        gTree.head = new GolLangNode(new GolLangLine(tempGLK));

        tempGLK.Clear();
        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        tempGLK.Add(new GolLangKeyword(GKeyword.ASS));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "0"));

        gTree.head.addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "k"));
        tempGLK.Add(new GolLangKeyword(GKeyword.ASS));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "0"));

        gTree.head.addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.FOR));
        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        tempGLK.Add(new GolLangKeyword(GKeyword.NEQ));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "3"));

        gTree.head.addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.IF));
        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        tempGLK.Add(new GolLangKeyword(GKeyword.MOD));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "2"));
        tempGLK.Add(new GolLangKeyword(GKeyword.EQ));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "1"));

        gTree.head.children[2].addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "k"));
        tempGLK.Add(new GolLangKeyword(GKeyword.ASS));
        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "k"));
        tempGLK.Add(new GolLangKeyword(GKeyword.PLUS));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "1"));

        gTree.head.children[2].children[0].addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        tempGLK.Add(new GolLangKeyword(GKeyword.ASS));
        tempGLK.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        tempGLK.Add(new GolLangKeyword(GKeyword.PLUS));
        tempGLK.Add(new GolLangKeyword(GKeyword.CONSTI, "1"));

        gTree.head.children[2].addChild(new GolLangNode(new GolLangLine(tempGLK)));

        tempGLK.Clear();

        interpret();

        foreach (GolLangVarData i in variables)
        {
            print(i);
        }
        
    }

    void test2()
    {
        List<GolLangKeyword> gl = new List<GolLangKeyword>();

        gl.Add(new GolLangKeyword(GKeyword.VARI, "i"));
        gl.Add(new GolLangKeyword(GKeyword.ASS));
        gl.Add(new GolLangKeyword(GKeyword.BOP));
        gl.Add(new GolLangKeyword(GKeyword.CONSTI, "1"));
        gl.Add(new GolLangKeyword(GKeyword.PLUS));
        gl.Add(new GolLangKeyword(GKeyword.CONSTI, "2"));
        gl.Add(new GolLangKeyword(GKeyword.BCL));
        gl.Add(new GolLangKeyword(GKeyword.MUL));
        gl.Add(new GolLangKeyword(GKeyword.CONSTI, "3"));

        GolLangNode gn = new GolLangNode(new GolLangLine(gl));

        excuteLine(gn);

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
        foreach (GolLangNode i in gTree)
        {
            if (lineCheck(i.line) == lineKind.EXE)
            {
                excuteLine(i);
            }
            //TODO break있어야함?
            else if (lineCheck(i.line) == lineKind.FOR)
            {
                GolLangNode tempGN = new GolLangNode(new GolLangLine(i.line.keywords.GetRange(1, i.line.keywords.Count - 1)));

                CalcResult tempCR = excuteLine(tempGN);

                if (tempCR.errorCode == 0)
                {
                    if (tempCR.resultValue == 1)
                    {
                        i.unvisit();
                    }
                    else
                    {
                        i.visit();
                    }
                }
                else
                {
                    //TODO 에러처리
                    if (tempCR.errorCode == 1)
                    {

                    }
                    else if (tempCR.errorCode == 2)
                    {

                    }
                    else if (tempCR.errorCode == 3)
                    {

                    }
                    else if (tempCR.errorCode == 4)
                    {

                    }
                }
            }
            //TODO 버그 있을지도
            else if (lineCheck(i.line) == lineKind.IF)
            {
                List<GolLangNode> ifFamily = new List<GolLangNode>();

                GolLangNode j = i;

                while (true)
                {
                    if (j.line.keywords[0].keyword == GKeyword.IF ||
                        j.line.keywords[0].keyword == GKeyword.ELIF ||
                        j.line.keywords[0].keyword == GKeyword.ELSE)
                    {
                        ifFamily.Add(j);

                        if (j.hasRightSibling())
                        {
                            j = j.rightSibling;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                foreach (GolLangNode k in ifFamily)
                {
                    if (k.line.keywords[0].keyword == GKeyword.IF ||
                       k.line.keywords[0].keyword == GKeyword.ELIF)
                    {
                        GolLangNode tempGN = new GolLangNode(new GolLangLine(k.line.keywords.GetRange(1, k.line.keywords.Count - 1)));

                        CalcResult tempCR = excuteLine(tempGN);

                        if (tempCR.errorCode == 0)
                        {
                            if (tempCR.resultValue == 1)
                            {
                                foreach (GolLangNode l in ifFamily)
                                {
                                    l.visit();
                                }

                                k.unvisit();
                                k.isVisited = true;

                                break;
                            }
                            else
                            {
                                k.visit();
                            }
                        }
                        else
                        {
                            //TODO 에러처리
                            if (tempCR.errorCode == 1)
                            {

                            }
                            else if (tempCR.errorCode == 2)
                            {

                            }
                            else if (tempCR.errorCode == 3)
                            {

                            }
                            else if (tempCR.errorCode == 4)
                            {

                            }
                        }
                    }
                    else //(k.line.keywords[0].keyword == GKeyword.ELSE)
                    {

                    }
                }
            }
            else if (lineCheck(i.line) == lineKind.STARTHERE)
            { 
                //Do nothing
            }
        }
    }

    //문법이 맞는 줄이 들어오는 것을 전제로 한다.
    private lineKind lineCheck(GolLangLine line)
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

    private enum lineKind {STARTHERE, FOR, IF, ELSE, ELIF, EXE, UNKNOWN}

    private CalcResult excuteLine(GolLangNode node)
    {
        Stack<GolLangParseNode> calculateStack = new Stack<GolLangParseNode>();

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
                //산술 연산
                if (i.line.keywords[0].keyword == GKeyword.PLUS)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTI, (operand1.value + operand2.value).ToString()) })));

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.MINUS)
                {
                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTI, (operand1.value - operand2.value).ToString()) })));

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.MUL)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTI, (operand1.value * operand2.value).ToString()) })));

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.DIV)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTI, (operand1.value / operand2.value).ToString()) })));

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.MOD)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTI, (operand1.value % operand2.value).ToString()) })));

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.NEG)
                {
                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if (operand1.type == dataType.CONSTI || operand1.type == dataType.VARI)
                    {
                        GolLangParseNode tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTI, (-operand1.value).ToString()) })));

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                //Int, Bool 비교연산
                else if (i.line.keywords[0].keyword == GKeyword.EQ)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if (((operand1.type == dataType.CONSTB || operand1.type == dataType.VARB) && (operand2.type == dataType.CONSTB || operand2.type == dataType.VARB)) ||
                        ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) && (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI)))
                    {
                        GolLangParseNode tempN;

                        if (operand1.value == operand2.value)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }


                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.NEQ)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if (((operand1.type == dataType.CONSTB || operand1.type == dataType.VARB) && (operand2.type == dataType.CONSTB || operand2.type == dataType.VARB)) ||
                        ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) && (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI)))
                    {
                        GolLangParseNode tempN;

                        if (operand1.value != operand2.value)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }


                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                //Int only
                else if (i.line.keywords[0].keyword == GKeyword.GT)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN;

                        if (operand1.value > operand2.value)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.LT)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN;

                        if (operand1.value < operand2.value)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.GE)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN;

                        if (operand1.value >= operand2.value)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.LE)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTI || operand1.type == dataType.VARI) &&
                        (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI))
                    {
                        GolLangParseNode tempN;

                        if (operand1.value <= operand2.value)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                //Bool only
                else if (i.line.keywords[0].keyword == GKeyword.AND)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTB || operand1.type == dataType.VARB) &&
                        (operand2.type == dataType.CONSTB || operand2.type == dataType.VARB))
                    {
                        GolLangParseNode tempN;

                        if (operand1.value == 1 && operand2.value == 1)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.OR)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());

                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if ((operand1.type == dataType.CONSTB || operand1.type == dataType.VARB) &&
                        (operand2.type == dataType.CONSTB || operand2.type == dataType.VARB))
                    {
                        GolLangParseNode tempN;

                        if (operand1.value == 1 || operand2.value == 1)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                else if (i.line.keywords[0].keyword == GKeyword.NOT)
                {
                    DataState operand1 = dataEvaluation(calculateStack.Pop());

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if (operand1.type == dataType.CONSTB || operand1.type == dataType.VARB)
                    {
                        GolLangParseNode tempN;

                        if (operand1.value == 1)
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 0.ToString()) })));
                        }
                        else
                        {
                            tempN = new GolLangParseNode(new GolLangLine(new List<GolLangKeyword>(new GolLangKeyword[] { new GolLangKeyword(GKeyword.CONSTB, 1.ToString()) })));
                        }

                        calculateStack.Push(tempN);
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }
                //할당
                else if (i.line.keywords[0].keyword == GKeyword.ASS)
                {
                    DataState operand2 = dataEvaluation(calculateStack.Pop());
                    GolLangParseNode tempVar = calculateStack.Pop();
                    DataState operand1 = dataEvaluation(tempVar);

                    //에러 코드 일 때
                    if (operand1.type == dataType.ERROR)
                    {
                        if (operand1.value == 1)
                        {
                            if (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI)
                            {
                                variables.Add(new GolLangVarData(tempVar.line.keywords[0].nameOrValue, operand2.value, ValueType.VARI));
                            }
                            else if (operand2.type == dataType.CONSTB || operand2.type == dataType.VARB)
                            {
                                variables.Add(new GolLangVarData(tempVar.line.keywords[0].nameOrValue, operand2.value, ValueType.VARB));
                            }
                            else
                            {
                                //TODO 배열
                            }
                        }
                        else if (operand1.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand1.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }
                    if (operand2.type == dataType.ERROR)
                    {
                        if (operand2.value == 1)
                        {
                            return new CalcResult(1, 0);
                        }
                        else if (operand2.value == 2)
                        {
                            return new CalcResult(2, 0);
                        }
                        else if (operand2.value == 3)
                        {
                            return new CalcResult(3, 0);
                        }
                    }

                    //정상
                    if (operand1.type == dataType.VARI && (operand2.type == dataType.CONSTI || operand2.type == dataType.VARI) ||
                        operand1.type == dataType.VARB && (operand2.type == dataType.CONSTB || operand2.type == dataType.VARB))
                    {
                        variables.Find(x => x.name.Contains(tempVar.line.keywords[0].nameOrValue)).value = operand2.value;
                    }
                    else
                    {
                        return new CalcResult(2, 0);
                    }
                }

                else if (i.line.keywords[0].keyword == GKeyword.FUNC)
                {
                    //TODO
                }
            }
        }

        if (calculateStack.Count != 0)
        {
            return new CalcResult(0, int.Parse(calculateStack.Peek().line.keywords[0].nameOrValue));
        }
        else
        {
            return new CalcResult(0, 0);
        }
    }
    
    //int로 에러코드 반환
    //0 정상
    //1 선언되지 않은 변수
    //2 피연산자 타입오류
    //3 피연산자가 아님
    //4 알려지지 않은 연산자
    private class CalcResult
    {
        public int errorCode;

        public int resultValue;

        public CalcResult(int errorCode, int resultValue)
        {
            this.errorCode = errorCode;
            this.resultValue = resultValue;
        }

        public CalcResult(int resultValue)
        {
            errorCode = 0;
            this.resultValue = resultValue;
        }
    }

    /*
    ERROR일때 value는 에러코드

    1 선언되지 않은 변수 사용
    2 선언된 변수지만 변수의 형이 node에 표시된 형과 다름 맞지 않음
    3 노드가 데이터값이 아님
    */
    private DataState dataEvaluation(GolLangParseNode node)
    {
        if (node.line.keywords[0].keyword == GKeyword.CONSTI)
        {
            string temp = "";

            foreach (GolLangKeyword i in node.line.keywords)
            {
                temp += i.nameOrValue;

                return new DataState(int.Parse(temp), dataType.CONSTI);
            }
        }
        else if (node.line.keywords[0].keyword == GKeyword.CONSTB)
        {
            if (node.line.keywords[0].nameOrValue.Contains("TRUE"))
            {
                return new DataState(1, dataType.CONSTB);
            }
            else
            {
                return new DataState(0, dataType.CONSTB);
            }
        }
        else if (node.line.keywords[0].keyword == GKeyword.VARI)
        {

            GolLangVarData tempVar = variables.Find(x => x.name.Contains(node.line.keywords[0].nameOrValue));

            if (tempVar == null)
            {
                return new DataState(1, dataType.ERROR);
            }
            else if (tempVar.type != ValueType.VARI)
            {
                return new DataState(2, dataType.ERROR);
            }

            return new DataState(tempVar.value, dataType.VARI);
        }
        else if (node.line.keywords[0].keyword == GKeyword.VARB)
        {
            GolLangVarData tempVar = variables.Find(x => x.name.Contains(node.line.keywords[0].nameOrValue));

            if (tempVar == null)
            {
                return new DataState(1, dataType.ERROR);
            }
            else if (tempVar.type != ValueType.VARB)
            {
                return new DataState(2, dataType.ERROR);
            }

            return new DataState(tempVar.value, dataType.VARB);
        }
        else if (node.line.keywords[0].keyword == GKeyword.ARRI)
        {

        }
        else if (node.line.keywords[0].keyword == GKeyword.ARRB)
        {

        }

        return new DataState(3, dataType.ERROR);

    }

    private class DataState
    {
        //int값이면 그 값 bool 값이면 true = 1, false = 0
        public int value;

        public dataType type;

        public DataState(int value, dataType type)
        {
            this.value = value;
            this.type = type;
        }        
    }
    public enum dataType { VARI, VARB, CONSTI, CONSTB, ARRI, ARRB, ERROR }

    private GolLangParseTree parse(GolLangLine line)
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