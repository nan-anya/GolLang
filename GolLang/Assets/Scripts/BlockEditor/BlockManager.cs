using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public EditorNode firstLine;

    public GolLangInterpreter interpreter;
    
    //Battle



    public void Start()
    {
        interpreter = transform.GetComponent<GolLangInterpreter>();

        interpreter.monster = GameObject.Find("Enemy").GetComponent<Monster>();

        interpreter.golem = GameObject.Find("Golem").GetComponent<Golem>();

        Block b = transform.Find("StartHere").GetComponent<Block>();

        b.initBlock(Block.BlockKind.STARTHERE);

        firstLine = new EditorNode(b);
    }

    public void run()
    {
        interpreter.gTree.head = firstLine.golLangNode;

        StartCoroutine(interpreter.interpret());
    }

    
}
