using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangNode : MonoBehaviour
{
    public List<GolLangNode> children;

    public GolLangLine line;

    public GolLangNode(GolLangLine line)
    {
        children = new List<GolLangNode>();

        this.line = line;
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
