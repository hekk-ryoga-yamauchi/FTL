using Framework;
using MasterDatas;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Main
{
    public class RoomView : ButtonView
    {

        [SerializeField]
        private RoomTypeMasterData _roomType;

        [SerializeField]
        private int _id;

        public RoomView _right;
        
        public RoomView _left;
        
        public RoomView _up;
        
        public RoomView _under;
        
        private Button _button;

        public bool IsOpen { get; private set; }
        public RoomView Parent { get; private set; }
        public NodeStateMasterData State { get; private set; } = NodeStateMasterData.None;
        
        

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }
        
        public  override void OnClick()
        {
            
        }

        public Vector2 GetPosition()
        {
            return transform.position;
        }

        public int GetId()
        {
            return _id;
        }
    }
}