using System;
using Scrpts.ToolScripts;
using UnityEngine;

namespace Scrpts.ObjectScripts
{
    public class Piece : MonoBehaviour
    {
        public Vector2Int Index;
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

        private void OnDestroy()
        {
            
        }

        public void Initialize(int color, string name, Vector3 pos)
        {
            SetColor(color);
            SetObjectName(name);
            SetPosition(pos);
        }
        protected void MoveToSlice(Vector3 pos)
        {
        }
    
        protected void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        // Set piece color when a sub-class of Piece is initialized
        protected void SetColor(int color)
        {
            LogUtils.Log("SetColor");
            if (color == 0) {
                GetComponent<MeshRenderer>().materials[0].color = Color.red;
            }else
            {
                GetComponent<MeshRenderer>().materials[0].color = Color.white;
            }
        }

        protected void SetObjectName(string name)
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
