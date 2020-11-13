using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Scrpts.ObjectScripts.Pieces;
using Scrpts.RuleScripts;
using Scrpts.ToolScripts;
using UnityEngine;
using UnityEngine.AI;

namespace Scrpts.ObjectScripts
{
    public class Piece : MonoBehaviour
    {
        // Position on the board(8*8)
        private Vector2Int Index;
        private Vector3 _position;
        private bool _isRouting;
        private bool _hasEnemy;
        protected NavMeshAgent _agent;
        protected int Status;
        protected int MoveStep;
        protected MoveRules _moveRules;
        // protected bool _isPlayer;
        public bool isBlack;
        public int pieceScore;
        public Animator Animator;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int GetAttack = Animator.StringToHash("GetHurt");
        private static readonly int Die = Animator.StringToHash("Die");

        private bool isMoving = false;
        private float _stopDistance = 0f;



        
        // Update is called once per frame
        private void Update()
        {
        }

        private void FixedUpdate()
        {
            if(!isMoving) return;

            // Debug.Log(gameObject.name + "Current Pos: " + transform.position);
            // Debug.Log(gameObject.name + "Destin Pos:" + _agent.destination);
            // Debug.Log(gameObject.name + " : " + GeneralTools.GetRealDistance(transform.position, _agent.destination));
            
            // If moving towards an non-empty slice, stop before enemy and attack.
            if(GeneralTools.GetRealDistance(transform.position, _agent.destination) < 0.2f + _stopDistance)
            {
                _agent.isStopped = true;
                _agent.velocity = Vector3.zero;
                ChangeAnimationState(InitConfig.IDLE);
                _isRouting = false;
                if (_hasEnemy)
                {
                    ChangeAnimationState(InitConfig.ATTACK);
                    StartCoroutine(CompleteMovement());
                }
            
                isMoving = false;
            }
        }

        IEnumerator CompleteMovement()
        {
            yield return new WaitForSeconds(2);
            _agent.isStopped = false;
            Debug.Log("Agent des: " + _agent.destination);
        }


        public void Initialize(int color, string objName, Vector3 pos, Vector2Int index)
        {
            Status = InitConfig.STATE_NORMAL;
            _agent = GetComponent<NavMeshAgent>();
            _isRouting = false;
            Animator = GetComponent<Animator>();
            SetColor(color);
            SetObjectName(objName);
            SetPosition(pos);
            SetIndex(index);
        }
        
        // Move this piece from A to B
        public void MoveToSlice(Vector2Int toIndex)
        {
            Debug.Log("Move:" + gameObject.name + " to " + toIndex);
            InitConfig.IsPlayerTurn = !gameObject.name.Contains("Black");
            // If the pawn is moved for the first time, set isFirstStep to false
            if (gameObject.name.Contains("Pawn") && GameObject.Find(gameObject.name).GetComponent<Pawn>().isFirstStep) {
                GameObject.Find(gameObject.name).GetComponent<Pawn>().isFirstStep = false;
            }
            
            ChangeAnimationState(InitConfig.WALK);
            _isRouting = true;
            // If an opponent stands on destination slice, remove that piece 
            if (Board.SharedInstance.SliceList[toIndex.x, toIndex.y].pieceName != "")
            {
                _stopDistance = 0.5f;
                _hasEnemy = true;
                var piece = GameObject.Find(Board.SharedInstance.SliceList[toIndex.x, toIndex.y].pieceName).GetComponent<Piece>();
                // piece.gameObject.SetActive(false);
                if (piece.isBlack) {
                    Board.SharedInstance.blackPieceList.Remove(piece);
                }else {
                    Board.SharedInstance.whitePieceList.Remove(piece);
                }
            } else {
                // Move to an empty slice
                _hasEnemy = false;
            }
            // Reset origin slice piece-name 
            Board.SharedInstance.SliceList[Index.x, Index.y].pieceName = "";
            // Set destination slice piece-name 
            Board.SharedInstance.SliceList[toIndex.x, toIndex.y].pieceName = gameObject.name;
            Board.SharedInstance.EditRecord(gameObject.name, GetIndex(), toIndex);
            // Move to destination with Navmesh
            
            // _agent.stoppingDistance = _stopDistance;
            _agent.destination = Board.SharedInstance.SliceList[toIndex.x, toIndex.y].transform.position;
            // _agent.stoppingDistance = _stopDistance;
            _agent.isStopped = false;
            isMoving = true;

            // transform.position = Board.SharedInstance.SliceList[toIndex.x, toIndex.y].transform.position + new Vector3(0, transform.localScale.y * 0.5f,0);
            SetIndex(toIndex);
            Board.SharedInstance.ClearAllMarkSlice();

            if (InitConfig.DUAL_AI) {
                StartCoroutine(AutoPlay());
            }else if (!InitConfig.IsPlayerTurn)
            {
                StartCoroutine(AutoPlay());
            }

            // if (!InitConfig.IsPlayerTurn)
            // {
            //     StartCoroutine(AutoPlay());
            // }
            // StopCoroutine("AutoPlay");

        }

