using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        foreach(GolLangKeyword i in line.keywords)
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
            foreach(GolLangNode i in children)
            {
                if(!i.isVisited)
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
