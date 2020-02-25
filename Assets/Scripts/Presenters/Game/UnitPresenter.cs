using Contracts.Game;
using Models;
using Views.Main;

namespace Presenters.Game
{
    public class UnitPresenter: IUnitPresenter
    {
        private GameModel _gameModel;
        private IUnitModel _model;
        private UnitView _unitView;
        private SelectUnitView _selectUnitView;

        public UnitPresenter(GameModel gameModel, IUnitModel model, SelectUnitView selectUnitView)
        {
            _gameModel = gameModel;
            _model = model;
            _selectUnitView = selectUnitView;
        }
        
        public void Init(UnitView unitView)
        {
            _unitView = unitView;
        }
        
        public int Damage(int damage)
        {
            return _model.Damage(damage);
        }

        public int GetId()
        {
            return _model.GetId();
        }

        public int GetHp()
        {
            return _model.GetHp();
        }

        public void SetSelectUnit()
        {
            _selectUnitView.ChangeSelecting();
        }
    }
}