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
