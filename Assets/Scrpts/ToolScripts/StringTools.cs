using UnityEngine;

namespace Scrpts.ToolScripts
{
    public class StringTools
    {
        public static int GetPieceNums(string pName)
        {
            var strList = pName.Split('-');
            return strList.Length > 0 ? int.Parse(strList[1]) + int.Parse(strList[2]) : 0;
        }

        public static Vector2Int GetSliceIndex(string sName)
        {
            var strList = sName.Split('-');
            return new Vector2Int(int.Parse(strList[1]), int.Parse(strList[2]));
        }

        public static bool IsEmpty(string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
