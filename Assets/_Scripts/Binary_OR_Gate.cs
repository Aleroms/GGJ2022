using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binary_OR_Gate : Binary_Gate
{
    private bool prev_result;

    private void Start() 
    {
        SetResult();
        prev_result = result;
    }

    private void Update() 
    {
        if (prev_result != ( variables[0].GetResult() || variables[1].GetResult() )) 
        {
            SetResult();
            prev_result = result;
        }
    }

    public override void SetResult() 
    {
        result = variables[0].GetResult() || variables[1].GetResult();
        ChangeColor();
    }
}
