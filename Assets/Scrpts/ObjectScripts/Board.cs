using System.Collections.Generic;
using Scrpts.ObjectScripts.Pieces;
using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts
{
    public class Board : MonoBehaviour
    {
        public Slice[,] SliceList;
        public List<Piece> blackPieceList;
        public List<Piece> whitePieceList;
        public Slice slice;

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
        
        // Start is called before the first frame update
        private void Start()
        {
            _boardHeight = 0.5f * transform.localScale.y;
            _boardSize = transform.localScale.x;
            _pieceSize = 1f;
            InitSlices();
            InitPieces(0);
            InitPieces(1);

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
                    .AddItem(PieceInitializer(bishopObject, color, "Bishop-Black-1", GetPositionFromSlice(new Vector2Int(2, 0), bishopObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(bishopObject, color, "Bishop-Black-2", GetPositionFromSlice(new Vector2Int(5, 0), bishopObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(rookObject, color, "Rook-Black-1", GetPositionFromSlice(new Vector2Int(0, 0), rookObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(rookObject, color, "Rook-Black-2", GetPositionFromSlice(new Vector2Int(7, 0), rookObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(knightObject, color, "Knight-Black-1", GetPositionFromSlice(new Vector2Int(1, 0), knightObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(knightObject, color, "Knight-Black-2", GetPositionFromSlice(new Vector2Int(6, 0), knightObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(kingObject, color, "King-Black-1", GetPositionFromSlice(new Vector2Int(3, 0), kingObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(queenObject, color, "Queen-Black-1", GetPositionFromSlice(new Vector2Int(4, 0), queenObject.transform.localScale.y)))
                    .GetList();
                for (var i = 1; i <= 8; i++)
                {
                    var pawn = Instantiate(pawnObject);
                    pawn.Initialize(color, "pawn-Black-" + i, GetPositionFromSlice(new Vector2Int(i - 1, 1), pawn.transform.localScale.y));
                }
            }
            else {
                whitePieceList = new ListChain<Piece>()
                    .AddItem(PieceInitializer(bishopObject, color, "Bishop-White-1", GetPositionFromSlice(new Vector2Int(2, 7), bishopObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(bishopObject, color, "Bishop-White-2", GetPositionFromSlice(new Vector2Int(5, 7), bishopObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(rookObject, color, "Rook-White-1", GetPositionFromSlice(new Vector2Int(0, 7), rookObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(rookObject, color, "Rook-White-2", GetPositionFromSlice(new Vector2Int(7, 7), rookObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(knightObject, color, "Knight-White-1", GetPositionFromSlice(new Vector2Int(1, 7), knightObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(knightObject, color, "Knight-White-2", GetPositionFromSlice(new Vector2Int(6, 7), knightObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(kingObject, color, "King-White-1", GetPositionFromSlice(new Vector2Int(3, 7), kingObject.transform.localScale.y)))
                    .AddItem(PieceInitializer(queenObject, color, "Queen-White-1", GetPositionFromSlice(new Vector2Int(4, 7), queenObject.transform.localScale.y)))
                    .GetList();
                for (var i = 1; i <= 8; i++)
                {
                    var pawn = Instantiate(pawnObject);
                    pawn.Initialize(color, "pawn-White-" + i, GetPositionFromSlice(new Vector2Int(i - 1, 6), pawn.transform.localScale.y));
                }
            }

        }

        private static Piece PieceInitializer(Piece piece, int color, string name, Vector3 pos)
        {
            var pieceObject = Instantiate(piece);
            pieceObject.Initialize(color, name, pos);
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
    }
}
