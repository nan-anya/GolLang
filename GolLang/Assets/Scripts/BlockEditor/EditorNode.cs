using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EditorNode : MonoBehaviour
{
    public GolLangNode golLangNode;

    public List<Block> blocks;

    public EditorNode parents;

    public EditorNode leftSibling;

    public EditorNode rightSibling;

    public List<EditorNode> children;

    public void Start()
    {
        golLangNode = new GolLangNode(new GolLangLine());

        blocks = new List<Block>();

        parents = null;

        leftSibling = null;

        rightSibling = null;

        children = new List<EditorNode>();
    }

    public void attachBlockRight(Block left, Block right)
    {
        int leftIndex = golLangNode.line.keywords.IndexOf(left.keyword);

        right.node = this;

        blocks.Insert(leftIndex + 1, right);

        golLangNode.line.keywords.Insert(leftIndex + 1, right.keyword);
    }

    public void attachBlockChild(Block child)
    {
        GameObject childNode = Instantiate(Resources.Load("Prefabs/FinalPrefabs/Others/EditorNode")) as GameObject;

        EditorNode childEditorNode = childNode.GetComponent<EditorNode>();

        childEditorNode.blocks.Add(child);
        childEditorNode.golLangNode.line.keywords.Add(child.keyword);
       
        childEditorNode.parents = this;
        this.children.Add(childEditorNode);
    }

    public void attachBlockSibling(Block sibling)
    {
        GameObject siblingNode = Instantiate(Resources.Load("Prefabs/FinalPrefabs/Others/EditorNode")) as GameObject;

        EditorNode siblingEditorNode = siblingNode.GetComponent<EditorNode>();

        siblingEditorNode.blocks.Add(sibling);
        siblingEditorNode.golLangNode.line.keywords.Add(sibling.keyword);

        siblingEditorNode.leftSibling = this;
        this.rightSibling = siblingEditorNode;
    }
    public void adjustSiblingTrigger()
    {
        Transform head = blocks[0].gameObject.transform.Find("SiblingTrigger");

        if (head != null)
        {
            head.position = new Vector3(1.905F, -2.54F * height(), 0);
        }
        if (parents != null)
        {
            parents.adjustSiblingTrigger();
        }
    }

    public int height()
    {
        int h = 1;

        foreach (EditorNode i in children)
        {
            h += i.height();
        }

        return h;
    }
}
