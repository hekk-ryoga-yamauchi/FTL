using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Framework
{
    public abstract class ButtonView : MonoBehaviour
    {
        private Button _button { get; set; }

        public Action OnClicked;


        [Inject]
        protected virtual void Construct()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public abstract void OnClick();
    }
}