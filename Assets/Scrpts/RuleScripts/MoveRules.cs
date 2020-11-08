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
        public List<Vector2Int> Diagonal(Vector2Int index, int stride, bool isBlack)
        {
            Slice[,] sliceList = Board.SharedInstance.GetSliceList();
            var dList = new List<Vector2Int>();
            var tl = 1;
            var tr = 1;
            var bl = 1;
            var br = 1;
            while (index.x - tl >= Math.Max(0, index.x - stride) && index.y + tl <= Math.Min(7, index.y + stride)) {
                if (!sliceList[index.x - tl, index.y + tl].pieceName.Contains("Piece")) {
                    dList.Add(new Vector2Int(index.x - tl, index.y + tl));
                }else {
                    if (!StringTools.ComparePieceColor(sliceList[index.x - tl, index.y + tl].pieceName, isBlack)) {
                        dList.Add(new Vector2Int(index.x - tl, index.y + tl));
                    }
                    break;
                }
                // dList.Add(new Vector2Int(index.x - tl, index.y + tl));
                // if (sliceList[index.x - tl, index.y + tl].pieceName.Contains("Piece")) break;
                tl++;
            }
            while (index.x + tr <= Math.Min(7, index.x + stride) && index.y + tr <= Math.Min(7, index.y + stride)) {
                if (!sliceList[index.x + tr, index.y + tr].pieceName.Contains("Piece")) {
                    dList.Add(new Vector2Int(index.x + tr, index.y + tr));
                }else {
                    if (!StringTools.ComparePieceColor(sliceList[index.x + tr, index.y + tr].pieceName, isBlack)) {
                        dList.Add(new Vector2Int(index.x + tr, index.y + tr));
                    }
                    break;
                }
                // dList.Add(new Vector2Int(index.x + tr, index.y + tr));
                // if (sliceList[index.x + tr, index.y + tr].pieceName.Contains("Piece")) break;
                tr++;
            }
            while (index.x - bl >= Math.Max(0, index.x - stride) && index.y - bl >= Math.Max(0, index.y - stride)) {
                if (!sliceList[index.x - bl, index.y - bl].pieceName.Contains("Piece")) {
                    dList.Add(new Vector2Int(index.x - bl, index.y - bl));
                }else {
                    if (!StringTools.ComparePieceColor(sliceList[index.x - bl, index.y - bl].pieceName, isBlack)) {
                        dList.Add(new Vector2Int(index.x - bl, index.y - bl));
                    }
                    break;
                }
                // dList.Add(new Vector2Int(index.x - bl, index.y - bl));
                // if (sliceList[index.x - bl, index.y - bl].pieceName.Contains("Piece")) break;
                bl++;
            }
            while (index.x + br <= Math.Min(7, index.x + stride) && index.y - br >= Math.Max(0, index.y - stride)) {
                if (!sliceList[index.x + br, index.y - br].pieceName.Contains("Piece")) {
                    dList.Add(new Vector2Int(index.x + br, index.y - br));
                }else {
                    if (!StringTools.ComparePieceColor(sliceList[index.x + br, index.y - br].pieceName, isBlack)) {
                        dList.Add(new Vector2Int(index.x + br, index.y - br));
                    }
                    break;
                }
                // dList.Add(new Vector2Int(index.x + br, index.y - br));
                // if (sliceList[index.x + br, index.y - br].pieceName.Contains("Piece")) break;
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
        public List<Vector2Int> Horizontal(Vector2Int index, int stride, bool isBlack)
        {
            var vList = new List<Vector2Int>();
            var r = index.x + 1;
            var l = index.x - 1;
            var sliceList = Board.SharedInstance.SliceList;
            while (l >= Math.Max(0, index.x - stride)) {
                if (!sliceList[l, index.y].pieceName.Contains("Piece")) {
                    vList.Add(new Vector2Int(l, index.y));
                }else {
                    if (!StringTools.ComparePieceColor(sliceList[l, index.y].pieceName, isBlack)) {
                        vList.Add(new Vector2Int(l, index.y));
                    }
                    break;
                }
                // vList.Add(new Vector2Int(l, index.y));
                // if (sliceList[l, index.y].pieceName.Contains("Piece")) break;
                l--;
            }
            while (r <= Math.Min(7, index.x + stride)) {
                if (!sliceList[r, index.y].pieceName.Contains("Piece")) {
                    vList.Add(new Vector2Int(r, index.y));
                }else {
                    if (!StringTools.ComparePieceColor(sliceList[r, index.y].pieceName, isBlack)) {
                        vList.Add(new Vector2Int(r, index.y));
                    }
                    break;
                }
                // vList.Add(new Vector2Int(r, index.y));
                // if (sliceList[r, index.y].pieceName.Contains("Piece")) break;
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
        public List<Vector2Int> Vertical(Vector2Int index, int stride, bool isBlack)
        {
            var hList = new List<Vector2Int>();
            var t = index.y + 1;
            var b = index.y - 1;
            var sliceList = Board.SharedInstance.SliceList;
            while (b >= Math.Max(0, index.y - stride)) {
                if (!sliceList[index.x, b].pieceName.Contains("Piece")) {
                    hList.Add(new Vector2Int(index.x, b));
                }else {
                    if (!StringTools.ComparePieceColor(sliceList[index.x, b].pieceName, isBlack)) {
                        hList.Add(new Vector2Int(index.x, b));
                    }
                    break;
                }
                b--;
            }
            while (t <= Math.Min(7, index.y + stride)) {
                if (!sliceList[index.x, t].pieceName.Contains("Piece")) {
                    hList.Add(new Vector2Int(index.x, t));
                }else {
                    if (!StringTools.ComparePieceColor(sliceList[index.x, t].pieceName, isBlack)) {
                        hList.Add(new Vector2Int(index.x, t));
                    }
                    break;
                }
                t++;
            }
            return hList;
        }

        // /// <summary>
        // /// Return a list of vector2, which include all the slices available for pawn(if first time clicked)
        // /// </summary>
        // /// <param name="index">The point of selected piece</param>
        // /// <param name="stride">The stride of the piece</param>
        // /// <returns>list of vector2</returns>
        // public List<Vector2Int> PawnFirst(Vector2Int index, int stride, bool isPlayer)
        // {
        //     var pList = new List<Vector2Int>();
        //     pList = isPlayer ? PawnDetail(pList, index.x, index.y + 1) : PawnDetail(pList, index.x, index.y - 1);
        //     pList.Add(isPlayer ? new Vector2Int(index.x, index.y + 2) : new Vector2Int(index.x, index.y - 2));
        //
        //     // for (var i = 1; i <= 2; i++) {
        //     //     pList.Add(isPlayer ? new Vector2Int(index.x, index.y + i) : new Vector2Int(index.x, index.y - i));
        //     // }
        //     return pList;
        // }

        /// <summary>
        /// Return a list of vector2, which include all the slices available for pawn(if not the first time)
        /// </summary>
        /// <param name="index">The point of selected piece</param>
        /// <param name="stride">The stride of the piece</param>
        /// <param name="isPlayer"></param>
        /// <param name="isFirst"></param>
        /// <returns>list of vector2</returns>
        public List<Vector2Int> Pawn(Vector2Int index, int stride, bool isPlayer, bool isFirst)
        {
            var  pList = new List<Vector2Int>();
            var p = isPlayer ? 1 : -1;
            pList = isPlayer ? PawnDetail(pList, index.x, index.y + 1) : PawnDetail(pList, index.x, index.y - 1);
            if (!isFirst) return pList;
            // If first time, if slice[x, y+1] is not empty or slice[x, y+2] has the same color, slice[x, y+2] won't be added to list
            if (Board.SharedInstance.SliceList[index.x, index.y + (isPlayer ? 1 : -1)].pieceName != "" 
                || StringTools.ComparePieceColor(Board.SharedInstance.SliceList[index.x, index.y + (isPlayer ? 2 : -2)].pieceName, isPlayer)) {
                return pList;
            }
            pList.Add(isPlayer ? new Vector2Int(index.x, index.y + 2) : new Vector2Int(index.x, index.y - 2));
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
        public List<Vector2Int> Knight(Vector2Int index, bool isBlack)
        {
            var  kList = new List<Vector2Int>();
            for (var i = 0; i < InitConfig.BOARD_SIZE; i++)
            {
                for (var j = 0; j < InitConfig.BOARD_SIZE; j++)
                {
                    if ((Math.Abs(index.x - i) == 1 && Math.Abs(index.y - j) == 2) || (Math.Abs(index.x - i) == 2 && Math.Abs(index.y - j) == 1))
                    {
                        // If the destination is empty or has an opponent on it, add that slice to list
                        if (!StringTools.ComparePieceColor(Board.SharedInstance.SliceList[i, j].pieceName, isBlack))
                        {
                            kList.Add(new Vector2Int(i, j));
                        }
                    }
                }
            }
            return kList;
        }

        /// <summary>
        /// Get all available slices 
        /// </summary>
        /// <param name="index">Index of piece selected</param>
        /// <param name="pType">InitConfig piece type</param>
        /// <returns>list of vector2</returns>
        public List<Vector2Int> GetAvailableSlice(Vector2Int index, int pType, bool isPlayer, bool isFirst)
        {
            var list = new List<Vector2Int>();
            switch (pType)
            {
                case InitConfig.PIECE_PAWN:
                    if (!(isPlayer && index.y == InitConfig.BOARD_SIZE - 1) && !(!isPlayer && index.y == 0)) 
                        break;
                    list.AddRange(Pawn(index, 1, isPlayer, isFirst));
                    break;
                case InitConfig.PIECE_ROOK:
                    list.AddRange(Horizontal(index, 10, isPlayer));
                    list.AddRange(Vertical(index, 10, isPlayer));
                    break;
                case InitConfig.PIECE_KNIGHT:
                    list.AddRange(Knight(index, isPlayer));
                    break;
                case InitConfig.PIECE_BISHOP:
                    list.AddRange(Diagonal(index, 10, isPlayer));
                    break;
                case InitConfig.PIECE_QUEEN:
                    list.AddRange(Horizontal(index, 10, isPlayer));
                    list.AddRange(Vertical(index, 10, isPlayer));
                    list.AddRange(Diagonal(index, 10, isPlayer));
                    break;
                case InitConfig.PIECE_KING:
                    list.AddRange(Horizontal(index, 1, isPlayer));
                    list.AddRange(Vertical(index, 1, isPlayer));
                    list.AddRange(Diagonal(index, 1, isPlayer));
                    break;
            }
            return list;
        }
        
    }
}