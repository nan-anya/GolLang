using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangTree : IEnumerable
{
    public GolLangNode head;

    private GolLangNode now;

    public GolLangTree()
    {
        head = null;
    }

    //전위 순회 Enumerator
    public IEnumerator GetEnumerator()
    {
        head.unvisit();

        now = head;

        while (true)
        {
            if (!now.isVisited)
            {
                now.isVisited = true;

                yield return now;
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
}

public class GolLangNode
{
    public GolLangLine line;

    public GolLangNode parents;

    public GolLangNode leftSibling;

    public GolLangNode rightSibling;

    public List<GolLangNode> children;

    public bool isVisited;

    public GolLangNode(GolLangLine line)
    {
        this.line = line;

        parents = null;

        leftSibling = null;

        rightSibling = null;

        children = new List<GolLangNode>();

        isVisited = false;
    }

    public override string ToString()
    {
        string temp = "";

        foreach (GolLangKeyword i in line.keywords)
        {
            temp += i.ToString();
        }


        return temp;
    }

    public void addChild(GolLangNode child)
    {
        children.Add(child);

        child.parents = this;

        if (children.Count > 1)
        {
            GolLangNode now = children[0];

            while (now.rightSibling != null)
            {
                now = now.rightSibling;
            }

            now.rightSibling = child;
            child.leftSibling = now;

        }
    }

    public bool hasChildren()
    {
        if (children.Count == 0 || children == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public GolLangNode getFirstUnvisitedChild()
    {
        if (children.Count == 0 || children == null)
        {
            return null;
        }
        else
        {
            foreach (GolLangNode i in children)
            {
                if (!i.isVisited)
                {
                    return i;
                }
            }

            return null;
        }
    }

    public bool hasRightSibling()
    {
        if (this.rightSibling != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void unvisit()
    {
        isVisited = false;

        foreach (GolLangNode i in children)
        {
            i.unvisit();
        }
    }

    public void visit()
    {
        isVisited = true;

        foreach (GolLangNode i in children)
        {
            i.visit();
        }
    }
}

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
            if (i.nameOrValue.Equals(""))
            {
                switch (i.keyword)
                {
                    case GKeyword.AND:
                        temp += "&&";
                        break;
                    case GKeyword.ASS:
                        temp += "=";
                        break;
                    case GKeyword.BCL:
                        temp += ")";
                        break;
                    case GKeyword.BOP:
                        temp += "(";
                        break;
                    case GKeyword.COMMA:
                        temp += ",";
                        break;
                    case GKeyword.DIV:
                        temp += "/";
                        break;
                    case GKeyword.EQ:
                        temp += "==";
                        break;
                    case GKeyword.GE:
                        temp += ">=";
                        break;
                    case GKeyword.GT:
                        temp += ">";
                        break;
                    case GKeyword.LE:
                        temp += "<=";
                        break;
                    case GKeyword.LT:
                        temp += "<";
                        break;
                    case GKeyword.MINUS:
                        temp += "-";
                        break;
                    case GKeyword.MOD:
                        temp += "%";
                        break;
                    case GKeyword.MUL:
                        temp += "*";
                        break;
                    case GKeyword.NEG:
                        temp += "-";
                        break;
                    case GKeyword.NEQ:
                        temp += "!=";
                        break;
                    case GKeyword.NOT:
                        temp += "!";
                        break;
                    case GKeyword.OR:
                        temp += "||";
                        break;
                    case GKeyword.PLUS:
                        temp += "+";
                        break;
                }
            }
            else
            {
                temp += i.nameOrValue;
            }
        }

        return temp;
    }

    public GolLangLine clone()
    {
        return new GolLangLine(this.keywords);
    }

    public List<GolLangKeyword> extract(int from, int to)
    {
        if (from < 0)
        {
            return null;
        }
        else if (keywords.Count <= to)
        {
            return null;
        }
        else if (from > to)
        {
            return null;
        }

        List<GolLangKeyword> temp = new List<GolLangKeyword>();

        for (int i = to; i >= from; i--)
        {
            temp.Add(keywords[i]);
            keywords.RemoveAt(i);
        }

        temp.Reverse();

        return temp;
    }
}
