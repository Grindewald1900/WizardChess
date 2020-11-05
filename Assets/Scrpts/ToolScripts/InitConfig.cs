using System.Collections;
using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;

public class InitConfig : MonoBehaviour
{
    // When pieces animation is ongoing, other pieces are unclickable
    public static bool IsClickable;
    // Start is called before the first frame update
    private void Start()
    {
        LogUtils.SetMode(LogUtils.MODE_DEBUG);
        IsClickable = true;
    }

    // Getter and Setter for is clickable;
    public static void SetClickable(bool clickable)
    {
        IsClickable = clickable;
    }

    public static bool GetClickable()
    {
        return IsClickable;
    }

}
