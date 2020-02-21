using System.Collections.Generic;
using Models.Jump;
using UnityEngine;
using Views.Jump;

namespace ViewModels.Jump
{
    public struct NodesViewModel
    {
        private Dictionary<int, Vector3> _dictionary;

        public NodesViewModel(Dictionary<int, NodeModel> dictionary)
        {
            _dictionary = new Dictionary<int, Vector3>();
            foreach (var node in dictionary)
            {
                _dictionary.Add(node.Key, node.Value.GetPosition());
            }
        }

        public Dictionary<int, Vector3> GetNodes()
        {
            return _dictionary;
        }
    }
}