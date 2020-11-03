using UnityEngine;

namespace Scrpts.ToolScripts
{
    public class LogUtils
    {
        public static int MODE_DEBUG = 1;
        public static int MODE_REALEASE = 2;
        private static int mode = 0;
        
        public LogUtils()
        {
        }

        public static void Log(object msg)
        {
            if (mode == MODE_DEBUG) Debug.Log(msg);
        }
        
        public static void LogTag(string tag, object msg)
        {
            if (mode == MODE_DEBUG) Debug.Log(tag + msg.ToString());
        }

        public static void LogAssertion(object msg)
        {
            if (mode == MODE_DEBUG) Debug.LogAssertion(msg);
        }
        
        public static void LogError(object msg)
        {
            if (mode == MODE_DEBUG) Debug.LogError(msg);
        }
        
        public static void SetMode(int m)
        {
            mode = m;
        }
    }
}
