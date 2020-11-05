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
        private int _moveStep;
        private MoveRules _moveRules;

        // Start is called before the first frame update
        private void Start()
        {
            _moveStep = 10;
            _moveRules = new MoveRules();
        }
        
        private void OnMouseDown()
        {
            if(!InitConfig.IsClickable) return;
            Board.SharedInstance.ChangeSliceState(GetIndex(), InitConfig.SLICE_STATE_SELECTED);
            var markList = new List<Vector2Int>();
            markList.AddRange(_moveRules.Diagonal(GetIndex(), _moveStep));
            Board.SharedInstance.MarkAvailableSlice(markList);
            
        }

        
    }
}
