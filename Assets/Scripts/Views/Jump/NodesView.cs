using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Contracts.Jump;
using Framework;
using Models;
using UnityEngine;
using ViewModels.Jump;
using Zenject;

namespace Views.Jump
{
    public class NodesView : ViewBase
    {
        private GameModel _model;

        private List<NodeView> _nodeList = new List<NodeView>();
        private INodesPresenter _presenter;
        private int _playerCurrentId;
        private NodeView _playerStayPoint;

        [Inject]
        DiContainer _container = null;


        public void Init(INodesPresenter presenter, NodesViewModel viewModel, int playerCurrentId)
        {
            _presenter = presenter;
            CreateChildren(viewModel);
            _playerCurrentId = playerCurrentId;
        }

        public void CreateChildren(NodesViewModel viewModel)
        {
            foreach (var node in viewModel.GetNodes())
            {
                var obj = Resources.Load("Jump/Prefabs/node");
                var instance = _container.InstantiatePrefab(obj, gameObject.transform);
                instance.transform.position = new Vector3(node.Value.x - 50, node.Value.y - 50, 0);
                var nodeView = instance.GetComponent<NodeView>();
                nodeView.Init(node.Key, _presenter);
                _nodeList.Add(instance.GetComponent<NodeView>());
            }
            
            _nodeList.ForEach(x => SetNearNode(6, x));
            _playerStayPoint = _nodeList.FirstOrDefault(x => x.GetId() == _playerCurrentId);
            _playerStayPoint.SetIsStay(true);
            _playerStayPoint.CreatePlayerEdges();
        }
        

        private void SetNearNode(int nodesCount, NodeView enumerator)
        {
            Dictionary<NodeView, float> dic = new Dictionary<NodeView, float>();
            foreach (var node in _nodeList)
            {
                var range = GetRange(enumerator, node.Position);
                
                dic.Add(node, range);
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