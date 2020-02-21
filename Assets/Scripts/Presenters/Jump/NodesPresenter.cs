using Contracts.Jump;
using Framework;
using Models;
using ViewModels.Jump;
using Views.Jump;

namespace Presenters
{
    public class NodesPresenter : PresenterBase, INodesPresenter
    {
        private INodesModel _model;
        private NodesView _nodesView;
        private GameModel _gameModel;
        
        public NodesPresenter(GameModel gameModel, NodesView nodesView)
        {
            _nodesView = nodesView;
            _gameModel = gameModel;
            _model = gameModel.NodesModel;
            var viewModel = new NodesViewModel(_model.GetNodes());
            _nodesView.Init(this,viewModel,gameModel.PlayerModel.CurrentId);
        }

        public void OnClicked(int id)
        {
            _gameModel.PlayerModel.SetCurrentId(id);

        }
    }
}