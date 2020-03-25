using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangNode
{
    public List<GolLangNode> children;

    public GolLangLine line;

    public GolLangNode(GolLangLine line)
    {
        children = new List<GolLangNode>();

        this.line = line;
    }

    public void addChild(GolLangNode child)
    {
        children.Add(child);
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
}
