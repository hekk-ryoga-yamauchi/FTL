using System.Collections.Generic;
using Contracts.Jump;
using UnityEngine;

namespace Models.Jump
{
    public class NodesModel : INodesModel
    {
        private Dictionary<int,NodeModel> _nodes = new Dictionary<int,NodeModel>();

        public NodesModel(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var x = Random.Range(0, 30)*3;
                var y = Random.Range(0, 30)*3;
                _nodes.Add(i,new NodeModel(i,new Vector3(x,y)));
            }
        }

        public Dictionary<int,NodeModel> GetNodes()
        {
            return _nodes;
        }
    }
}