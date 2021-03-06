﻿using System;
using System.Collections.Generic;
using System.Linq;
using Scrpts.ObjectScripts.Pieces;
using Scrpts.RuleScripts;
using Scrpts.ToolScripts;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Scrpts.ObjectScripts
{
    public class Board : MonoBehaviour
    {
        public static Board SharedInstance;
        public Slice[,] SliceList;
        public string selectedPiece;
        public int playerScore;
        public int aiScore;
        public List<Piece> blackPieceList;
        public List<Piece> whitePieceList;
        public Slice slice;
        // public Canvas scoreCanvas;
        public Text scoreText;
        public Text hintText;
        public Text recordText;

        public Bishop bishopObject;
        public Rook rookObject;
        public Knight knightObject;
        public Queen queenObject;
        public King kingObject;
        public Pawn pawnObject;
        // Half of the board height, which provides a y coordinate for every pieces on the board.
        private float _boardHeight;
        private float _boardSize;
        private float _pieceSize;
        private string _record;

        private Vector3 _mousePosition;
        
        // Start is called before the first frame update
        private void Start()
        {
            SharedInstance = this;
            _boardHeight = 0.5f * transform.localScale.y;
            _boardSize = transform.localScale.x;
            _pieceSize = 1f;
            playerScore = 0;
            aiScore = 0;
            InitConfig.IsPlayerTurn = true;
            InitConfig.AI_TYPE = InitConfig.AI_MINIMAX_LOOP;
            InitConfig.DUAL_AI = false;
            InitSlices();
            InitPieces(0);
            InitPieces(1);
            LogUtils.Log("Is Dual:" + InitConfig.DUAL_AI);
            if (InitConfig.DUAL_AI)
            {
                GameObject.Find("Piece-Pawn-Black-2").GetComponent<Piece>().MoveToSlice(new Vector2Int(1,3));
            }
        }

        private void Update()
        {
            // OnBoardClicked();
        }

        private void FixedUpdate()
        {
            
        }


        // private void InitLocation()
        // {
        //     var position = transform.position;
        //     var localScale = transform.localScale;
        //     var x = position.x + localScale.x * 0.5f;
        //     var y = position.y;
        //     var z = position.z + localScale.z * 0.5f;
        //     transform.position = new Vector3(x, y, z);
        // }

        // Initialize 8*8 slices of board, located at the center of the board
        private void InitSlices()
        {
            SliceList = new Slice[8, 8];
            // sliceList = new List<Slice>();
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    var sliceObject = Instantiate(slice);
                    var x = _boardSize * 0.1f * (1 + i) + _pieceSize * 0.5f;
                    var y = transform.position.y + _boardHeight;
                    var z = _boardSize * 0.1f * (1 + j) + _pieceSize * 0.5f;
                    // Set object name which is followed by their index in the array
                    sliceObject.name = "Slice-" + i + "-" + j;
                    sliceObject.transform.position = new Vector3(x,y,z);
                    // Setup piece color with Black and White according to the index of raw and column
                    sliceObject.SetColor((i + j + 2) % 2);
                    SliceList[i, j] = sliceObject;
                    // sliceList.Add(sliceObject);
                    // LogUtils.Log(new Vector3(x,y,z));
                }
            }
        }

        // Initialize pieces
        /// <param name="color">Used to distinguish black and white piece list</param>
        private void InitPieces(int color)
        {
            if (color == 0) {
                blackPieceList = new ListChain<Piece>()
                    .AddItem(PieceInitializer(bishopObject, color, "Piece-Bishop-Black-1", GetPositionFromSlice(new Vector2Int(2, 0), 0f), new Vector2Int(2, 0)))
                    .AddItem(PieceInitializer(bishopObject, color, "Piece-Bishop-Black-2", GetPositionFromSlice(new Vector2Int(5, 0), 0f), new Vector2Int(5, 0)))
                    .AddItem(PieceInitializer(rookObject, color, "Piece-Rook-Black-1", GetPositionFromSlice(new Vector2Int(0, 0), rookObject.transform.localScale.y), new Vector2Int(0, 0)))
                    .AddItem(PieceInitializer(rookObject, color, "Piece-Rook-Black-2", GetPositionFromSlice(new Vector2Int(7, 0), rookObject.transform.localScale.y), new Vector2Int(7, 0)))
                    .AddItem(PieceInitializer(knightObject, color, "Piece-Knight-Black-1", GetPositionFromSlice(new Vector2Int(1, 0), 0f), new Vector2Int(1, 0)))
                    .AddItem(PieceInitializer(knightObject, color, "Piece-Knight-Black-2", GetPositionFromSlice(new Vector2Int(6, 0), 0f), new Vector2Int(6, 0)))
                    .AddItem(PieceInitializer(kingObject, color, "Piece-King-Black-1", GetPositionFromSlice(new Vector2Int(3, 0), kingObject.transform.localScale.y), new Vector2Int(3, 0)))
                    .AddItem(PieceInitializer(queenObject, color, "Piece-Queen-Black-1", GetPositionFromSlice(new Vector2Int(4, 0), 0f), new Vector2Int(4, 0)))
                    .GetList();
                for (var i = 1; i <= 8; i++)
                {
                    blackPieceList.AddRange(new ListChain<Piece>()
                        .AddItem(PieceInitializer(pawnObject, color, "Piece-Pawn-Black-" + i, GetPositionFromSlice(new Vector2Int(i - 1, 1), pawnObject.transform.localScale.y), new Vector2Int(i - 1, 1)))
                        .GetList());
                    // var pawn = Instantiate(pawnObject);
                    // pawn.Initialize(color, "Piece-pawn-Black-" + i, GetPositionFromSlice(new Vector2Int(i - 1, 1), pawn.transform.localScale.y), new Vector2Int(i - 1, 1));
                }
            }
            else {
                whitePieceList = new ListChain<Piece>()
                    .AddItem(PieceInitializer(bishopObject, color, "Piece-Bishop-White-1", GetPositionFromSlice(new Vector2Int(2, 7), 0f), new Vector2Int(2, 7)))
                    .AddItem(PieceInitializer(bishopObject, color, "Piece-Bishop-White-2", GetPositionFromSlice(new Vector2Int(5, 7), 0f), new Vector2Int(5, 7)))
                    .AddItem(PieceInitializer(rookObject, color, "Piece-Rook-White-1", GetPositionFromSlice(new Vector2Int(0, 7), rookObject.transform.localScale.y), new Vector2Int(0, 7)))
                    .AddItem(PieceInitializer(rookObject, color, "Piece-Rook-White-2", GetPositionFromSlice(new Vector2Int(7, 7), rookObject.transform.localScale.y), new Vector2Int(7, 7)))
                    .AddItem(PieceInitializer(knightObject, color, "Piece-Knight-White-1", GetPositionFromSlice(new Vector2Int(1, 7), 0f), new Vector2Int(1, 7)))
                    .AddItem(PieceInitializer(knightObject, color, "Piece-Knight-White-2", GetPositionFromSlice(new Vector2Int(6, 7), 0f), new Vector2Int(6, 7)))
                    .AddItem(PieceInitializer(kingObject, color, "Piece-King-White-1", GetPositionFromSlice(new Vector2Int(3, 7), kingObject.transform.localScale.y), new Vector2Int(3, 7)))
                    .AddItem(PieceInitializer(queenObject, color, "Piece-Queen-White-1", GetPositionFromSlice(new Vector2Int(4, 7), 0f), new Vector2Int(4, 7)))
                    .GetList();
                for (var i = 1; i <= 8; i++)
                {
                    whitePieceList.AddRange(new ListChain<Piece>()
                        .AddItem(PieceInitializer(pawnObject, color, "Piece-Pawn-White-" + i, GetPositionFromSlice(new Vector2Int(i - 1, 6), pawnObject.transform.localScale.y), new Vector2Int(i - 1, 6)))
                        .GetList());
                    // var pawn = Instantiate(pawnObject);
                    // pawn.Initialize(color, "Piece-pawn-White-" + i, GetPositionFromSlice(new Vector2Int(i - 1, 6), pawn.transform.localScale.y), new Vector2Int(i - 1, 6));
                    // SliceList[i - 1, 6].SetPieceName();
                }
            }

        }

        /// <summary>
        /// Instantiate a certain piece with parameters
        /// </summary>
        /// <param name="piece">piece object to be instantiated</param>
        /// <param name="color">piece color</param>
        /// <param name="pName">reset piece name e.g. Piece-Pawn-White-1 </param>
        /// <param name="pos">initial position</param>
        /// <param name="index">index of the slice that the piece stand on</param>
        /// <returns></returns>
        private Piece PieceInitializer(Piece piece, int color, string pName, Vector3 pos, Vector2Int index)
        {
            var pieceObject = Instantiate(piece);
            pieceObject.Initialize(color, pName, pos, index);
            SliceList[index.x, index.y].SetPieceName(pName);
            return pieceObject;
        }


        /// <summary>
        /// Return the destination position of piece
        /// </summary>
        /// <param name="index">objective slice index</param>
        /// <param name="objectHeight">piece height</param>
        /// <returns>Destination position of piece</returns>
        private Vector3 GetPositionFromSlice(Vector2Int index, float objectHeight)
        {
            var slicePosition = SliceList[index.x, index.y].transform.position;
            return new Vector3(slicePosition.x, slicePosition.y + objectHeight * 0.5f, slicePosition.z);
        }
        

        // Another method to detect which object is selected.
        private void OnBoardClicked()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            _mousePosition = Input.mousePosition;
            try {
                var castPoint = Camera.main.ScreenPointToRay(_mousePosition);
                if (!Physics.Raycast(castPoint, out var hit, Mathf.Infinity)) return;
                var hitName = hit.collider.name;
                if (hitName.Contains("Piece"))
                {
                    LogUtils.Log(hitName);
                }

                if (hitName.Contains("Slice"))
                {
                    LogUtils.Log("Slice:" + hitName);
                }

            }catch (Exception e) {
                LogUtils.LogError(e.Message);
            }
        }

        public Slice[,] GetSliceList()
        {
            return SliceList;
        }

        /// <summary>
        /// Change Slice state
        /// </summary>
        /// <param name="index">The index of slice</param>
        /// <param name="state">Target State</param>
        public void ChangeSliceState(Vector2Int index, int state)
        {
            // Debug.Log(state);
            // Debug.Log(index);
            switch (state)
            {
                case InitConfig.STATE_NORMAL:
                    SliceList[index.x, index.y].Normal();
                    break;
                case InitConfig.STATE_SELECTED: 
                    SliceList[index.x, index.y].Selected();
                    break;
                case InitConfig.STATE_HIGHLIGHT: 
                    SliceList[index.x, index.y].HighLight();
                    break;
                default:
                        break;
            }
        }

        // Highlight all the available slice when a certain piece is selected
        public void MarkAvailableSlice(List<Vector2Int> mList)
        {
            foreach (var item in mList)
            {
                SliceList[item.x, item.y].HighLight();
            }
        }

        // Reset all slices state to normal
        public void ClearAllMarkSlice()
        {
            selectedPiece = "";
            foreach (var item in SliceList)
            {
                item.Normal();
            }
        }

        // Edit score board and hint on the screen
        // e.g. Score: 50 - 150
        // e.g. "Your turn"
        public void EditScore(int pScore, int aScore)
        {
            playerScore += Math.Abs(pScore);
            aiScore += Math.Abs(aScore);
            scoreText.text = "Score: " + playerScore + " - " + aiScore;
            hintText.text = InitConfig.IsPlayerTurn ? "Your turn" : "AI turn";
        }

        public void EditHint(string hint)
        {
            hintText.text = hint;
        }
        public void EditRecord(string pName, Vector2Int fromIndex, Vector2Int toIndex)
        {
            _record += "\n" + pName + ": Move from " + fromIndex + " To " + toIndex;
            recordText.text = _record;
        }

        // public void AutoPlay()
        // {
        //     if(InitConfig.IsPlayerTurn) return;
        //     var maxLoop = new MiniMaxLoop(InitConfig.IsPlayerTurn);
        //     maxLoop.AutoPlay();
        // }
        
        
        // Get total score 
        // public int GetTotalScore()
        // {
        //     
        // }
    }
}
