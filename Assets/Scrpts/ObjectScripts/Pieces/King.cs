using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class King : Piece
    {
        private int _moveStep;

        // Start is called before the first frame update
        private void Start()
        {
            _moveStep = 1;
        }
        
        // Game lose
        private void OnDestroy()
        {
            
        }
    }
}
