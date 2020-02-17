using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Framework
{
    public abstract class ButtonView : MonoBehaviour
    {
        protected Button _button = default;

        public Action OnClicked;


        [Inject]
        protected abstract void Construct();

        public abstract void OnClick();
    }
}