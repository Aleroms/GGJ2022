using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Binary_Switch : Binary_Variable
{
    // It is expected that this switch is a UI button
    public override void SetResult()
    {
        result = !result;
        ChangeColor();
    }

    
}
