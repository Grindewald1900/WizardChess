﻿using System.Collections;
using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;

public class InitConfig : MonoBehaviour
{
    // When pieces animation is ongoing, other pieces are unclickable
    public static bool IsClickable;
    // Player and AI move their pieces in turn
    public static bool IsPlayerTurn;

    public const int STATE_NORMAL = 100;
    public const int STATE_SELECTED = 101;
    public const int STATE_HIGHLIGHT = 102;
    public const int BOARD_SIZE = 8;
    
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
