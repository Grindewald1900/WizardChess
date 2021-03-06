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
    // AI types according to main setting value
    public static int AI_TYPE;
    // If true, 2 AI players
    public static bool DUAL_AI;
    
    public const int STATE_NORMAL = 100;
    public const int STATE_SELECTED = 101;
    public const int STATE_HIGHLIGHT = 102;
    public const int BOARD_SIZE = 8;

    public const int SCORE_PAWN = 10;
    public const int SCORE_KNIGHT = 30;
    public const int SCORE_BISHOP = 30;
    public const int SCORE_ROOK = 50;
    public const int SCORE_QUEEN = 100;
    public const int SCORE_KING = 1000;

    public const int PIECE_PAWN = 1;
    public const int PIECE_KNIGHT = 2;
    public const int PIECE_BISHOP = 3;
    public const int PIECE_ROOK = 4;
    public const int PIECE_QUEEN = 5;
    public const int PIECE_KING = 6;

    public const int AI_MINIMAX_LOOP = 201;
    public const int AI_MINIMAX_ALPHA_BETA = 202;
    public const int AI_RANDOM = 203;

    public const int IDLE = 301;
    public const int WALK = 302;
    public const int ATTACK = 303;
    public const int GETATTACK = 304;
    public const int DIE = 305;


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
