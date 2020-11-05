using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class Rook : Piece
    {
        private int _moveStep;

        // Start is called before the first frame update
        private void Start()
        {
            _moveStep = 1;
        }

        public void Initialize(int color, string name, Vector3 pos)
        {
            SetColor(color);
            SetObjectName(name);
            SetPosition(pos);
        }
    }
}
