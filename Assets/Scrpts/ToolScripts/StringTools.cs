namespace Scrpts.ToolScripts
{
    public class StringTools
    {
        public static int GetPieceNums(string pName)
        {
            var strList = pName.Split('-');
            return strList.Length > 0 ? int.Parse(strList[1]) + int.Parse(strList[2]) : 0;
        }
    }
}
