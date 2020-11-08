using UnityEngine;

namespace Scrpts.ToolScripts
{
    public class StringTools
    {
        public static int GetSliceNums(string sName)
        {
            var strList = sName.Split('-');
            return strList.Length > 0 ? int.Parse(strList[1]) + int.Parse(strList[2]) : 0;
        }

        public static int GetPieceType(string pName)
        {
            var strList = pName.Split('-');
            var type = 0;
            switch (strList[1])
            {
                case "Pawn":
                    type = InitConfig.PIECE_PAWN;
                    break;
                case "Rook":
                    type = InitConfig.PIECE_ROOK;
                    break;
                case "Knight":
                    type = InitConfig.PIECE_KNIGHT;
                    break;
                case "Bishop":
                    type = InitConfig.PIECE_BISHOP;
                    break;
                case "Queen":
                    type = InitConfig.PIECE_QUEEN;
                    break;
                case "King":
                    type = InitConfig.PIECE_KING;
                    break;
                default:
                    break;
            }
            return type;
        }

        public static Vector2Int GetSliceIndex(string sName)
        {
            var strList = sName.Split('-');
            return new Vector2Int(int.Parse(strList[1]), int.Parse(strList[2]));
        }

        // Return true if colors are same
        public static bool ComparePieceColor(string pName, bool isBlack)
        {
            if (pName.Equals("")) return false;
            var strList = pName.Split('-');
            if (strList[2].Equals("Black") && isBlack) return true;
            if (strList[2].Equals("White") && !isBlack) return true;
            return false;
        }

        public static bool IsEmpty(string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
