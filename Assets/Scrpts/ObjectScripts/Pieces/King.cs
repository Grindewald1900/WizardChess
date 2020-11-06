using System.Collections.Generic;
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
        
        private void OnMouseDown()
        {
            var markList = new List<Vector2Int>();
            markList.AddRange(_moveRules.Diagonal(GetIndex(), MoveStep));
            markList.AddRange(_moveRules.Horizontal(GetIndex(), MoveStep));
            markList.AddRange(_moveRules.Vertical(GetIndex(), MoveStep));
            MouseClick(markList);
        }
    }
}
