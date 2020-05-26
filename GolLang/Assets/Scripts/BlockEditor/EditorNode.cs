using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class EditorNode
{
    public GolLangNode golLangNode;

    public List<Block> blocks;

    public EditorNode parents;

    public EditorNode leftSibling;

    public EditorNode rightSibling;

    public List<EditorNode> children;

    public EditorNode()
    {
        golLangNode = new GolLangNode(new GolLangLine());

        blocks = new List<Block>();

        parents = null;

        leftSibling = null;

        rightSibling = null;

        children = new List<EditorNode>();
    }

    public EditorNode(Block firstBlock)
    {
        golLangNode = new GolLangNode(new GolLangLine());



        golLangNode.line.keywords.Add(firstBlock.keyword);

        blocks = new List<Block>();
        blocks.Add(firstBlock);

        firstBlock.node = this;

        parents = null;

        leftSibling = null;

        rightSibling = null;

        children = new List<EditorNode>();
    }

    public void attachBlockRight(Block right)
    {
        right.node = this;

        blocks.Add(right);

        golLangNode.line.keywords.Add(right.keyword);
    }

    public void attachBlockChild(Block child)
    {
        EditorNode childEditorNode = new EditorNode(child);

        childEditorNode.parents = this;
        children.Add(childEditorNode);

        golLangNode.addChild(childEditorNode.golLangNode);
    }

    public void attachBlockSibling(Block sibling)
    {
        EditorNode siblingEditorNode = new EditorNode(sibling);

        siblingEditorNode.leftSibling = this;
        rightSibling = siblingEditorNode;

        siblingEditorNode.parents = parents;
        parents.children.Add(siblingEditorNode);

        parents.golLangNode.addChild(siblingEditorNode.golLangNode);
    }
    
    public void adjustSiblingTrigger()
    {
        Transform head = blocks[0].gameObject.transform.Find("SiblingTrigger");

        MeshFilter m = blocks[0].gameObject.GetComponent<MeshFilter>();//.mesh.name.Contains("LongBlock2");

        if (head != null && m.mesh.name.Contains("LongBlock2"))
        {
            head.localPosition = new Vector3(head.localPosition.x, -2.54F * height(), 0);
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

        if (blocks[0].gameObject.GetComponent<MeshFilter>().mesh.name.Contains("LongBlock2"))
        {
            return h + 1;
        }

        return h;
    }
}
