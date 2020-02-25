using System.Collections.Generic;
using System.Linq;
using System.Text;
using MasterDatas;
using UnityEngine;
using Views.Main;

namespace Framework
{
    public class Node
    {
        public int Id;
        private RoomView _roomView;
        private Node _right;
        private Node _left;
        private Node _up;
        private Node _under;
        private Node _parent;
        private double _cost;

        private NodeStateMasterData _state;

        public Node(RoomView roomView)
        {
            _roomView = roomView;
            Id = roomView.GetId();
        }

        public void Init(List<Node> allNodes)
        {
            SetNearRooms(allNodes);
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

        public RoomView GetRoomView()
        {
            return _roomView;
        }

        public void AddCost(int cost)
        {
            _cost += cost;
        }

        // 推定コスト,スタートノードからこのノードを経由してゴールノードに到達するまでの推定最小コスト(最短距離)
        public double GetEstimationCost(Node startNode, Node goalNode)
        {
            var fromStartCost = _cost;
            var toGoalCost = GetToGoalCost(this, goalNode);
            return fromStartCost + toGoalCost;
        }

        public double GetToGoalCost(Node from, Node to)
        {
            var startPos = from.GetRoomView().transform.position;
            var endPos = to.GetRoomView().transform.position;
            var result =  Mathf.Sqrt(Mathf.Pow(startPos.x - endPos.x, 2) +
                       Mathf.Pow(startPos.y - endPos.y, 2));
            Debug.Log(from+ "から" + to + "までの距離は" + result);
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

        private void SetNearRooms(List<Node> allNodes)
        {
            if (_roomView._right != null)
            {
                _right = allNodes.FirstOrDefault(x => x.Id == _roomView._right.GetId());
            }

            if (_roomView._left != null)
            {
                _left = allNodes.FirstOrDefault(x => x.Id == _roomView._left.GetId());
            }

            if (_roomView._up != null)
            {
                _up = allNodes.FirstOrDefault(x => x.Id == _roomView._up.GetId());
            }

            if (_roomView._under != null)
            {
                _under = allNodes.FirstOrDefault(x => x.Id == _roomView._under.GetId());
            }
        }

        public Node[] GetChildren(List<Node> allNodes)
        {
            SetNearRooms(allNodes);
            Node[] nodes = new Node[4];
            int cnt = 0;
            if (_right != null)
            {
                nodes[cnt] = _right;
                cnt++;
            }

            if (_left != null)
            {
                nodes[cnt] = _left;
                cnt++;
            }

            if (_up != null)
            {
                nodes[cnt] = _up;
                cnt++;
            }

            if (_under != null)
            {
                nodes[cnt] = _under;
                cnt++;
            }

            return nodes;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Id : {Id}");
            return stringBuilder.ToString();
        }
    }
}