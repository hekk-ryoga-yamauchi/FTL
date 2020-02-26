using System.Collections.Generic;
using System.Linq;
using Contracts.Game;
using Models;
using UnityEngine;
using Views.Main;

namespace Presenters.Game
{
    public class UnitsPresenter : IUnitsPresenter
    {
        private GameModel _gameModel;
        List<UnitPresenter> _units = new List<UnitPresenter>();

        private UnitsView _unitsView;

        public UnitsPresenter(GameModel gameModel, UnitsView unitsView, SelectUnitView selectUnitView)
        {
            _unitsView = unitsView;
            _gameModel = gameModel;
            var units = gameModel.UnitsModel.GetUnitModels();
            foreach (var unitModel in units)
            {
                var presenter = new UnitPresenter(gameModel, unitModel,selectUnitView);
                var unitView = _unitsView.CreateUnitView(presenter);
                presenter.Init(unitView);
                _units.Add(presenter);
            }
        }

        public void MoveUnit(List<RoomView> roomView)
        {
           var unit =  _units[0];
           unit.Move(roomView);
        }

        public int GetUnitRoomId(int id)
        {
            var unit = _units.FirstOrDefault(x => x.GetId() == id);
            return unit.GetUnitRoomId();
        }
    }
}