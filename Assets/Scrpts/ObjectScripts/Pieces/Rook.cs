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
            pieceScore = isBlack ? InitConfig.SCORE_ROOK : InitConfig.SCORE_ROOK * -1;

        }
        
        private void OnMouseDown()
        {
            var markList = new List<Vector2Int>();
            markList.AddRange(_moveRules.Horizontal(GetIndex(), MoveStep, isBlack));
            markList.AddRange(_moveRules.Vertical(GetIndex(), MoveStep, isBlack));
            MouseClick(markList);
        }
        
        public void OnClicked()
        {
            Debug.Log("Rook Clicked");
            var markList = new List<Vector2Int>();
            markList.AddRange(_moveRules.Horizontal(GetIndex(), MoveStep, isBlack));
            markList.AddRange(_moveRules.Vertical(GetIndex(), MoveStep, isBlack));
            MouseClick(markList);
        }
        
    }
}
