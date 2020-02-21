using System.Collections.Generic;
using Contracts.Game;
using Framework;
using Models;
using Presenters.Game;
using UnityEngine;
using Zenject;

namespace Views.Main
{
    public class UnitsView : ViewBase
    {
        [Inject]
        DiContainer _container = null;

        private GameModel _gameModel;

        private List<UnitView> _unitViews = new List<UnitView>();

        [Inject]
        private void Construct(GameModel gameModel)
        {
            _gameModel = gameModel;
           
        }

        public UnitView CreateUnitView(IUnitPresenter presenter)
        {
            var obj = Resources.Load("Main/Prefabs/Unit");
            var instance = _container.InstantiatePrefab(obj, gameObject.transform);
            var unitView = instance.GetComponent<UnitView>();
            unitView.Init(presenter);
            return unitView;
        }

        
    }
}