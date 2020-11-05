using System.Collections;
using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;

public class ListChain<T>
{
    private List<T> _list;
    
    public ListChain()
    {
        LogUtils.Log("ListChain-Cons");
        _list = new List<T>();

    }
    // private List<T> list;
    public ListChain<T> AddItem(T item)
    {
        _list.Add(item);
        return this;
    }

    public List<T> GetList()
    {
        return _list;
    }
    
}
