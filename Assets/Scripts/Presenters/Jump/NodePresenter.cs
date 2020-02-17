using Contracts.Jump;
using Framework;
using Models;
using Models.Game;
using Views.Jump;
using Zenject;

namespace Presenters
{
    public class NodePresenter : PresenterBase, INodePresenter
    {
        private NodeView _nodeView;
        private GameModel _model;

        public NodePresenter(GameModel model)
        {
            _model = model;
        }

        public void OnClicked(int id)
        {
            _model.PlayerModel.SetCurrentId(id);
        }
    }
}