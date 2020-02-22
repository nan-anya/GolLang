using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolLangInterpreter : MonoBehaviour
{
    public GolLangTree gTree;
    
    public List<GolLangVarData> vars;

    public void preorderTraversal(GolLangTree t)
    {
        GolLangNode now = t.head;

        if (now.hasChildren())
        {

        }
        else
        {
            
        }
    }

    public void interpret()
    { 
        
    }
}
