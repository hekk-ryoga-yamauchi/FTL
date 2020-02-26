using System.Collections.Generic;
using System.Linq;
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

        private RoomsView _roomsView;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
            _roomsView = transform.parent.GetComponent<RoomsView>();
        }
        
        public  override void OnClick()
        {
             _roomsView.OnClicked(_id);
        }

        public Vector2 GetPosition()
        {
            return transform.position;
        }

        public int GetId()
        {
            return _id;
        }

        public Node GetNode()
        {
            return new Node(_id, transform.position, GetNeighborsId());
        }

        public int[] GetNeighborsId()
        {
            List<int> list = new List<int>();
            if (_right != null)
            {
                list.Add(_right.GetId());
            }
            if (_left != null)
            {
                list.Add(_left.GetId());
            }
            if (_up != null)
            {
                list.Add(_up.GetId());
            }
            if (_under != null)
            {
                list.Add(_under.GetId());
            }
            
            return list.ToArray();
        }
    }
}