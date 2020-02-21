using System.Collections.Generic;
using Contracts.Jump;
using Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Views.Jump
{
    public class NodeView : ViewBase
    {
        private int _id;

        public Vector2 Position => GetPosition();

        private IEnumerable<KeyValuePair<NodeView, float>> _nodeViews;
        private List<GameObject> _lines = new List<GameObject>();

        private bool _isPlayerStay = false;

        private INodesPresenter _nodesPresenter;
        
        
        public void Init(int id, INodesPresenter presenter)
        {
            _id = id;
            _nodesPresenter = presenter;
        }

        private void RenderEdges()
        {
            _lines.ForEach(x => x.gameObject.SetActive(true));
        }

        private void CreateEdges()
        {
            CreateEdge( Color.green, gameObject.transform);
        }

        public void CreatePlayerEdges()
        {
            var obj = new GameObject();
            obj.transform.SetParent(gameObject.transform.parent.parent);
            obj.name = "playerCurrentPoint";
            CreateEdge(Color.red ,obj.gameObject.transform);
        }

        private void CreateEdge(Color color, Transform parent)
        {
            var enumerator = _nodeViews.GetEnumerator();
            while (enumerator.MoveNext())
            {
                GameObject line = new GameObject();
                line.gameObject.transform.SetParent(parent);
                var lineRenderer = line.AddComponent<LineRenderer>();
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, gameObject.transform.position);
                var pos = enumerator.Current.Key.Position;
                lineRenderer.SetPosition(1, new Vector3(pos.x, pos.y, -1));
                lineRenderer.startColor=color;
                
                _lines.Add(line);
            }
        }
        
        
        public void OnPointerEnter()
        {
            if (_isPlayerStay) return;

            if (_lines.Count == 0)
            {
                CreateEdges();
            }
            else
            {
                RenderEdges();
            }
        }


        public void OnPointerExit()
        {
            if (_isPlayerStay) return;
            _lines.ForEach(x => x.gameObject.SetActive(false));
        }

        public void OnClicked()
        {
            if (_isPlayerStay) return;
            _nodesPresenter.OnClicked(_id);
            SceneManager.LoadSceneAsync("Battle");
        }

        public void SetNearNodes(IEnumerable<KeyValuePair<NodeView, float>> nodeViews)
        {
            _nodeViews = nodeViews;
        }

        private Vector2 GetPosition()
        {
            var pos = gameObject.transform.position;
            return new Vector2(pos.x, pos.y);
        }

        public int GetId()
        {
            return _id;
        }

        public void SetIsStay(bool state)
        {
            _isPlayerStay = state;
        }
    }
}