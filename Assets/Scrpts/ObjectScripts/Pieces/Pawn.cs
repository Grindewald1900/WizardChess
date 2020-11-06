using System.Collections;
using System.Collections.Generic;
using Scrpts.RuleScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class Pawn : Piece
    {
        private bool isFirstStep;
        // Start is called before the first frame update
        private void Start()
        {
            MoveStep = 1;
            isFirstStep = true;
            _moveRules = new MoveRules();
        }
        
        private void OnMouseDown()
        {
            var markList = new List<Vector2Int>();
            markList.AddRange(_moveRules.Diagonal(GetIndex(), MoveStep));
            MouseClick(markList);
        }
        
    }
}

