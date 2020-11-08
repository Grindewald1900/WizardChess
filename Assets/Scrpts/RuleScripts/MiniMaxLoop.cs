﻿using System;
using System.Collections;
using System.Collections.Generic;
using Scrpts.ObjectScripts;
using Scrpts.RuleScripts;
using Scrpts.ToolScripts;
using UnityEngine;
using Random = System.Random;

public class MiniMaxLoop
{
    private List<Piece> playerList;
    private List<Piece> aiList;
    private int _depth;
    private int _bestScore;
    private Vector2Int _bestIndex;
    private Piece _bestPiece;
    private bool _isBlackSide;
    private MoveRules _moveRules;

    public MiniMaxLoop(bool side)
    {
        playerList = Board.SharedInstance.blackPieceList;
        aiList = Board.SharedInstance.whitePieceList;
        _moveRules = new MoveRules();
        _bestScore = 0;
        _isBlackSide = side;
    }

    public void AutoPlay()
    {
        if(_isBlackSide) return;
        LogUtils.Log("Auto play");
        LogUtils.Log("Size: " + aiList.Count);
        foreach (var item in aiList)
        {
            var type = StringTools.GetPieceType(item.gameObject.name);
            var list = _moveRules.GetAvailableSlice(item.GetIndex(), type, _isBlackSide, false);
            // If no available slice, turn to next piece
            if (list.Count == 0)
                continue;
            
            // For each available slice, check if there's piece on it. If so, compare the piece value with current best score
            foreach (var index in list)
            {
                var slice = Board.SharedInstance.SliceList[index.x, index.y];
                if (slice.pieceName == "") continue;
                if (GameObject.Find(slice.pieceName).GetComponent<Piece>().pieceScore <= _bestScore) continue;
                _bestScore = GameObject.Find(slice.pieceName).GetComponent<Piece>().pieceScore;
                _bestIndex = index;
                _bestPiece = item;
            }
        }

        if (_bestScore == 0)
        {
            while (true)
            {
                _bestPiece = aiList[new Random().Next(aiList.Count)];
                var type = StringTools.GetPieceType(_bestPiece.gameObject.name);
                var list = _moveRules.GetAvailableSlice(_bestPiece.GetIndex(), type, _isBlackSide, false);
                // If no available slice, turn to next piece
                if (list.Count == 0)
                    continue;
                _bestIndex = list[0];
                break;
            }
            
        }
        LogUtils.Log("_bestScore: " + _bestScore);
        LogUtils.Log("_bestIndex: " + _bestIndex);
        LogUtils.Log("_bestPiece: " + _bestPiece.gameObject.name);

        // Move best piece to index, add best score to total 
        GameObject.Find(_bestPiece.gameObject.name).GetComponent<Piece>().MoveToSlice(_bestIndex);
        Board.SharedInstance.EditScore(0, Math.Abs(_bestScore));
        
    }
}