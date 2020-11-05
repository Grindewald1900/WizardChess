using System;
using System.Dynamic;
using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts
{
    public class Piece : MonoBehaviour
    {
        private Vector2Int Index;
        private int _score;
        private int _moveStep;
        private Vector3 _position;

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
            SetColor(color);
            SetObjectName(objName);
            SetPosition(pos);
            SetIndex(index);
        }
        protected void MoveToSlice(Vector3 pos)
        {
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
                GetComponent<MeshRenderer>().materials[0].color = Color.red;
            }else
            {
                GetComponent<MeshRenderer>().materials[0].color = Color.white;
            }
        }

        public void SetObjectName(string name)
        {
            gameObject.name = "Piece-" + name;
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