        IEnumerator AutoPlay()
        {
            // Wait for 1 sec
            yield return new WaitForSeconds(1);
            switch (InitConfig.AI_TYPE)
            {
                case InitConfig.AI_MINIMAX_LOOP:
                    var minimax = new MiniMaxLoop(InitConfig.IsPlayerTurn);
                    minimax.AutoPlay();
                    break;
                case InitConfig.AI_MINIMAX_ALPHA_BETA:
                    break;
                case InitConfig.AI_RANDOM:
                    break;
                default:
                    break;
            }
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
                // GetComponent<MeshRenderer>().materials[0].color = Color.red;
            }else
            {
                isBlack = false;
                transform.Rotate(0,180,0);
                // GetComponent<MeshRenderer>().materials[0].color = Color.white;
            }
        }

        public void SetObjectName(string name)
        {
            gameObject.name = name;
        }

        // Deal with mouse click event
        protected void MouseClick(List<Vector2Int> markList)
        {
              // When animation is ongoing, pieces are not clickable
            if(!InitConfig.IsClickable) return;
            // Status = Status == InitConfig.STATE_NORMAL ? InitConfig.STATE_SELECTED : InitConfig.STATE_NORMAL;
            
            // Case1: No piece selected
            if (!Board.SharedInstance.selectedPiece.Contains("Piece"))
            {
                if(isBlack != InitConfig.IsPlayerTurn) return;
                Status = InitConfig.STATE_SELECTED;
                Board.SharedInstance.selectedPiece = gameObject.name;
                Board.SharedInstance.ChangeSliceState(GetIndex(), InitConfig.STATE_SELECTED);
                Board.SharedInstance.MarkAvailableSlice(markList);
            }
            // Piece selected
            else
            {
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
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.transform.gameObject.name.Contains("Piece"))
            {
                // other.attachedRigidbody.AddForce((other.attachedRigidbody.transform.position - transform.position));
            }
        }

        private void ChangeAnimationState(int state)
        {
            switch (state)
            {
                // Idle State
                case InitConfig.IDLE:
                    Animator.SetBool(Walk, false);
                    Animator.SetBool(Attack,false);
                    break;
                // Moving State
                case InitConfig.WALK:
                    Animator.SetBool(Walk, true);
                    Animator.SetBool(Attack,false);
                    break;
                // Attack State
                case InitConfig.ATTACK:
                    Animator.SetBool(Walk, false);
                    Animator.SetBool(Attack, true);
                    break;
                // Hurt State
                case InitConfig.GETATTACK:
                    Animator.SetBool(GetAttack, true);
                    break;
                // Destroy State
                case InitConfig.DIE:
                    Animator.SetBool(Die, true);
                    break;
                default:
                    break;
            }
        }
    }
}
