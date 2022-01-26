using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Binary_Variable : MonoBehaviour
{
    protected bool result;

    private void Start() 
    {
        ChangeColor();
    }

    public virtual void SetResult() 
    {
        // Temporary function. Other classes should override this
        ChangeColor();
    }

    public bool GetResult() 
    {
        return result;
    }

    protected void ChangeColor() 
    {
        if (result)
            GetComponent<Image>().color = new Color(0, 255, 0, 100);
        else
            GetComponent<Image>().color = new Color(255, 0, 0, 100);
    }
}
