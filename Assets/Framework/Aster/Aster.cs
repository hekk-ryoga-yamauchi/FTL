using System.Collections.Generic;
using System.Linq;
using MasterDatas;
using UnityEngine;

namespace Framework
{
    /**
     * 渡されたスタートノードから、ゴールノードまでの最短距離を求める。
     * @return 最短経路のRoomViewの配列
     */
    public class Aster
    {
        private int cnt = 0;
        public Node[] Exec(Node startNode, Node targetNode, List<Node> allNodes)
        {
            var _openNodes = new List<Node>();
            var _closedNodes = new List<Node>();

            _openNodes.Add(startNode);
            startNode.SetNodeState(NodeStateMasterData.Open);
            var result = StartSearch(_openNodes, _closedNodes, allNodes.ToList(), targetNode); // 同期処理
            var path = result.GetPath(new List<Node>());
            return path;
        }


        // 探索の開始
        private Node StartSearch(List<Node> _openNodes, List<Node> _closedNodes, List<Node> _allNodes,
            Node _goalNode)
        {
            // オープンノードがなくなれば探索失敗
            while (_openNodes.Count != 0)
            {
                Debug.Log(cnt++);
                // Openリストから最小の推定コストを持つノードを抽出し、親ノードにする。
                var currentNode = GetParentNode(_openNodes);
                // Debug.Log(currentNode);

                //親ノードがgoalなら探索終了
                if (currentNode.Id == _goalNode.Id)
                {
                    Debug.Log("探索完了");
                    return currentNode;
                }

                _openNodes.Remove(currentNode);
                _closedNodes.Add(currentNode);
                currentNode.SetNodeState(NodeStateMasterData.Closed);

                //子ノードを求める(親のーどに隣接して移動可能な全てのノード)
                var children = currentNode.GetChildren(_allNodes);

                foreach (var node in children)
                {
                    var currentEstimationCost = currentNode.GetEstimationCost(currentNode.GetCost(), _goalNode);
                    // 状態がNoneのとき、Openに入れる
                    if (node.GetNodeState() == NodeStateMasterData.None)
                    {
                        // 子ノードをOpenリストに追加
                        // 子ノードの親をnとして追加
                        _openNodes.Add(node);
                        node.SetParent(currentNode);
                        node.SetCost(currentEstimationCost + 1.0f);
                        node.SetNodeState(NodeStateMasterData.Open);
                    }
                    // 状態がClosedで、そのnodeに設定されているcostよりcurrentのcostの方が低い場合経路を更新
                    else if (
                        node.GetNodeState() == NodeStateMasterData.Closed && 
                        node.GetCost() > currentEstimationCost)
                    {
                        
                        _closedNodes.Remove(node);
                        _openNodes.Add(node);
                        node.SetParent(currentNode);
                        node.SetCost(currentEstimationCost + 1.0f);
                        node.SetNodeState(NodeStateMasterData.Open);

                    }
                    // 状態がOpenで、そのnodeに設定されているコストよりcurrentのcostが低い場合更新
                    else if (node.GetNodeState() == NodeStateMasterData.Open &&
                             node.GetCost() > currentEstimationCost)
                    {
                        node.SetParent(currentNode);
                        node.SetCost(currentEstimationCost + 1.0f);
                    }
                }
            }

            Debug.Log("探索失敗。終了");
            return null;
        }

        // Openノードから最小コストのノードを取得する
        private Node GetParentNode(List<Node> _openNodes)
        {
            var result = _openNodes.OrderBy(x => x.GetCost()).First();
            return result;
        }
    }
}