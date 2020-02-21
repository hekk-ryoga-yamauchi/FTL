using Contracts.Jump;
using UnityEngine;

namespace Models.Jump
{
    public class NodeModel : INodeModel
    {
        private int _id;
        private Vector3 _position;

        public NodeModel(int id, Vector3 position)
        {
            _id = id;
            _position = position;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

    }
}