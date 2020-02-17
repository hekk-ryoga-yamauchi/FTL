using System.Collections.Generic;
using System.Linq;
using Contracts.Jump;
using Framework;
using Models;
using Models.Game;
using UnityEngine;
using Zenject;

namespace Views.Jump
{
    public class NodesView : ViewBase
    {
        private INodesPresenter _presenter;
        private GameModel _model;
        
        private List<NodeView> _nodeList = new List<NodeView>();

        [Inject]
        private void Construct(INodesPresenter presenter, GameModel model)
        {
            _presenter = presenter;
            _nodeList = GetComponentsInChildren<NodeView>().ToList();
            _model = model;
            var enumerator = _nodeList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                SetNearNode(6, enumerator.Current);
            }

            var playerCurrentId = _model.PlayerModel.CurrentId;
            var playerStayPoint = _nodeList.FirstOrDefault(x => x.GetId() == playerCurrentId);
            playerStayPoint.SetIsStay(true);
            SetNearNode(6,playerStayPoint);
            playerStayPoint.Init();
        }

        private void SetNearNode(int nodesCount,NodeView enumerator )
        {
            Dictionary<NodeView,float> dic = new Dictionary<NodeView, float>();
            foreach (var node in _nodeList)
            {
                var range = GetRange(enumerator, node.Position);
                dic.Add(node,range);
            }

            var nears = dic.OrderBy(x => x.Value).Take(nodesCount);
            enumerator.SetNearNodes(nears);
        }

        private float GetRange(NodeView view, Vector2 pos)
        {
            var x = view.Position.x - pos.x;
            var y = view.Position.y - pos.y;
            return x * x + y * y;
        }
    }
}