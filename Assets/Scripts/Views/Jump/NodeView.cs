using System.Collections.Generic;
using Contracts.Jump;
using Framework;
using UnityEngine;
using Zenject;

namespace Views.Jump
{
    public class NodeView : ViewBase
    {
        [SerializeField]
        public int _id;

        public Vector2 Position => GetPosition();

        private INodePresenter _presenter;
        private IEnumerable<KeyValuePair<NodeView, float>> _nodeViews;
        private List<GameObject> lines = new List<GameObject>();
        
        

        [Inject]
        private void Construct(INodePresenter presenter)
        {
            _presenter = presenter;
        }

        public void OnPointerEnter()
        {
            if (lines.Count == 0)
            {
                CreateEdges();
            }
            else
            {
                RenderEdges();
            }
        }

        private void RenderEdges()
        {
            lines.ForEach(x => x.gameObject.SetActive(true));
        }

        private void CreateEdges()
        {
            var enumerator = _nodeViews.GetEnumerator();
            while (enumerator.MoveNext())
            {
                GameObject line = new GameObject();
                line.gameObject.transform.SetParent(gameObject.transform);
                var lineRenderer = line.AddComponent<LineRenderer>();
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, gameObject.transform.position);
                var pos = enumerator.Current.Key.Position;
                lineRenderer.SetPosition(1, new Vector3(pos.x,pos.y,-1));
                lines.Add(line);
            }
        }

        public void OnPointerExit()
        {
            lines.ForEach(x => x.gameObject.SetActive(false));
        }

        public void OnClicked()
        {
            Debug.Log(",クリックされたで");
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
    }
}