using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class Bishop : Piece
    {
        private int _moveStep;

        // Start is called before the first frame update
        private void Start()
        {
            _moveStep = 10;
        }

        
    }
}
