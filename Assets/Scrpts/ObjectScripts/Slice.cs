﻿using System;
using Scrpts.ObjectScripts.Pieces;
using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts
{
    public class Slice : MonoBehaviour
    {
        public Material TextureNormal;
        public Material TextureHighLight;
        public Material TextureSelected;
        private Material[] _materials;
        private Material[] _renderMaterials;
        public string pieceName;
        public int status; 

        // Start is called before the first frame update
        private void Start()
        {
            // LogUtils.Log(gameObject.name + transform.position);
            _renderMaterials = GetComponent<MeshRenderer>().materials;
            _materials = new Material[_renderMaterials.Length];
            // TextureNormal = Resources.Load("Texture/SliceTexture/SliceNormal.mat", typeof(Material)) as Material;
            // TextureHighLight = Resources.Load("Texture/SliceTexture/SliceHighlight.mat", typeof(Material)) as Material;
            // TextureSelected = Resources.Load("Texture/SliceTexture/SliceSelected.mat", typeof(Material)) as Material;

        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void OnMouseDown()
        {
            if (pieceName != "")
            {
                switch (StringTools.GetPieceType(pieceName))
                {
                    case InitConfig.PIECE_BISHOP:
                        GameObject.Find(pieceName).GetComponent<Bishop>().OnClicked();
                        break;
                    case InitConfig.PIECE_PAWN:
                        GameObject.Find(pieceName).GetComponent<Pawn>().OnClicked();
                        break;
                    case InitConfig.PIECE_ROOK:
                        GameObject.Find(pieceName).GetComponent<Rook>().OnClicked();
                        break;
                    case InitConfig.PIECE_KNIGHT:
                        GameObject.Find(pieceName).GetComponent<Knight>().OnClicked();
                        break;
                    case InitConfig.PIECE_QUEEN:
                        GameObject.Find(pieceName).GetComponent<Queen>().OnClicked();
                        break;
                    case InitConfig.PIECE_KING:
                        GameObject.Find(pieceName).GetComponent<King>().OnClicked();
                        break;
                }

            }

            // If no piece selected, just return
            if (string.IsNullOrEmpty(Board.SharedInstance.selectedPiece)) return;
            // This slice has no piece on it and is highlight
            if (status == InitConfig.STATE_HIGHLIGHT) {
                if (!pieceName.Contains("Piece")) {     
                    // Move the selected piece to this slice
                    GameObject.Find(Board.SharedInstance.selectedPiece).GetComponent<Piece>().MoveToSlice(StringTools.GetSliceIndex(gameObject.name));
                }
            }else {
                // Board.SharedInstance.ClearAllMarkSlice();
            }
        }

        public string GetPieceName()
        {
            return pieceName;
        }
        
        public void SetPieceName(string pName)
        {
            pieceName = pName;
        }
        // Set the slice state to Highlight
        public void HighLight()
        {
            Debug.Log(gameObject.name +  ": Highllight");
            _renderMaterials[0].color = Color.yellow;
            status = InitConfig.STATE_HIGHLIGHT;
        }

        // Set the slice state to Selected
        public void Selected()
        {
            Debug.Log(gameObject.name +  ": Selected");
            _renderMaterials[0].color = Color.red;
            status = InitConfig.STATE_SELECTED;
        }

        // Set the slice state to Normal
        public void Normal()
        {
            // Name of the Slice contains two number, which represents the index of col and row.
            // If sum of col and row equals is divisible by 2, it is a black slice, otherwise white. 
            // e.g Piece-1-3
            // Debug.Log(gameObject.name +  ": Normal");
            _renderMaterials[0].color = StringTools.GetSliceNums(gameObject.name)%2 == 0 ? Color.black : Color.white;
            status = InitConfig.STATE_NORMAL;
        }
        
        // Set color when a slice is initialized
        public void SetColor(int color)
        {
            GetComponent<MeshRenderer>().materials[0].color = color == 0 ? Color.black : Color.white;
        }
    }
}
