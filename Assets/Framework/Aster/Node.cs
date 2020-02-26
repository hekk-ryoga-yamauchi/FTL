using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterDatas;
using UnityEngine;

namespace Framework
{
    public class Node
    {
        public int Id;
        private int[] _neighborsId;
        private Node _parent;
        private double _cost;
        private Vector2 _position;

        private NodeStateMasterData _state;

        public Node(int id, Vector2 position, int[] neighborsId)
        {
            Id = id;
            _position = position;
            _neighborsId = neighborsId;
        }
        public Vector2 GetPosition()
        {
            return _position;
        }

        public NodeStateMasterData GetNodeState()
        {
            return _state;
        }

        public void SetNodeState(NodeStateMasterData state)
        {
            _state = state;
        }

        public void SetParent(Node parent)
        {
            _parent = parent;
        }
        
        public void SetCost(double cost)
        {
            _cost = cost;
        }
        
        public double GetCost()
        {
            return _cost;
        }

        // 推定コスト,スタートノードからこのノードを経由してゴールノードに到達するまでの推定最小コスト(最短距離)
        public double GetEstimationCost(double cost, Node goalNode)
        {
            var toGoalCost = GetToGoalCost(this, goalNode);
            return  cost + toGoalCost;
        }

        public double GetToGoalCost(Node from, Node to)
        {
            var startPos = from.GetPosition();
            var endPos = to.GetPosition();
            var result = Vector2.Distance(startPos, endPos);
            // Debug.Log(from+ "から" + to + "までの距離は" + result);
            return result;
        }

        public Node[] GetPath(List<Node> children)
        {
            if (_parent == null)
            {
                return children.ToArray();
            }

            children.Add(this);
            return _parent.GetPath(children);
        }

        public Node[] GetChildren(List<Node> all)
        {
            var list = new List<Node>();
            foreach (var node in all)
            {
                if (_neighborsId.Contains(node.Id))
                {
                    list.Add(node);
                }
            }
            return list.ToArray();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Id : {Id}");
            return stringBuilder.ToString();
        }

        
    }
}