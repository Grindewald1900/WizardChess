using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Scrpts.RuleScripts;
using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class Bishop : Piece
    {
        // public Board Board;

        // Start is called before the first frame update
        private void Start()
        {
            MoveStep = 10;
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
