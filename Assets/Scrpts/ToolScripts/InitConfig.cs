using System.Collections;
using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;

public class InitConfig : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        LogUtils.SetMode(LogUtils.MODE_DEBUG);
    }

}
