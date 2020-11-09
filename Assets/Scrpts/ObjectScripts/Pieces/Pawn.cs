using System.Collections;
using System.Collections.Generic;
using Scrpts.RuleScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts.Pieces
{
    public class Pawn : Piece
    {
        public bool isFirstStep;
        // Player hold the pieces at the bottom of the board.
        // Start is called before the first frame update
        private void Start()
        {
            MoveStep = 1;
            isFirstStep = true;
            _moveRules = new MoveRules();
            pieceScore = isBlack ? InitConfig.SCORE_PAWN : InitConfig.SCORE_PAWN * -1;

        }
        
        private void OnMouseDown()
        {
            var markList = new List<Vector2Int>();
            // If the pawn doesn't touch the base line of its opponent, run the inner code below
            if (!(isBlack && GetIndex().y == InitConfig.BOARD_SIZE - 1) && !(!isBlack && GetIndex().y == 0))
            {
                if (isFirstStep) {
                    markList.AddRange(_moveRules.Pawn(GetIndex(), MoveStep, isBlack, true));
                }else {
                    markList.AddRange(_moveRules.Pawn(GetIndex(), MoveStep, isBlack, false));
                }
            }
            MouseClick(markList);
        }
        
        public void OnClicked()
        {
            Debug.Log("Pawn Clicked");
            var markList = new List<Vector2Int>();
            // If the pawn doesn't touch the base line of its opponent, run the inner code below
            if (!(isBlack && GetIndex().y == InitConfig.BOARD_SIZE - 1) && !(!isBlack && GetIndex().y == 0))
            {
                if (isFirstStep) {
                    markList.AddRange(_moveRules.Pawn(GetIndex(), MoveStep, isBlack, true));
                }else {
                    markList.AddRange(_moveRules.Pawn(GetIndex(), MoveStep, isBlack, false));
                }
            }
            MouseClick(markList);
        }
        
    }
}

