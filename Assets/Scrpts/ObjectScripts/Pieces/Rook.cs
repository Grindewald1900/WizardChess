using System.Collections;
using System.Collections.Generic;
using Scrpts.RuleScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class Rook : Piece
    {

        // Start is called before the first frame update
        private void Start()
        {
            MoveStep = 10;
            _moveRules = new MoveRules();
        }
        
        private void OnMouseDown()
        {
            var markList = new List<Vector2Int>();
            markList.AddRange(_moveRules.Horizontal(GetIndex(), MoveStep));
            markList.AddRange(_moveRules.Vertical(GetIndex(), MoveStep));
            MouseClick(markList);
        }
        
    }
}
