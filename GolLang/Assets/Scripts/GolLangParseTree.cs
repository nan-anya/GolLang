using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GolLangParseTree : IEnumerable
{
    public GolLangParseNode head;

    private GolLangParseNode now;

    public GolLangParseTree()
    {
        head = null;
    }

    public GolLangParseTree(GolLangParseNode head)
    {
        this.head = head;
    }


    //후위 순회 Enumerator
    public IEnumerator GetEnumerator()
    {
        head.unvisit();

        now = head;

        while (true)
        {
            GolLangParseNode temp = now.getFirstUnvisitedChild();

            if (temp == null)
            {
                if (!now.isVisited)
                {
                    now.isVisited = true;

                    yield return now;
                }

                if (now.hasRightSibling())
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
            else
            {
                now = temp;
            }

        }
    }
   
    /* 전위 순회 Enumerator
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

            GolLangParseNode temp = now.getFirstUnvisitedChild();

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
    */
}

public class GolLangParseNode
{
    public GolLangLine line;

    public GolLangParseNode parents;

    public GolLangParseNode leftSibling;

    public GolLangParseNode rightSibling;

    public List<GolLangParseNode> children;

    public bool isVisited;

    public GolLangParseNode(GolLangLine keywords)
    {
        this.line = keywords.clone();

        parents = null;

        leftSibling = null;

        rightSibling = null;

        children = new List<GolLangParseNode>();

        isVisited = false;
    }

    public override string ToString()
    {
        return line.ToString();
    }

    public void addChild(GolLangParseNode child)
    {
        children.Add(child);

        child.parents = this;

        if (children.Count > 1)
        {
            GolLangParseNode now = children[0];

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

    public GolLangParseNode getFirstUnvisitedChild()
    {
        if (children.Count == 0 || children == null)
        {
            return null;
        }
        else
        {
            foreach (GolLangParseNode i in children)
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

        foreach (GolLangParseNode i in children)
        {
            i.unvisit();
        }
    }
}