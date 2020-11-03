using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    private int _moveStep = 10;
    private int _color;
    
    public Bishop(int c)
    {
        _color = c;
    }
    // Start is called before the first frame update
    private void Start()
    {
        SetColor(_color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
