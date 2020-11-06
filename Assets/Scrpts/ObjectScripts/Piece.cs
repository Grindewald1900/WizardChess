using System;
using System.Collections.Generic;
using System.Dynamic;
using Scrpts.ObjectScripts.Pieces;
using Scrpts.RuleScripts;
using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts
{
    public class Piece : MonoBehaviour
    {
        // Position on the board(8*8)
        private Vector2Int Index;
        private int _score;
        protected int MoveStep;
        private Vector3 _position;
        protected int Status;
        protected MoveRules _moveRules;
        // protected bool _isPlayer;
        public bool isBlack;


        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        
        }

        public void Initialize(int color, string objName, Vector3 pos, Vector2Int index)
        {
            Status = InitConfig.STATE_NORMAL;
            SetColor(color);
            SetObjectName(objName);
            SetPosition(pos);
            SetIndex(index);
        }
        public void MoveToSlice(Vector2Int index)
        {
            if (gameObject.name.Contains("Pawn")) {
                GameObject.Find(gameObject.name).GetComponent<Pawn>().isFirstStep = false;
            }
            Board.SharedInstance.SliceList[Index.x, Index.y].pieceName = "";
            LogUtils.Log("Index" + Index);
            transform.position = Board.SharedInstance.SliceList[index.x, index.y].transform.position;
            SetIndex(index);
            Board.SharedInstance.ClearAllMarkSlice();
        }

        public void SetIndex(Vector2Int index)
        {
            Index = index;
        }

        public Vector2Int GetIndex()
        {
            return Index;
        }
        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        // Set piece color when a sub-class of Piece is initialized
        public void SetColor(int color)
        {
            if (color == 0) {
                isBlack = true;
                GetComponent<MeshRenderer>().materials[0].color = Color.red;
            }else
            {
                isBlack = false;
                GetComponent<MeshRenderer>().materials[0].color = Color.white;
            }
        }

        public void SetObjectName(string name)
        {
            gameObject.name = "Piece-" + name;
        }

        // Deal with mouse click event
        protected void MouseClick(List<Vector2Int> markList)
        {
              // When animation is ongoing, pieces are not clickable
            if(!InitConfig.IsClickable) return;
            
            // Status = Status == InitConfig.STATE_NORMAL ? InitConfig.STATE_SELECTED : InitConfig.STATE_NORMAL;
            LogUtils.Log("Bishop");
            LogUtils.Log(Board.SharedInstance.selectedPiece);

            // Case1: No piece selected
            if (!Board.SharedInstance.selectedPiece.Contains("Piece"))
            {
                Status = InitConfig.STATE_SELECTED;
                Board.SharedInstance.selectedPiece = gameObject.name;
                Board.SharedInstance.ChangeSliceState(GetIndex(), InitConfig.STATE_SELECTED);
                Board.SharedInstance.MarkAvailableSlice(markList);
            }
            // Piece selected
            else
            {
                LogUtils.Log("Piece Status:" + Status);
                LogUtils.Log("Slice Status:" + Board.SharedInstance.SliceList[GetIndex().x, GetIndex().y].status);

                if (Status == InitConfig.STATE_NORMAL)
                {
                    // Case2: Another Piece selected, then click on a normal piece(not highlighted)
                    if (Board.SharedInstance.SliceList[GetIndex().x, GetIndex().y].status == InitConfig.STATE_NORMAL)
                    {
                        Board.SharedInstance.ClearAllMarkSlice();
                    }
                    // Case3: Another Piece selected, then click on a highlighted piece
                    if (Board.SharedInstance.SliceList[GetIndex().x, GetIndex().y].status == InitConfig.STATE_HIGHLIGHT)
                    {

                        var p = GameObject.Find(Board.SharedInstance.selectedPiece).GetComponent<Piece>();
                        Board.SharedInstance.ClearAllMarkSlice();
                        // Return if this is not opponent of the selected piece
                        if(p.isBlack == isBlack) return;
                        // Destroy this object
                        p.MoveToSlice(GetIndex());
                        gameObject.SetActive(false);

                    }
                    
                }
                // Case4: Piece selected, then click on the same piece
                if (Status == InitConfig.STATE_SELECTED)
                {
                    Status = InitConfig.STATE_NORMAL;
                    Board.SharedInstance.ClearAllMarkSlice();
                }
            }
        }

        private void ChangeAnimationState(int state)
        {
            switch (state)
            {
                // Idle State
                case 0:
                    break;
                // Moving State
                case 1:
                    break;
                // Attack State
                case 2:
                    break;
                // Hurt State
                case 3:
                    break;
                // Destroy State
                case 4:
                    break;
                default:
                    break;
            }
        }
    }
}
