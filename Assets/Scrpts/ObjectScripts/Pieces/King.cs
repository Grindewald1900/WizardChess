using Scrpts.RuleScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class King : Piece
    {

        // Start is called before the first frame update
        private void Start()
        {
            MoveStep = 1;
            _moveRules = new MoveRules();

        }
        
        // Game lose
        private void OnDestroy()
        {
            
        }
    }
}
