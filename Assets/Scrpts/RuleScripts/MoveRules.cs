using System;
using System.Collections.Generic;
using Scrpts.ObjectScripts;
using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.RuleScripts
{
    public class MoveRules
    {
        public MoveRules(){}
        
        /// <summary>
        /// Return a list of vector2, which include all the slices available in the Diagonal lines
        /// </summary>
        /// <param name="index">The point of selected piece</param>
        /// <param name="stride">The stride of the piece</param>
        /// <returns>list of vector2</returns>
        public List<Vector2Int> Diagonal(Vector2Int index, int stride)
        {
            Slice[,] sliceList = Board.SharedInstance.GetSliceList();
            var dList = new List<Vector2Int>();
            var tl = 1;
            var tr = 1;
            var bl = 1;
            var br = 1;
            while (index.x - tl >= Math.Max(0, index.x - stride) && index.y + tl <= Math.Min(7, index.y + stride)) {
                dList.Add(new Vector2Int(index.x - tl, index.y + tl));
                // LogUtils.Log(sliceList[index.x - tl, index.y + tl].pieceName);
                if (sliceList[index.x - tl, index.y + tl].pieceName.Contains("Piece")) break;
                tl++;
            }
            while (index.x + tr <= Math.Min(7, index.x + stride) && index.y + tr <= Math.Min(7, index.y + stride)) {
                dList.Add(new Vector2Int(index.x + tr, index.y + tr));
                if (sliceList[index.x + tr, index.y + tr].pieceName.Contains("Piece")) break;
                tr++;
            }
            while (index.x - bl >= Math.Max(0, index.x - stride) && index.y - bl >= Math.Max(0, index.y - stride)) {
                dList.Add(new Vector2Int(index.x - bl, index.y - bl));
                if (sliceList[index.x - bl, index.y - bl].pieceName.Contains("Piece")) break;
                bl++;
            }
            while (index.x + br <= Math.Min(7, index.x + stride) && index.y - br >= Math.Max(0, index.y - stride)) {
                dList.Add(new Vector2Int(index.x + br, index.y - br));
                if (sliceList[index.x + br, index.y - br].pieceName.Contains("Piece")) break;
                br++;
            }
            return dList;
        }
        
        /// <summary>
        /// Return a list of vector2, which include all the slices available in the column
        /// </summary>
        /// <param name="index">The point of selected piece</param>
        /// <param name="stride">The stride of the piece</param>
        /// <returns>list of vector2</returns>
        public List<Vector2Int> Horizontal(Vector2Int index, int stride)
        {
            var vList = new List<Vector2Int>();
            var r = index.x + 1;
            var l = index.x - 1;
            var sliceList = Board.SharedInstance.SliceList;
            while (l >= Math.Max(0, index.x - stride)) {
                vList.Add(new Vector2Int(l, index.y));
                if (sliceList[l, index.y].pieceName.Contains("Piece")) break;
                l--;
            }
            while (r <= Math.Min(7, index.x + stride)) {
                vList.Add(new Vector2Int(r, index.y));
                if (sliceList[r, index.y].pieceName.Contains("Piece")) break;
                r++;
            }
            return vList;
        }
        
        /// <summary>
        /// Return a list of vector2, which include all the slices available in the row
        /// </summary>
        /// <param name="index">The point of selected piece</param>
        /// <param name="stride">The stride of the piece</param>
        /// <returns>list of vector2</returns>
        public List<Vector2Int> Vertical(Vector2Int index, int stride)
        {
            var hList = new List<Vector2Int>();
            var t = index.y + 1;
            var b = index.y - 1;
            var sliceList = Board.SharedInstance.SliceList;
            while (b >= Math.Max(0, index.y - stride)) {
                hList.Add(new Vector2Int(index.x, b));
                if (sliceList[index.x, b].pieceName.Contains("Piece")) break;
                b--;
            }
            while (t <= Math.Min(7, index.y + stride)) {
                hList.Add(new Vector2Int(index.x, t));
                if (sliceList[index.x, t].pieceName.Contains("Piece")) break;
                t++;
            }
            return hList;
        }

        /// <summary>
        /// Return a list of vector2, which include all the slices available for pawn(if first time clicked)
        /// </summary>
        /// <param name="index">The point of selected piece</param>
        /// <param name="stride">The stride of the piece</param>
        /// <returns>list of vector2</returns>
        public List<Vector2Int> PawnFirst(Vector2Int index, int stride, bool isPlayer)
        {
            var pList = new List<Vector2Int>();
            for (var i = 1; i <= 2; i++) {
                pList.Add(isPlayer ? new Vector2Int(index.x, index.y + i) : new Vector2Int(index.x, index.y - i));
            }
            return pList;
        }

        /// <summary>
        /// Return a list of vector2, which include all the slices available for pawn(if not the first time)
        /// </summary>
        /// <param name="index">The point of selected piece</param>
        /// <param name="stride">The stride of the piece</param>
        /// <returns>list of vector2</returns>
        public List<Vector2Int> Pawn(Vector2Int index, int stride, bool isPlayer)
        {
            var  pList = new List<Vector2Int>();
            pList = isPlayer ? PawnDetail(pList, index.x, index.y + 1) : PawnDetail(pList, index.x, index.y - 1);
            return pList;
        }

        /// <summary>
        /// Detail logic for the pawn piece, 
        /// </summary>
        /// <param name="list">list to containing some available index</param>
        /// <param name="indexX">The X index for the selected pawn</param>
        /// <param name="indexY">The Y index of the row in front of the selected pawn</param>
        /// <returns>list of vector2</returns>
        private List<Vector2Int> PawnDetail(List<Vector2Int> list, int indexX, int indexY)
        {
            for (var i = 0; i < InitConfig.BOARD_SIZE; i++)
            {
                if (i == indexX && Board.SharedInstance.SliceList[i, indexY].pieceName == "")
                {
                    list.Add(new Vector2Int(i, indexY));
                }
                if (Math.Abs(i - indexX) == 1 && !string.IsNullOrEmpty(Board.SharedInstance.SliceList[i, indexY].pieceName))
                {
                    list.Add(new Vector2Int(i, indexY));
                }
            }
            return list;
        }

        /// <summary>
        /// Return a list of vector2, which include all the slices available for knight
        /// </summary>
        /// <param name="index">The point of selected piece</param>
        /// <returns>list of vector2</returns>
        public List<Vector2Int> Knight(Vector2Int index)
        {
            var  kList = new List<Vector2Int>();
            for (int i = 0; i < InitConfig.BOARD_SIZE; i++)
            {
                for (int j = 0; j < InitConfig.BOARD_SIZE; j++)
                {
                    if (Math.Abs(index.x - i) == 1 && Math.Abs(index.y - j) == 2)
                    {
                        kList.Add(new Vector2Int(i, j));
                    }
                    if (Math.Abs(index.x - i) == 2 && Math.Abs(index.y - j) == 1)
                    {
                        kList.Add(new Vector2Int(i, j));
                    }
                }
            }
            return kList;
        }
    }
}