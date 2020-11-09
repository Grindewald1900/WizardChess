using System.Collections;
using System.Collections.Generic;
using Scrpts.RuleScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class Knight : Piece
    {

        // Start is called before the first frame update
        private void Start()
        {
            MoveStep = 1;
            _moveRules = new MoveRules();
            pieceScore = isBlack ? InitConfig.SCORE_KNIGHT : InitConfig.SCORE_KNIGHT * -1;
        }
        
        private void OnMouseDown()
        {
            var markList = new List<Vector2Int>();
            markList.AddRange(_moveRules.Knight(GetIndex(), isBlack));
            MouseClick(markList);
        }
        
        public void OnClicked()
        {
            Debug.Log("Knight Clicked");
            var markList = new List<Vector2Int>();
            markList.AddRange(_moveRules.Knight(GetIndex(), isBlack));
            MouseClick(markList);

        }
    }
}
