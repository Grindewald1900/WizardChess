using UnityEngine;

namespace Scrpts.ToolScripts
{
    public class MouseDoubleClick : MonoBehaviour
    {
        private bool _lBtnClicked;
        private bool _rBtnClicked;
        private bool _lBtnDoubleClicked;
        private bool _rBtnDoubleClicked;
        private const float Interval = 0.5f;
        private float _intervalLeft;
        private float _intervalRight;


        // Start is called before the first frame update
        private void Start()
        {
            _lBtnClicked = false;
            _rBtnClicked = false;
            _intervalLeft = Interval;
            _intervalRight = Interval;
        }

        // Update is called once per frame
        private void Update()
        {
            CheckBtnDoubleClick();
            if (_lBtnDoubleClicked) {
                Debug.Log("Double Click Left" + Time.time);
            }
            if (_rBtnDoubleClicked) {
                Debug.Log("Double Click Right" + Time.time);
            }
        
        }

        private void CheckBtnDoubleClick()
        {
            _rBtnDoubleClicked = _lBtnDoubleClicked = false;
            if (Input.GetMouseButtonUp(0)) {
                if (_lBtnClicked && Time.time - _intervalLeft < Interval) {
                    _lBtnDoubleClicked = true;
                } else {
                    _intervalLeft = Time.time;
                }
                _lBtnClicked = !_lBtnClicked;
            }
            if (Input.GetMouseButtonUp(1)) {
                if (_rBtnClicked && Time.time - _intervalRight < Interval) {
                    _rBtnDoubleClicked = true;
                } else {
                    _intervalRight = Time.time;
                }
                _rBtnClicked = !_rBtnClicked;
            }
        }
    }
}