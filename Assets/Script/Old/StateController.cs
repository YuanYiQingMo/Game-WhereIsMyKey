using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private int level;
    public int maxLevel = 17;
    void Start()
    {
        level = 1;
    }
    public void LevelUp()
    {
        if (level < maxLevel)
        {
            level++;
        }
    }
    public void LevelDown()
    {
        if (level > 1)
        {
            level--;
        }
    }
}
