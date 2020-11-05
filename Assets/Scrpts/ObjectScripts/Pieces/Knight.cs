using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class Knight : Piece
    {
        private int _moveStep;

        // Start is called before the first frame update
        private void Start()
        {
            _moveStep = 1;
        }
    }
}
