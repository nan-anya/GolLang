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

    public void reset()
    {
        head.unvisite();

        now = null;
    }

    public IEnumerator GetEnumerator()
    {
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

    public string excute()
    {
        return this.ToString();
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

    public void unvisite()
    {
        isVisited = false;

        foreach (GolLangNode i in children)
        {
            i.unvisite();
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
            temp += i.keyword.ToString();
        }

        return temp;
    }
}
