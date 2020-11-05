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
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Highlight");
                HighLight();
            }

            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("Select");
                Selected();
            }
        }

        private void HighLight()
        {
            _renderMaterials[0].color = Color.yellow;
        }

        private void Selected()
        {
            _renderMaterials[0].color = Color.red;
        }

        private void Normal()
        {
            _renderMaterials[0].color = Color.white;
        }
        
        // Set color when a slice is initialized
        public void SetColor(int color)
        {
            if (color == 0) {
                GetComponent<MeshRenderer>().materials[0].color = Color.black;
            }else
            {
                GetComponent<MeshRenderer>().materials[0].color = Color.white;
            }
        }
    }
}
