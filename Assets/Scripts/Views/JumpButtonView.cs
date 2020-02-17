using System;
using Framework;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public class JumpButtonView : ButtonView
    {
        private Button _button = default;

        public Action OnClicked;


        [Inject]
        protected override void Construct()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => { Debug.Log("Jumpが押されたよ"); }
            );
        }
        public  override void OnClick()
        {
            _button.onClick?.Invoke();
        }
    }
}