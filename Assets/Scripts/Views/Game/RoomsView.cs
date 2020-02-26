using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Game;
using Framework;
using UnityEngine;
using Zenject;

namespace Views.Main
{
    public class RoomsView : ViewBase
    {
        private List<RoomView> _list = new List<RoomView>();

        private IUnitsPresenter _unitPresenter;
        private RoomView[] _roomViews;

        
        [Inject]
        private void Construct(IUnitsPresenter unitPresenter)
        {
            _unitPresenter = unitPresenter;
            
        }

        public void OnClicked(int roomId)
        {
            _roomViews = GetComponentsInChildren<RoomView>();
            var roomNodes = new List<Node>();
            foreach (var roomView in _roomViews)
            {
                roomNodes.Add(new Node(roomView.GetId(),roomView.GetPosition(),roomView.GetNeighborsId()));
            }
            var unitRoom = _roomViews.FirstOrDefault(x => x.GetId() == _unitPresenter.GetUnitRoomId(0));
            var targetRoom = _roomViews.FirstOrDefault(x => x.GetId() == roomId);
            
            var aster = new Aster();
            var startNode = new Node(unitRoom.GetId(), unitRoom.transform.position, unitRoom.GetNeighborsId());
            var targetNode = new Node(targetRoom.GetId(), targetRoom.transform.position, targetRoom.GetNeighborsId());
            var rooms = aster.Exec(startNode,targetNode,roomNodes);
            
            Array.Reverse(rooms);
            var result = new List<RoomView>();
            foreach (var room in rooms)
            {
                result.Add(_roomViews.FirstOrDefault(x => x.GetId() == room.Id));
            }
            _unitPresenter.MoveUnit(result);
        }
    }
}