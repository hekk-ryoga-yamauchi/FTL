using System.Collections.Generic;
using Framework;
using UnityEngine;

namespace Views.Main
{
    public class RoomsView : ViewBase
    {
        private List<RoomView> _list = new List<RoomView>();

        [SerializeField]
        private RoomView _startRoom;

        [SerializeField]
        private RoomView _goalRoom;

        private void Start()
        {
            var children = GetComponentsInChildren<RoomView>();
            var nodes = Aster.Start(_startRoom,_goalRoom,children);
            foreach (var node in nodes)
            {
                Debug.Log(node.GetId());
            }
        }
    }
}