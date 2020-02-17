using System.Collections.Generic;
using System.Linq;
using Contracts.Jump;
using Framework;
using UnityEngine;
using Zenject;

namespace Views.Jump
{
    public class NodesView : ViewBase
    {
        private INodesPresenter _presenter;
        private IJumpModel _models;
        
        private List<NodeView> _nodeList = new List<NodeView>();

        [Inject]
        private void Construct(INodesPresenter presenter, IJumpModel models)
        {
            _presenter = presenter;
            _nodeList = GetComponentsInChildren<NodeView>().ToList();
            _models = models;
            var enumerator = _nodeList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                SetNearNode(6, enumerator);
            }
        }

        private void SetNearNode(int nodesCount,List<NodeView>.Enumerator enumerator )
        {
            Dictionary<NodeView,float> dic = new Dictionary<NodeView, float>();
            foreach (var node in _nodeList)
            {
                var range = GetRange(enumerator.Current, node.Position);
                dic.Add(node,range);
            }

            var nears = dic.OrderBy(x => x.Value).Take(nodesCount);
            enumerator.Current.SetNearNodes(nears);
        }

        private float GetRange(NodeView view, Vector2 pos)
        {
            var x = view.Position.x - pos.x;
            var y = view.Position.y - pos.y;
            return x * x + y * y;
        }
    }
}