using System.Collections.Generic;
using System.Linq;
using MasterDatas;
using UnityEngine;
using Views.Main;

namespace Framework
{
    /**
     * 渡されたスタートノードから、ゴールノードまでの最短距離を求める。
     * @return 最短経路のRoomViewの配列
     */
    public static class Aster
    {
        private static Node _startNode;
        private static Node _goalNode;
        private static List<Node> _openNodes;
        private static List<Node> _closedNodes;
        private static List<Node> _allNodes;
        private static List<RoomView> _result;


        private static void Init(RoomView[] roomViews)
        {
            _result = new List<RoomView>();
            _allNodes = new List<Node>();
            _openNodes = new List<Node>();
            _closedNodes = new List<Node>();
            
            
            foreach (var room in roomViews)
            {
                _allNodes.Add(new Node(room));
            }

            foreach (var node in _allNodes)
            {
                node.Init(_allNodes);
            }
        }

        public static List<RoomView> Start(RoomView startRoomView, RoomView goalRoomView, RoomView[] roomViews)
        {
            Init(roomViews);

            _startNode = _allNodes.FirstOrDefault(x => x.Id == startRoomView.GetId());
            _goalNode = _allNodes.FirstOrDefault(x => x.Id == goalRoomView.GetId());
            
            _openNodes.Add(_startNode);
            _startNode.SetNodeState(NodeStateMasterData.Open);
            var result = StartSearch(); // 同期処理
            var parents = result.GetPath(new List<Node>());

            // _result.Add(startRoomView);

            foreach (var parent in parents)
            {
                var roomView = parent.GetRoomView();
                _result.Add(roomView);
            }

            return _result;
        }


        // 探索の開始
        private static Node StartSearch()
        {
            // オープンノードがなくなれば探索失敗
            if (_openNodes.Count == 0)
            {
                Debug.Log("探索失敗。終了");
                return null;
            }

            // Openリストから最小の推定コストを持つノードを抽出し、親ノードにする。
            var parentNode = GetParentNode();
            Debug.Log(parentNode);

            //親ノードがgoalなら探索終了
            if (parentNode.Id == _goalNode.Id)
            {
                Debug.Log("探索完了");

                return parentNode;
            }

            _openNodes.Remove(parentNode);
            _closedNodes.Add(parentNode);
            parentNode.SetNodeState(NodeStateMasterData.Closed);

            //子ノードを求める(親のーどに隣接して移動可能な全てのノード)
            var children = parentNode.GetChildren(_allNodes);
            
            foreach (var node in children)
            {
                if (node == null) break;
                node.AddCost(1);

                if (node.GetNodeState() == NodeStateMasterData.None)
                {
                    // 子ノードをOpenリストに追加
                    // 子ノードの親をnとして追加
                    _openNodes.Add(node);
                    node.SetParent(parentNode);
                }
            }

            return StartSearch();
        }

        // Openノードから最小コストのノードを取得する
        private static Node GetParentNode()
        {
            var result = _openNodes[0];
            foreach (var node in _openNodes)
            {
                if (result.GetEstimationCost(_startNode, _goalNode) > node.GetEstimationCost(_startNode, _goalNode))
                {
                    result = node;
                }
            }

            return result;
        }
    }
}