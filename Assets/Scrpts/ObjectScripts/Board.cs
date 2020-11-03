using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts
{
    public class Board : MonoBehaviour
    {
        public Slice[,] sliceList;
        public List<Piece> blackPieceList;
        public List<Piece> whitePieceList;
        public Slice slice;
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
            LogUtils.Log("height" + _boardHeight);
            LogUtils.Log(gameObject.name + transform.position);
            LogUtils.Log(gameObject.name + transform.localScale);

        }

        // Update is called once per frame
        private void Update()
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
            sliceList = new Slice[8, 8];
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
                    sliceList[i, j] = sliceObject;
                    // sliceList.Add(sliceObject);
                    LogUtils.Log(new Vector3(x,y,z));
                }
            }
        }

        // Initialize pieces
        /// <param name="color">Used to distinguish black and white piece list</param>
        private void InitPieces(int color)
        {
            if (color == 0) {
                blackPieceList = new List<Piece>();
                
            }

        }
    }
}
