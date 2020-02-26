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
            var unitRoom = _roomViews.FirstOrDefault(x => x.GetId() == _unitPresenter.GetUnitRoomId(0));
            var targetRoom = _roomViews.FirstOrDefault(x => x.GetId() == roomId);
            var rooms =  Aster.Start(unitRoom,targetRoom,_roomViews).ToArray();
            Array.Reverse(rooms);
            _unitPresenter.MoveUnit(rooms.ToList());
        }
    }
}