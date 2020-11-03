using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Piece : MonoBehaviour
{
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

    protected void MoveToSlice()
    {
        
    }

    // Set piece color when a sub-class of Piece is initialized
    protected void SetColor(int color)
    {
        if (color == 0) {
            GetComponent<MeshRenderer>().materials[0].color = Color.black;
        }else
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.white;
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
