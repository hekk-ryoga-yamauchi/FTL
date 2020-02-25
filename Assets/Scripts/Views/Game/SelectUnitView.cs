using Framework;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.Main
{
    public class SelectUnitView : ViewBase
    {
        [SerializeField]
        private Image _image;

        private bool _isSelecting;


        [Inject]
        private void Construct()
        {
        }

        public void ChangeSelecting ()
        {
            if (_isSelecting)
            {
                _image.color = Color.red;
            }
            else
            {
                _image.color= Color.green;
            }

            _isSelecting = !_isSelecting;
        }
    }
}