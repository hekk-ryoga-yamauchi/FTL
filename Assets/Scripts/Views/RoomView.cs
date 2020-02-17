using System;
using Framework;
using MasterDatas;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views
{
    public class RoomView : ButtonView
    {
        private Button _button = default;

        [SerializeField]
        private RoomTypeMasterData _roomType;

        public Action OnClicked;


        [Inject]
        protected override void Construct()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => { Debug.Log($"{_roomType.ToString()}が押されたよ"); }
            );
        }
        public  override void OnClick()
        {
            _button.onClick?.Invoke();
        }
    }
}