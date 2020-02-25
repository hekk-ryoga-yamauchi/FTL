using System.Collections.Generic;
using Contracts.Game;
using Models;
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
    }
}